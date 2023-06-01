using Osyacat.Ecs.Component.Component;
using Osyacat.Ecs.Component.Event;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Proportion
{
    [Component, EventComponent]
    public class ProportionComponent
    {
        public float Height;
        public float Width;
    }
}