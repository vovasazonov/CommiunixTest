using Project.CoreDomain.Services.Content;
using Project.CoreDomain.Services.Di;
using Project.CoreDomain.Services.Engine;
using Project.CoreDomain.Services.Screen;
using Project.CoreDomain.Services.View;
using Zenject;

namespace Project.CoreDomain.Services
{
    public class ServicesInstaller : Installer<ServicesInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ContentService>().AsSingle();
            Container.BindInterfacesTo<ScreensService>().AsSingle();
            Container.BindInterfacesTo<EngineService>().AsSingle();
            Container.BindInterfacesTo<DiService>().AsSingle();
            Container.BindInterfacesTo<ViewService>().AsSingle();
        }
    }
}