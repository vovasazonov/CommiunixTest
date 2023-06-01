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
        private IEntity _entity;

        [Inject]
        private void Constructor(IWorld world)
        {
            _world = world;
        }
        
        private void Start()
        {
            var entity = _entity ?? _world.CreateEntity();
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

        public void InitializeEntity(IEntity entity)
        {
            _entity = entity;
        }

        private void OnDestroy()
        {
            _entityView.UnInitialize();
        }
    }
}