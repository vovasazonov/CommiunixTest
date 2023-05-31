using Zenject;

namespace Project.GameDomain.ScreensDomain.BattleDomain
{
    public class BattleScreenInstaller : Installer<BattleScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<BattleScreen>().AsSingle();
            
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