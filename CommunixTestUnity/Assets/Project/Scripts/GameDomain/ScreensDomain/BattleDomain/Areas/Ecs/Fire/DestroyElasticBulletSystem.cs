using System.Collections.Generic;
using Osyacat.Ecs.Entity;
using Osyacat.Ecs.System;
using Osyacat.Ecs.World;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Direction;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Enemy;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Position;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Proportion;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Speed;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Zone;
using Object = UnityEngine.Object;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Fire
{
    public class DestroyElasticBulletSystem : IUpdateSystem, ILateUpdateSystem
    {
        private readonly IFilter _bulletFilter;
        private readonly IFilter _enemyFilter;
        private readonly List<IEntity> _buffer = new();
        private readonly IFilter _wallFilter;
        private readonly List<IEntity> _toDestroy = new();

        public DestroyElasticBulletSystem(IWorld world)
        {
            _bulletFilter = world.GetFilter(matcher => matcher.Has<BulletComponent>().Has<ElasticComponent>().Has<SpeedComponent>().Has<DirectionComponent>());
            _enemyFilter = world.GetFilter(matcher => matcher.Has<PositionComponent>().Has<ProportionComponent>().Has<EnemyComponent>());
            _wallFilter = world.GetFilter(matcher => matcher.Has<LandWallComponent>());
        }

        public void Update()
        {
            _bulletFilter.UpdateBuffer(_buffer);

            foreach (var bullet in _buffer)
            {
                var isBulletDestroyed = false;
                var elastic = bullet.Get<ElasticComponent>();

                foreach (var enemy in _enemyFilter)
                {
                    var position = enemy.Get<PositionComponent>().Value;
                    var proportion = enemy.Get<ProportionComponent>();

                    var isOnX = position.x + proportion.Width / 2 >= elastic.Start.x && position.x - proportion.Width / 2 <= elastic.Start.x;
                    var isOnY = position.y - proportion.Height / 2 <= elastic.End.y;

                    var isEnemyTrigger = isOnX && isOnY;

                    if (isEnemyTrigger)
                    {
                        _toDestroy.Add(bullet);
                        isBulletDestroyed = true;
                        break;
                    }
                }

                if (!isBulletDestroyed)
                {
                    foreach (var wall in _wallFilter)
                    {
                        var position = wall.Get<PositionComponent>().Value;
                        var proportion = wall.Get<ProportionComponent>();
                        
                        var isOnY = position.y - proportion.Height / 2 <= elastic.End.y && elastic.Start.y <= position.y - proportion.Height / 2;
                        
                        if (isOnY)
                        {
                            _toDestroy.Add(bullet);
                            break;
                        }
                    }
                }
            }
        }

        private static void DestroyBullet(IEntity bullet)
        {
            var view = bullet.Get<ViewComponent>().Value;
            bullet.Get<ViewComponent>().Value.UnInitialize();
            Object.Destroy(((EntityView)view).gameObject);
            bullet.Destroy();
        }

        public void LateUpdate()
        {
            foreach (var toDestroy in _toDestroy)
            {
                DestroyBullet(toDestroy);
            }

            _toDestroy.Clear();
        }
    }
}