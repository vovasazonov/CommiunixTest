using Osyacat.Ecs.Entity;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Direction
{
    public class DirectionComponentRegister : ComponentRegister
    {
        public Vector3Int Direction = Vector3Int.left;
        
        public override void Register(IEntity entity)
        {
            if (!entity.Contains<DirectionComponent>())
            {
                entity.Replace<DirectionComponent>().Value = Direction;
            }
        }
    }
}