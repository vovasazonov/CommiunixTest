using Project.GameDomain.Areas.Levels.Model;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Multiplayer.Model;
using Project.Scripts.GameDomain.ScreensDomain.MainDomain.Areas.Input.Model;
using Zenject;

namespace Project.GameDomain.Areas
{
    public class GameInstaller : Installer<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelsModel>().AsSingle();
            Container.BindInterfacesTo<MultiplayerModel>().AsSingle();
            Container.BindInterfacesTo<InputModel>().AsSingle();
        }
    }
}