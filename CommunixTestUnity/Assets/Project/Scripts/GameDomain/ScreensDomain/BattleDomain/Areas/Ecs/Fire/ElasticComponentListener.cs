using Osyacat.Ecs.Component.Event;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Fire
{
    public class ElasticComponentListener : ComponentListener<ElasticComponent>
    {
        [SerializeField] private LineRenderer _lineRenderer;
        
        public override void OnChanged(ElasticComponent component)
        {
            _lineRenderer.SetPosition(0, component.Start);
            _lineRenderer.SetPosition(1, component.End);
        }
    }
}