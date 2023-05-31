using Osyacat.Ecs.Entity;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Player
{
    public class PlayerComponentRegister : ComponentRegister
    {
        [SerializeField] private int _id;
        
        public override void Register(IEntity entity)
        {
            entity.Replace<PlayerComponent>().Id = _id;
        }
    }
}