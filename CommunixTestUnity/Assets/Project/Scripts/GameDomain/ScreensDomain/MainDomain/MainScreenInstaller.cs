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

        }

        private void BindModels()
        {

        }
    }
}