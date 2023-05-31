using Osyacat.Ecs.Entity;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Speed
{
    public class SpeedComponentRegister : ComponentRegister
    {
        [SerializeField] private float _speed;
        
        public override void Register(IEntity entity)
        {
            entity.Replace<SpeedComponent>().Value = _speed;
        }
    }
}