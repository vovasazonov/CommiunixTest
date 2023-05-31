using Osyacat.Ecs.Entity;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Move
{
    public class MovableComponentRegister : ComponentRegister
    {
        public override void Register(IEntity entity)
        {
            entity.Replace<MovableComponent>();
        }
    }
}