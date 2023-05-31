using System;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.Input.View;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.View
{
    public interface IBattleUiView
    {
        event Action MenuClicked;
        
        IUiInputView InputView { get; }
    }
}