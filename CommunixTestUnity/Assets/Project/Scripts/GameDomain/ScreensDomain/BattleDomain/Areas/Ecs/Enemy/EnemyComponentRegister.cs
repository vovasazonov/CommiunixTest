using System.Collections.Generic;
using Osyacat.Ecs.Entity;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Enemy
{
    public class EnemyComponentRegister : ComponentRegister
    {
        [SerializeField] private List<EnemyLevelInfo> _levels;
        
        public override void Register(IEntity entity)
        {
            if (!entity.Contains<EnemyComponent>())
            {
                var enemyComponent = entity.Replace<EnemyComponent>();
                enemyComponent.Levels = _levels;
                enemyComponent.CurrentLevel = 1;
            }
        }
    }
}