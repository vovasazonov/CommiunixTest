namespace Project.GameDomain.ScreensDomain.BattleDomain
{
    public static class BattleScreenContentIds
    {
        private static string BattleDomain => "Content/GameDomain/ScreensDomain/BattleDomain";
        
        public static string PlayerPrefab => $"{BattleDomain}/Prefabs/PlayerEntity.prefab";
        public static string EnemyPrefab => $"{BattleDomain}/Prefabs/EnemyEntity.prefab";
    }
}