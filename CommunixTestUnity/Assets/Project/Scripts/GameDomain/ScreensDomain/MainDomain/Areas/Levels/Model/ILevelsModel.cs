namespace Project.GameDomain.Areas.Levels.Model
{
    public interface ILevelsModel
    {
        int CurrentLevel { get; set; }
        int TotalLevels { get; set; }
    }
}