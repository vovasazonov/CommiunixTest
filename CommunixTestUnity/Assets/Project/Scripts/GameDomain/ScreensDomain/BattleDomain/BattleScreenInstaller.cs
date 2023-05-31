using Project.CoreDomain;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Battle.Presenter;
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
            Container.Bind<IPresenter>().To<BattlePresenter>().AsSingle();
        }

        private void BindModels()
        {

        }
    }
}