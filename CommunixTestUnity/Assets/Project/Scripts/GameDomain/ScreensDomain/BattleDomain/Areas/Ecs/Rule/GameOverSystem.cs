﻿using Osyacat.Ecs.System;
using Osyacat.Ecs.World;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Battle.Model;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Enemy;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Player;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Position;
using Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Proportion;
using UnityEngine;

namespace Project.GameDomain.ScreensDomain.BattleDomain.Areas.Ecs.Rule
{
    public class GameOverSystem : IUpdateSystem
    {
        private readonly IBattleModel _battleModel;
        private readonly IFilter _playerFilter;
        private readonly IFilter _enemyFilter;

        public GameOverSystem(IWorld world, IBattleModel battleModel)
        {
            _battleModel = battleModel;
            _playerFilter = world.GetFilter(matcher => matcher.Has<PlayerComponent>());
            _enemyFilter = world.GetFilter(matcher => matcher.Has<PositionComponent>().Has<ProportionComponent>().Has<EnemyComponent>());
        }

        public void Update()
        {
            if (!_battleModel.IsGameOver)
            {
                foreach (var enemy in _enemyFilter)
                {
                    foreach (var player in _playerFilter)
                    {
                        var playerProportion = player.Get<ProportionComponent>();
                        var playerPosition = player.Get<PositionComponent>().Value;

                        var enemyPosition = enemy.Get<PositionComponent>().Value;
                        var enemyProportion = enemy.Get<ProportionComponent>();

                        var isOnX = Vector3.Distance(enemyPosition, new Vector3(playerPosition.x + playerProportion.Width / 2, playerPosition.y)) < enemyProportion.Width / 2 ||
                                    Vector3.Distance(enemyPosition, new Vector3(playerPosition.x - playerProportion.Width / 2, playerPosition.y)) < enemyProportion.Width / 2;
                        var isOnY = Vector3.Distance(enemyPosition, new Vector3(playerPosition.x, playerPosition.y + playerProportion.Height / 2)) < enemyProportion.Height / 2 ||
                                    Vector3.Distance(enemyPosition, new Vector3(playerPosition.x, playerPosition.y - playerProportion.Height / 2)) < enemyProportion.Height / 2;

                        var isEnemyTrigger = isOnX && isOnY;

                        if (isEnemyTrigger)
                        {
                            _battleModel.IsGameOver = true;
                            _battleModel.Finish();
                        }
                    }
                }
            }
        }
    }
}