using System.Collections.Generic;
using Osyacat.Ecs.Component.Component;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Enemy
{
    [Component]
    public class EnemyComponent
    {
        public List<EnemyLevelInfo> Levels;
        public int CurrentLevel;
    }
}