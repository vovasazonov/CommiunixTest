using Osyacat.Ecs.Component.Event;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Proportion
{
    public class ProportionComponentListener : ComponentListener<ProportionComponent>
    {
        public override void OnChanged(ProportionComponent component)
        {
            var scale = transform.localScale;
            scale.x = component.Width;
            scale.y = component.Height;
            transform.localScale = scale;
        }
    }
}