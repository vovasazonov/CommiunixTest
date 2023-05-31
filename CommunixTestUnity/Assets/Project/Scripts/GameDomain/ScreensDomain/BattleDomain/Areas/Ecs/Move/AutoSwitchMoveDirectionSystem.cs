using Osyacat.Ecs.System;
using Osyacat.Ecs.World;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Direction;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Position;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Proportion;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Zone;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Move
{
    public class AutoSwitchMoveDirectionSystem : IUpdateSystem
    {
        private readonly IFilter _movableFilter;
        private readonly IFilter _wallFilter;

        public AutoSwitchMoveDirectionSystem(IWorld world)
        {
            _movableFilter = world.GetFilter(matcher => matcher.Has<MovableComponent>().Has<PositionComponent>().Has<DirectionComponent>());
            _wallFilter = world.GetFilter(matcher => matcher.Has<SideWallComponent>());
        }

        public void Update()
        {
            foreach (var movable in _movableFilter)
            {
                var movableDirection = movable.Get<DirectionComponent>().Value;
                var movablePosition = movable.Get<PositionComponent>().Value;
                var movableProportion = movable.Get<ProportionComponent>();
                var movableX = movablePosition.x;
                var movableLeftWidthPosition = movableX - movableProportion.Width / 2;
                var movableRightWidthPosition = movableX + movableProportion.Width / 2;

                foreach (var wall in _wallFilter)
                {
                    var wallPosition = wall.Get<PositionComponent>().Value;
                    var wallProportion = wall.Get<ProportionComponent>();
                    var wallX = wallPosition.x;
                    var wallLeftWidthPosition = wallX - wallProportion.Width / 2;
                    var wallRightWidthPosition = wallX + wallProportion.Width / 2;

                    if (movableX > wallLeftWidthPosition)
                    {
                        if (movableLeftWidthPosition <= wallRightWidthPosition && movableDirection == Vector3.left)
                        {
                            if (!movable.Contains<AutoSwitchableDirectionMoveComponent>())
                            {
                                movable.Replace<DirectionComponent>().Value = Vector3.zero;
                            }
                            else
                            {
                                movable.Replace<DirectionComponent>().Value = Vector3.right;
                            }
                        }
                    }
                    else if (movableX < wallRightWidthPosition && movableDirection == Vector3.right)
                    {
                        if (movableRightWidthPosition >= wallLeftWidthPosition)
                        {
                            if (!movable.Contains<AutoSwitchableDirectionMoveComponent>())
                            {
                                movable.Replace<DirectionComponent>().Value = Vector3.zero;
                            }
                            else
                            {
                                movable.Replace<DirectionComponent>().Value = Vector3.left;
                            }
                        }
                    }
                }
            }
        }
    }
}