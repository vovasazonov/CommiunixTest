using Osyacat.Ecs.Component.Component;
using Osyacat.Ecs.Entity;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs
{
    [Component]
    public class PrefabComponent
    {
        public Transform Parent;
        public EntityView Prefab;
    }
}