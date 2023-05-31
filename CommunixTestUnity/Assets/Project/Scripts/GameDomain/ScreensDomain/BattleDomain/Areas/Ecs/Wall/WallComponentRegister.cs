using Osyacat.Ecs.Entity;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Zone
{
    public class WallComponentRegister : ComponentRegister
    {
        public override void Register(IEntity entity)
        {
            entity.Replace<WallComponent>();
        }
    }
}