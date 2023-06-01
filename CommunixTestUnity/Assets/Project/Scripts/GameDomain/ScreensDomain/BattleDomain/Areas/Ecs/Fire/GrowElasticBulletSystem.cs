using Osyacat.Ecs.System;
using Osyacat.Ecs.World;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Direction;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Speed;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Fire
{
    public class GrowElasticBulletSystem : IUpdateSystem
    {
        private readonly IFilter _bulletFilter;
        private readonly IFilter _wallFilter;

        public GrowElasticBulletSystem(IWorld world)
        {
            _bulletFilter = world.GetFilter(matcher => matcher.Has<BulletComponent>().Has<ElasticComponent>().Has<SpeedComponent>().Has<DirectionComponent>());
        }

        public void Update()
        {
            foreach (var bullet in _bulletFilter)
            {
                var speed = bullet.Get<SpeedComponent>().Value;
                var elastic = bullet.Get<ElasticComponent>();
                var direction = bullet.Get<DirectionComponent>().Value;
                var newElastic = bullet.Replace<ElasticComponent>();
                newElastic.Start = elastic.Start;
                newElastic.End = elastic.End + direction * speed * Time.deltaTime;
            }
        }
    }
}