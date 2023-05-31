using System;
using Osyacat.Ecs.System;
using Osyacat.Ecs.World;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Direction;
using Project.Scripts.GameDomain.ScreensDomain.MainDomain.Areas.Menu.Input.Model;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Player
{
    public class PlayerInputSystem : IUpdateSystem
    {
        private readonly IInputModel _inputModel;
        private readonly IFilter _playerFilter;

        public PlayerInputSystem(IWorld world, IInputModel inputModel)
        {
            _inputModel = inputModel;
            _playerFilter = world.GetFilter(i => i.Has<PlayerComponent>().Has<DirectionComponent>());
        }

        public void Update()
        {
            foreach (var player in _playerFilter)
            {
                var playerInput = player.Get<PlayerComponent>().Id == 1 ? _inputModel.Player1 : _inputModel.Player2;
            }
        }
    }
}