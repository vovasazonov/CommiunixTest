using Osyacat.Ecs.Component.Event;
using UnityEngine;

namespace Osyacat.Ecs.Entity
{
    public class EntityView : MonoBehaviour, IEntityView
    {
        protected IEntity _entity;

        public void Initialize(IEntity entity)
        {
            if (_entity == null)
            {
                _entity = entity;
            }

            _entity.Replace<ViewComponent>().Value = this;

            foreach (var listener in GetComponents<IComponentListener>())
            {
                listener.Register(_entity);
            }
        }

        public void UnInitialize()
        {           
            if (_entity != null)
            {
                foreach (var listener in GetComponents<IComponentListener>())
                {
                    listener.Unregister();
                }

                _entity.Remove<ViewComponent>();
                _entity = null;
            }
        }
    }
}