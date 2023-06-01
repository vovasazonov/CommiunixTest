using Project.CoreDomain;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Battle.Model;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Battle.Presenter;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.Presenter;
using Zenject;

namespace Project.GameDomain.ScreensDomain.BattleDomain
{
    public class BattleScreenInstaller : Installer<BattleScreenInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<BattleScreen>().AsSingle();
            
            BindEcs();
            BindModels();
            BindPresenters();
        }
        
        private void BindEcs()
        {
            EcsArchitectureInstaller.Install(Container);
            EcsInstaller.Install(Container);
        }

        private void BindPresenters()
        {
            Container.Bind<IPresenter>().To<BattlePresenter>().AsSingle();
            Container.Bind<IPresenter>().To<BattleUiPresenter>().AsSingle();
        }

        private void BindModels()
        {
            Container.BindInterfacesTo<BattleModel>().AsSingle();
        }
    }
}