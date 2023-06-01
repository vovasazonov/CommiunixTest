using System.Collections.Generic;
using Osyacat.Ecs.Entity;
using Osyacat.Ecs.System;
using Osyacat.Ecs.World;
using Project.CoreDomain.Services.View;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Direction;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Fire;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Jump;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Position;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Proportion;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Speed;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Enemy
{
    public class EnemyDestroyerSystem : IUpdateSystem, IBeforeUpdateSystem
    {
        private readonly IWorld _world;
        private readonly IViewService _viewService;
        private readonly IFilter _bulletFilter;
        private readonly IFilter _enemyFilter;
        private readonly List<IEntity> _buffer = new();
        private readonly List<IEntity> _toDestroy = new();

        public EnemyDestroyerSystem(IWorld world, IViewService viewService)
        {
            _world = world;
            _viewService = viewService;
            _bulletFilter = world.GetFilter(matcher => matcher.Has<BulletComponent>().Has<ElasticComponent>().Has<SpeedComponent>().Has<DirectionComponent>());
            _enemyFilter = world.GetFilter(matcher => matcher.Has<PositionComponent>().Has<ProportionComponent>().Has<EnemyComponent>());
        }

        public void Update()
        {
            _enemyFilter.UpdateBuffer(_buffer);
            
            foreach (var enemy in _buffer)
            {
                foreach (var bullet in _bulletFilter)
                {
                    var elastic = bullet.Get<ElasticComponent>();

                    var enemyPosition = enemy.Get<PositionComponent>().Value;
                    var enemyProportion = enemy.Get<ProportionComponent>();

                    var isOnX = enemyPosition.x + enemyProportion.Width / 2 >= elastic.Start.x && enemyPosition.x - enemyProportion.Width / 2 <= elastic.Start.x;
                    var isOnY = enemyPosition.y - enemyProportion.Height / 2 <= elastic.End.y;

                    var isEnemyTrigger = isOnX && isOnY;

                    if (isEnemyTrigger)
                    {
                        var enemyComponent = enemy.Get<EnemyComponent>();
                        var enemyPrefab = enemy.Get<PrefabComponent>();
                        enemyComponent.CurrentLevel++;
                        if (enemyComponent.CurrentLevel <= enemyComponent.Levels.Count)
                        {
                            InstantiateEnemy(enemyComponent, enemyPrefab, enemyPosition, Vector3.left);
                            InstantiateEnemy(enemyComponent, enemyPrefab, enemyPosition, Vector3.right);
                        }

                        _toDestroy.Add(enemy);
                    }
                }
            }
        }

        private void InstantiateEnemy(EnemyComponent enemyComponent, PrefabComponent prefab, Vector3 position, Vector3 direction)
        {
            var entity = _world.CreateEntity();
            var view = _viewService.Create(prefab.Prefab, prefab.Parent);
            view.Value.gameObject.GetComponent<ViewEntityRegister>().InitializeEntity(entity);
            view.Value.Initialize(entity);
            var instantiatedEnemyComponent = entity.Replace<EnemyComponent>();
            var levelInfo = enemyComponent.Levels[enemyComponent.CurrentLevel - 1];
            instantiatedEnemyComponent.Levels = enemyComponent.Levels;
            instantiatedEnemyComponent.CurrentLevel = enemyComponent.CurrentLevel;
            entity.Replace<JumpForceComponent>().Value = levelInfo.JumpForce;
            var proportionComponent = entity.Replace<ProportionComponent>();
            proportionComponent.Height = levelInfo.Radius;
            proportionComponent.Width = levelInfo.Radius;
            entity.Replace<PositionComponent>().Value = position;
            entity.Replace<DirectionComponent>().Value = direction;
        }

        private static void DestroyEnemy(IEntity enemy)
        {
            var view = enemy.Get<ViewComponent>().Value;
            enemy.Get<ViewComponent>().Value.UnInitialize();
            ((EntityView)view).gameObject.SetActive(false);
            enemy.Destroy();
        }

        public void BeforeUpdate()
        {
            foreach (var toDestroy in _toDestroy)
            {
                DestroyEnemy(toDestroy);
            }

            _toDestroy.Clear();
        }
    }
}