using Cysharp.Threading.Tasks;

namespace Project.CoreDomain.Services.Content
{
    public interface IContentService
    {
        UniTask<IContentKeeper<T>> LoadAsync<T>(string id) where T : class;
    }
}