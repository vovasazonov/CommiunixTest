namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ui.Input.View
{
    public interface IUiInputView
    {
        bool IsPlayer1Active { set; }
        bool IsPlayer2Active { set; }
        
        bool IsLeftPlayer1 { get; }
        bool IsRightPlayer1 { get; }
        bool IsFirePlayer1 { get; }
                
        bool IsLeftPlayer2 { get; }
        bool IsRightPlayer2 { get; }
        bool IsFirePlayer2 { get; }
    }
}