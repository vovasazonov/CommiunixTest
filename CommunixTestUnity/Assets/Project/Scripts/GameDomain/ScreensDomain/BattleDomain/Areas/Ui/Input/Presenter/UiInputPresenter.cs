using Cysharp.Threading.Tasks;
using Project.CoreDomain;
using Project.CoreDomain.Services.Engine;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.Input.View;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Multiplayer.Model;
using Project.Scripts.GameDomain.ScreensDomain.MainDomain.Areas.Input.Model;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.Input.Presenter
{
    public class UiInputPresenter : IPresenter
    {
        private readonly IEngineService _engineService;
        private readonly IMultiplayerModel _multiplayerModel;
        private readonly IUiInputView _view;
        private readonly IInputModel _inputModel;

        public UiInputPresenter(
            IEngineService engineService,
            IMultiplayerModel multiplayerModel,
            IUiInputView view,
            IInputModel inputModel
        )
        {
            _engineService = engineService;
            _multiplayerModel = multiplayerModel;
            _view = view;
            _inputModel = inputModel;
        }

        public UniTask InitializeAsync()
        {
            if (Application.platform != RuntimePlatform.Android)
            {
                _view.IsPlayer1Active = false;
                _view.IsPlayer2Active = false;
            }
            else
            {
                _engineService.Updating += OnUpdating;

                _view.IsPlayer1Active = true;
                _view.IsPlayer2Active = _multiplayerModel.IsMultiplayer;
            }


            return UniTask.CompletedTask;
        }

        public UniTask DisposeAsync()
        {
            if (Application.platform == RuntimePlatform.Android)
            {
                _engineService.Updating -= OnUpdating;
            }

            return UniTask.CompletedTask;
        }

        private void OnUpdating()
        {
            _inputModel.Player1.IsFire = _view.IsFirePlayer1;
            _inputModel.Player1.IsLeft = _view.IsLeftPlayer1;
            _inputModel.Player1.IsRight = _view.IsRightPlayer1;

            _inputModel.Player2.IsFire = _view.IsFirePlayer2;
            _inputModel.Player2.IsLeft = _view.IsLeftPlayer2;
            _inputModel.Player2.IsRight = _view.IsRightPlayer2;
        }
    }
}