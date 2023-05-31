namespace Project.GameDomain.Areas.Levels.Model
{
    public class LevelsModel : ILevelsModel
    {
        public int CurrentLevel { get; set; } = 1;
        public int TotalLevels { get; set; } = 5;
    }
}