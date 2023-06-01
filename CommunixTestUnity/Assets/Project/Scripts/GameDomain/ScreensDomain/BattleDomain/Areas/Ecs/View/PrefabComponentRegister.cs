using Osyacat.Ecs.Entity;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs
{
    public class PrefabComponentRegister : ComponentRegister
    {
        [SerializeField] private Transform _parent;
        [SerializeField] private EntityView _prefab;
        
        public override void Register(IEntity entity)
        {
            var prefabComponent = entity.Replace<PrefabComponent>();
            prefabComponent.Parent = _parent;
            prefabComponent.Prefab = _prefab;
        }
    }
}