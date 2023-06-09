using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Project.CoreDomain.Services.View
{
    public interface IViewService
    {
        UniTask<IDisposableView<T>> CreateAsync<T>(string assetId) where T : MonoBehaviour;
        IDisposableView<T> Create<T>(T prefab, Transform parent) where T : MonoBehaviour;
    }
}