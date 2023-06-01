using Osyacat.Ecs.Entity;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Fire
{
    public class BulletComponentRegister : ComponentRegister
    {
        public override void Register(IEntity entity)
        {
            entity.Replace<BulletComponent>();
        }
    }
}