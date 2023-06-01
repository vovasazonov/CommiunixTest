using System;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Battle.Model
{
    public class BattleModel : IBattleModel
    {
        public event Action Finished;
        
        public bool IsGameOver { get; set; }
        
        public void Finish()
        {
            Finished?.Invoke();
        }
    }
}