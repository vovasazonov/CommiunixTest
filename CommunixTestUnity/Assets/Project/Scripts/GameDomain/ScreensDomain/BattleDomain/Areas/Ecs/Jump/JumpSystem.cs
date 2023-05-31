using System.Collections.Generic;
using Osyacat.Ecs.Entity;
using Osyacat.Ecs.System;
using Osyacat.Ecs.World;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Position;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Proportion;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Zone;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Jump
{
    public class JumpSystem : IUpdateSystem
    {
        private readonly IFilter _jumpableFilter;
        private readonly IFilter _inputFilter;
        private readonly List<IEntity> _buffer = new();
        private readonly float _gravity = -9.81f;
        private readonly IFilter _jumpingFilter;
        private readonly IFilter _wallFilter;

        public JumpSystem(IWorld world)
        {
            _jumpableFilter = world.GetFilter(matcher => matcher.Has<JumpableComponent>().Has<PositionComponent>().Has<JumpForceComponent>());
            _jumpingFilter = world.GetFilter(matcher => matcher.Has<JumpingComponent>().Has<PositionComponent>().Has<JumpForceComponent>());
            _wallFilter = world.GetFilter(matcher => matcher.Has<LandWallComponent>().Has<ProportionComponent>().Has<PositionComponent>());
        }

        public void Update()
        {
            _jumpableFilter.UpdateBuffer(_buffer);

            foreach (var jump in _buffer)
            {
                if (!jump.Contains<JumpingComponent>())
                {
                    jump.Replace<JumpingComponent>().Velocity = jump.Get<JumpForceComponent>().Value;
                }
            }

            _jumpingFilter.UpdateBuffer(_buffer);

            foreach (var jump in _buffer)
            {
                var velocity = jump.Get<JumpingComponent>().Velocity + _gravity * Time.deltaTime;
                jump.Replace<JumpingComponent>().Velocity = velocity;
                    
                var position = jump.Get<PositionComponent>().Value;
                var y = position.y + velocity * Time.deltaTime;
                
                var jumpableProportion = jump.Get<ProportionComponent>();
                var jumpableBottomHeightPosition = y - jumpableProportion.Height / 2;
                var jumpableTopHeightPosition = y + jumpableProportion.Height / 2;

                foreach (var wall in _wallFilter)
                {
                    var wallPosition = wall.Get<PositionComponent>().Value;
                    var wallProportion = wall.Get<ProportionComponent>();
                    var wallTopHeightPosition = wallPosition.y + wallProportion.Height / 2;
                    var wallBottomHeightPosition = wallPosition.y - wallProportion.Height / 2;

                    if (y > wallTopHeightPosition)
                    {
                        if (jumpableBottomHeightPosition <= wallTopHeightPosition)
                        {
                            position.y = wallTopHeightPosition + jumpableProportion.Height / 2;
                            if (jump.Contains<JumpingComponent>())
                            {
                                jump.Remove<JumpingComponent>();
                            }
                        }
                        else
                        {
                            position.y = y;
                        }
                    }
                    else if(y < wallBottomHeightPosition)
                    {
                        if (jumpableTopHeightPosition >= wallBottomHeightPosition)
                        {
                            position.y = wallBottomHeightPosition - jumpableProportion.Height / 2;
                            jump.Replace<JumpingComponent>().Velocity = -velocity;
                        }
                        else
                        {
                            position.y = y;
                        }
                    }
                }

                jump.Replace<PositionComponent>().Value = position;
            }
        }
    }
}