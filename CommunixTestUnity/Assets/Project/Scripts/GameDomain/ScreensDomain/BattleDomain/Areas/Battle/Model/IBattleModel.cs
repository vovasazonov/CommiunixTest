using System;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Battle.Model
{
    public interface IBattleModel
    {
        event Action Finished;
        
        bool IsGameOver { get; set; }

        void Finish();
    }
}