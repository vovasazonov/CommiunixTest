using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Project.CoreDomain.Services.Audio.Collection;
using Project.CoreDomain.Services.Content;
using Project.CoreDomain.Services.Engine;
using Project.CoreDomain.Services.Time;
using Project.CoreDomain.Services.View;

namespace Project.CoreDomain.Services.Audio
{
    public class AudioService : IAudioService, ITaskAsyncInitializable, ITaskAsyncDisposable
    {
        private readonly List<AudioCollection> _collections;

        public IAudioCollection Sound { get; }
        public IAudioCollection Music { get; }

        public AudioService(
            IEngineService engineService,
            ITimeService timeService,
            IContentService contentService,
            IViewService viewService
        )
        {
            _collections = new List<AudioCollection>(2);

            Sound = InitializeUpdateable(new AudioCollection(engineService, timeService, contentService, viewService));
            Music = InitializeUpdateable(new AudioCollection(engineService, timeService, contentService, viewService));
        }

        private AudioCollection InitializeUpdateable(AudioCollection audioCollection)
        {
            _collections.Add(audioCollection);
            return audioCollection;
        }

        public async UniTask InitializeAsync()
        {
            foreach (var audioCollection in _collections)
            {
                await audioCollection.InitializeAsync();
            }
        }

        public async UniTask DisposeAsync()
        {
            foreach (var audioCollection in _collections)
            {
                await audioCollection.DisposeAsync();
            }
        }
    }
}