using Osyacat.Ecs.System;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Jump;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Move;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Player;
using Zenject;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs
{
    public class EcsInstaller : Installer<EcsInstaller>
    {
        public override void InstallBindings()
        {
            Container.Bind<ISystem>().To<PlayerInputSystem>().AsSingle();
            Container.Bind<ISystem>().To<AutoSwitchMoveDirectionSystem>().AsSingle();
            Container.Bind<ISystem>().To<MoveSystem>().AsSingle();
            // Container.Bind<ISystem>().To<InputSystem>().AsSingle();
            // Container.Bind<ISystem>().To<PlayerCreatorSystem>().AsSingle();
            // Container.Bind<ISystem>().To<EnemyCreatorSystem>().AsSingle();
            // Container.Bind<ISystem>().To<ViewSystem>().AsSingle();
            Container.Bind<ISystem>().To<JumpSystem>().AsSingle();
            // Container.Bind<ISystem>().To<GameoverSystem>().AsSingle();
            // Container.Bind<ISystem>().To<PlayerJumpOnlyNearEnemySystem>().AsSingle();
            // Container.Bind<ISystem>().To<PlayerSideChangerSystem>().AsSingle();
            // Container.Bind<ISystem>().To<PlayerAnimationSystem>().AsSingle();
        }
    }
}