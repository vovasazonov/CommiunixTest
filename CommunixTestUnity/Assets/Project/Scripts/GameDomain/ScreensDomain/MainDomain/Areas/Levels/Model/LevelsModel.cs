namespace Project.GameDomain.Areas.Levels.Model
{
    public class LevelsModel : ILevelsModel
    {
        private int _currentLevel = 1;

        public int CurrentLevel
        {
            get => _currentLevel;
            set
            {
                _currentLevel = value;

                if (_currentLevel > TotalLevels || _currentLevel < 1)
                {
                    _currentLevel = 1;
                }
            }
        }

        public int TotalLevels { get; set; } = 3;
    }
}