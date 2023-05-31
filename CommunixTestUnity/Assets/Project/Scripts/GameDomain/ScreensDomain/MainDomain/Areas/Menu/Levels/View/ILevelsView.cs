using System;

namespace Project.GameDomain.ScreensDomain.MainDomain.Areas.Menu.Levels.View
{
    public interface ILevelsView
    {
        event Action<int> LevelClicked;

        void Initialize(int levels);
    }
}