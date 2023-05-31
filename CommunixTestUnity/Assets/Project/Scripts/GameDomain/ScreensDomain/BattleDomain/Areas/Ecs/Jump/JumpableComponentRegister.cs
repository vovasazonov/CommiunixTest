using Osyacat.Ecs.Entity;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Jump
{
    public class JumpableComponentRegister : ComponentRegister
    {
        public override void Register(IEntity entity)
        {
            entity.Replace<JumpableComponent>();
        }
    }
}