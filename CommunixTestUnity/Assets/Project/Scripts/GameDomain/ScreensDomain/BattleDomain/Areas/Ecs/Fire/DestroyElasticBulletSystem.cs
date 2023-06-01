using System.Collections.Generic;
using Osyacat.Ecs.Entity;
using Osyacat.Ecs.System;
using Osyacat.Ecs.World;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Direction;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Player;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Position;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Proportion;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Speed;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Zone;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Fire
{
    public class DestroyElasticBulletSystem : IUpdateSystem
    {
        private readonly IFilter _bulletFilter;
        private readonly IFilter _ballFilter;
        private readonly List<IEntity> _buffer = new();
        private readonly IFilter _wallFilter;

        public DestroyElasticBulletSystem(IWorld world)
        {
            _bulletFilter = world.GetFilter(matcher => matcher.Has<BulletComponent>().Has<ElasticComponent>().Has<SpeedComponent>().Has<DirectionComponent>());
            _ballFilter = world.GetFilter(matcher => matcher.Has<PositionComponent>().Has<ProportionComponent>().None<PlayerComponent>().None<LandWallComponent>().None<SideWallComponent>());
            _wallFilter = world.GetFilter(matcher => matcher.Has<LandWallComponent>());
        }

        public void Update()
        {
            _bulletFilter.UpdateBuffer(_buffer);

            foreach (var bullet in _buffer)
            {
                var isBulletDestroyed = false;
                var elastic = bullet.Get<ElasticComponent>();

                foreach (var ball in _ballFilter)
                {
                    var position = ball.Get<PositionComponent>().Value;
                    var proportion = ball.Get<ProportionComponent>();

                    var isOnX = position.x + proportion.Width / 2 >= elastic.Start.x && position.x - proportion.Width / 2 <= elastic.Start.x;
                    var isOnY = position.y - proportion.Height / 2 <= elastic.End.y;

                    var isBallTrigger = isOnX && isOnY;

                    if (isBallTrigger)
                    {
                        DestroyBullet(bullet);
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
                            DestroyBullet(bullet);
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
            Object.DestroyImmediate(((EntityView)view).gameObject);
            bullet.Destroy();
        }
    }
}