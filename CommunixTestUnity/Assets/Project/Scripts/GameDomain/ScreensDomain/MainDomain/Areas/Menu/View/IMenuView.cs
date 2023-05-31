using System;
using Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.Levels.View;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.View
{
    public interface IMenuView
    {
        event Action PlayClicked;
        event Action<bool> MultiplayerChanged;
        
        ILevelsView Levels { get; }
    }
}