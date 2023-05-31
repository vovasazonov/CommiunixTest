using Project.CoreDomain;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.View;
using Zenject;

namespace Project.GameDomain.ScreensDomain.MainDomain
{
    public class MainScreenInstaller : Installer<MainScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<MainScreen>().AsSingle();
            
            BindModels();
            BindPresenters();
        }

        private void BindPresenters()
        {
            Container.Bind<IPresenter>().To<MenuPresenter>().AsSingle();
        }

        private void BindModels()
        {

        }
    }
}