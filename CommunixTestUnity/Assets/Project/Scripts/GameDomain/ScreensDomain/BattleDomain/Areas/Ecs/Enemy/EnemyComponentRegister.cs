using Osyacat.Ecs.Entity;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Enemy
{
    public class EnemyComponentRegister : ComponentRegister
    {
        public override void Register(IEntity entity)
        {
            entity.Replace<EnemyComponent>();
        }
    }
}