using Osyacat.Ecs.Entity;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs
{
    [RequireComponent(typeof(ViewEntityRegister))]
    public abstract class ComponentRegister : MonoBehaviour
    {
        public abstract void Register(IEntity entity);
    }
}