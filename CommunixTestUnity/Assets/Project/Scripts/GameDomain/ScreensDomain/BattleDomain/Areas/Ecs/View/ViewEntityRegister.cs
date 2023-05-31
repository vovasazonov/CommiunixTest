using Osyacat.Ecs.Entity;
using Osyacat.Ecs.World;
using UnityEngine;
using Zenject;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs
{
    public class ViewEntityRegister : MonoBehaviour
    {
        [SerializeField] private EntityView _entityView;
        private IWorld _world;

        [Inject]
        private void Constructor(IWorld world)
        {
            _world = world;
        }
        
        private void Awake()
        {
            var entity = _world.CreateEntity();
            _entityView.Initialize(entity);
            var componentRegisters = GetComponents<ComponentRegister>();
            
            if (componentRegisters != null)
            {
                foreach (var componentRegister in componentRegisters)
                {
                    componentRegister.Register(entity);
                }
            }
        }

        private void OnDestroy()
        {
            _entityView.UnInitialize();
        }
    }
}