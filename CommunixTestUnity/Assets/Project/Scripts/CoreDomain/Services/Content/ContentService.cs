using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Project.CoreDomain.Services.Content
{
    public class ContentService : IContentService
    {
        private readonly Dictionary<string, AsyncOperationHandle> _handles = new();
        private readonly Dictionary<string, int> _counter = new();
        
        public async UniTask<IContentKeeper<T>> LoadAsync<T>(string id) where T : class
        {
            AsyncOperationHandle handle;

            if (_handles.ContainsKey(id))
            {
                handle = _handles[id];
            }
            else
            {
                handle = Addressables.LoadAssetAsync<T>(id);
                _handles.Add(id, handle);
            }

            if (!_counter.ContainsKey(id))
            {
                _counter.Add(id, 0);
            }

            _counter[id]++;
            
            await handle.Task;
            
            var result = handle.Result as T;

            if (result == null)
            {
                throw new NullReferenceException();
            }
            
            return new ContentKeeper<T>(this, id, result);
        }

        internal void Unload(string id)
        {
            if (_counter[id] == 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            
            _counter[id]--;

            if (_counter[id] == 0 && _handles.ContainsKey(id))
            {
                var handle = _handles[id];
                _handles.Remove(id);
                Addressables.Release(handle);
            }
        }
    }
}