﻿using Osyacat.Ecs.Entity;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Jump
{
    public class JumpForceComponentRegister : ComponentRegister
    {
        public float JumpForce;
        
        public override void Register(IEntity entity)
        {
            if (!entity.Contains<JumpForceComponent>())
            {
                entity.Replace<JumpForceComponent>().Value = JumpForce;
            }
        }
    }
}