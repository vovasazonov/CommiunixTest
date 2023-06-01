using Osyacat.Ecs.Entity;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Proportion
{
    public class ProportionComponentRegister : ComponentRegister
    {
        [SerializeField] private float _height;
        [SerializeField] private float _width;
        
        public override void Register(IEntity entity)
        {
            if (!entity.Contains<ProportionComponent>())
            {
                var proportion = entity.Replace<ProportionComponent>();
                proportion.Height = _height;
                proportion.Width = _width;
            }
        }
    }
}