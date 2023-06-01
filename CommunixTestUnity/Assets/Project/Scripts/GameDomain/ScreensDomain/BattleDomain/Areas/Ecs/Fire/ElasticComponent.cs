using Osyacat.Ecs.Component.Component;
using Osyacat.Ecs.Component.Event;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Fire
{
    [Component, EventComponent]
    public class ElasticComponent
    {
        public Vector3 Start;
        public Vector3 End;
    }
}