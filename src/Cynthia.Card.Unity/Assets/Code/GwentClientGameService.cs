﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Alsein.Utilities;
using UnityEngine;
using Alsein.Utilities.LifetimeAnnotations;
using System.Threading;

namespace Cynthia.Card.Client
{
    [Transient]
    public class GwentClientGameService
    {
        private LocalPlayer _player;
        //--------------------------------
        public GameCodeService GameCodeService { get; set; }
        //--------------------------------

        public async Task Play(LocalPlayer player)
        {
            _player = player;
            while (await ResponseOperation(await _player.ReceiveAsync()));
        }

        //-----------------------------------------------------------------------
        //响应指令
        private async Task<bool> ResponseOperation(Operation<ServerOperationType> operation)
        {
            var arguments = operation.Arguments.ToArray();
            switch (operation.OperationType)
            {
                //-----------------------------------------------------------------------
                case ServerOperationType.GetDragOrPass:
                    await _player.SendAsync(UserOperationType.RoundOperate, await GameCodeService.GetPlayerDrag());
                    break;
                case ServerOperationType.EnemyCardDrag:
                    GameCodeService.EnemyDrag(arguments[0].ToType<RoundInfo>(),arguments[1].ToType<GameCard>());
                    break;
                case ServerOperationType.MyCardEffectEnd:
                    GameCodeService.MyCardEffectEnd();
                    break;
                case ServerOperationType.EnemyCardEffectEnd://卡牌效果落下
                    GameCodeService.EnemyCardEffectEnd();
                    break;
                case ServerOperationType.RoundEnd://回合结束
                    GameCodeService.RoundEnd();
                    break;
                case ServerOperationType.CardsToCemetery:
                    GameCodeService.ShowCardsToCemetery(arguments[0].ToType<GameCardsPart>());
                    break;
                case ServerOperationType.GameEnd://游戏结束,以及游戏结束信息
                    GameCodeService.ShowGameResult(arguments[0].ToType<GameResultInfomation>());
                    return false;
                case ServerOperationType.SetCardTo:
                    GameCodeService.SetCardTo
                    (
                        arguments[0].ToType<RowPosition>(), 
                        arguments[1].ToType<int>(),
                        arguments[2].ToType<RowPosition>(),
                        arguments[3].ToType<int>()
                    );
                    break;
                case ServerOperationType.GetCardFrom:
                    GameCodeService.GetCardFrom
                    (
                        arguments[0].ToType<RowPosition>(),
                        arguments[1].ToType<RowPosition>(),
                        arguments[2].ToType<int>(),
                        arguments[3].ToType<GameCard>()
                    );
                    break;
                //------------------------------------------------------------------------
                case ServerOperationType.SetCoinInfo:
                    GameCodeService.SetCoinInfo(arguments[0].ToType<bool>());
                    break;
                case ServerOperationType.SetMyCemetery:
                    GameCodeService.SetMyCemeteryInfo(arguments[0].ToType<List<GameCard>>());
                    break;
                case ServerOperationType.SetEnemyCemetery:
                    GameCodeService.SetEnemyCemeteryInfo(arguments[0].ToType<List<GameCard>>());
                    break;
                case ServerOperationType.SetAllInfo:
                    GameCodeService.SetAllInfo(arguments[0].ToType<GameInfomation>());
                    break;
                case ServerOperationType.SetCardsInfo:
                    GameCodeService.SetCardsInfo(arguments[0].ToType<GameInfomation>());
                    break;
                case ServerOperationType.SetGameInfo:
                    GameCodeService.SetGameInfo(arguments[0].ToType<GameInfomation>());
                    break;
                case ServerOperationType.SetNameInfo:
                    GameCodeService.SetNameInfo(arguments[0].ToType<GameInfomation>());
                    break;
                case ServerOperationType.SetCountInfo:
                    GameCodeService.SetCountInfo(arguments[0].ToType<GameInfomation>());
                    break;
                case ServerOperationType.SetPointInfo:
                    GameCodeService.SetPointInfo(arguments[0].ToType<GameInfomation>());
                    break;
                case ServerOperationType.SetPassInfo:
                    GameCodeService.SetPassInfo(arguments[0].ToType<GameInfomation>());
                    break;
                case ServerOperationType.SetWinCountInfo:
                    GameCodeService.SetWinCountInfo(arguments[0].ToType<GameInfomation>());
                    break;
            }
            return true;
        }
    }
}