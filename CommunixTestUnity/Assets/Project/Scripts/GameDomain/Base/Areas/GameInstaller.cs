using Project.GameDomain.Areas.Levels.Model;
using Zenject;

namespace Project.GameDomain.Areas
{
    public class GameInstaller : Installer<GameInstaller>
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<LevelsModel>().AsSingle();
        }
    }
}