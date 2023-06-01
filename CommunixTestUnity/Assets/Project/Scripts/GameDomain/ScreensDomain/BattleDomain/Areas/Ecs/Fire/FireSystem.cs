using Osyacat.Ecs.System;
using Osyacat.Ecs.World;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Direction;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Player;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Position;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Speed;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Fire
{
    public class FireSystem : IUpdateSystem
    {
        private readonly IWorld _world;
        private readonly IFilter _bulletPrefabFilter;
        private readonly IFilter _playerFireFilter;

        public FireSystem(IWorld world)
        {
            _world = world;
            _bulletPrefabFilter = world.GetFilter(matcher => matcher.Has<BulletComponent>().Has<PrefabComponent>());
            _playerFireFilter = world.GetFilter(matcher => matcher.Has<PlayerComponent>().Has<FireInputComponent>());
        }

        public void Update()
        {
            foreach (var player in _playerFireFilter)
            {
                var position = player.Get<PositionComponent>().Value;
                
                foreach (var bulletPrefab in _bulletPrefabFilter)
                {
                    var bullet = _world.CreateEntity();
                    var prefab = bulletPrefab.Get<PrefabComponent>();
                    var view = Object.Instantiate(prefab.Prefab, prefab.Parent);
                    view.Initialize(bullet);
                    bullet.Replace<BulletComponent>();
                    var elastic = bullet.Replace<ElasticComponent>();
                    elastic.Start = position;
                    elastic.End = position;
                    bullet.Replace<SpeedComponent>().Value = 5;
                    bullet.Replace<DirectionComponent>().Value = Vector3.up;
                }
            }
        }
    }
}