using Osyacat.Ecs.Entity;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Position
{
    public class PositionComponentRegister : ComponentRegister
    {
        public override void Register(IEntity entity)
        {
            if (!entity.Contains<PositionComponent>())
            {
                entity.Replace<PositionComponent>().Value = transform.position;
            }
        }
    }
}