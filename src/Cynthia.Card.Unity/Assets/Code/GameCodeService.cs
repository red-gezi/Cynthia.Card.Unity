﻿using System;
using System.Threading.Tasks;
using Alsein.Utilities.LifetimeAnnotations;
using Autofac;
using Microsoft.AspNetCore.SignalR.Client;
using UnityEngine;
using UnityEngine.Audio;
using Alsein.Utilities;
using System.Collections.Generic;
using System.Threading;

namespace Cynthia.Card.Client
{
    [Transient]
    public class GameCodeService
    {
        private GameObject _code;
        public GameCodeService()
        {
            _code = GameObject.Find("Code");
        }
        //-------------------------------------------------------------------------------------------
        public void SelectCard(int index)
        {
            _code.GetComponent<GameCode>().GameCardShowControl.SelectCard(index);
        }
        public void ClickCard(int index)
        {
            _code.GetComponent<GameCode>().GameCardShowControl.ClickCard(index);
        }
        //--------------------
        public void BigRoundShowPoint(BigRoundInfomation data)
        {
            _code.GetComponent<GameCode>().BigRoundControl.ShowPoint(data);
        }
        public void BigRoundSetMessage(string message)
        {
            _code.GetComponent<GameCode>().BigRoundControl.SetMessage(message);
        }
        public void BigRoundShowClose()
        {
            _code.GetComponent<GameCode>().BigRoundControl.CloseBigRound();
        }
        //--------------------
        public void MulliganStart(IList<CardStatus> cards, int total)//调度界面
        {
            _code.GetComponent<GameCode>().GameCardShowControl.MulliganStart(cards, total);
        }
        //调度结束
        public void MulliganEnd()
        {
            _code.GetComponent<GameCode>().GameCardShowControl.MulliganEnd();
        }
        //更新信息(需要更改),动画之类的
        public void MulliganData(int index, CardStatus card)
        {
            _code.GetComponent<GameCode>().GameCardShowControl.MulliganData(index, card);
        }
        //获取调度信息
        public void GetMulliganInfo(LocalPlayer player)
        {
            _code.GetComponent<GameCode>().GameCardShowControl.GetMulliganInfo(player);
        }
        //----------------------------------
        //回合开始动画
        public void RoundStartShow()
        {
            _code.GetComponent<GameCode>().MyRoundShow.Play("RoundShow");
        }
        //-------------------------------------------------------------------------------------------
        //更新数据的方法们
        public void SetMulliganInfo(GameInfomation gameInfomation)
        {
            _code.GetComponent<GameCode>().GameUIControl.SetMulliganInfo(gameInfomation);
        }
        public void SetAllInfo(GameInfomation gameInfomation)//更新全部数据
        {
            _code.GetComponent<GameCode>().GameUIControl.SetGameInfo(gameInfomation);
            _code.GetComponent<GameCode>().GameCardsControl.SetCardsInfo(gameInfomation);
        }
        public void SetMyCemeteryInfo(IList<CardStatus> myCemetery)
        {
            _code.GetComponent<GameCode>().GameCardShowControl.MyCemetery = myCemetery;
        }
        public void SetEnemyCemeteryInfo(IList<CardStatus> enemyCemetery)
        {
            _code.GetComponent<GameCode>().GameCardShowControl.EnemyCemetery = enemyCemetery;
        }
        //--
        public void SetGameInfo(GameInfomation gameInfomation)//更新数值+胜场数据
        {
            _code.GetComponent<GameCode>().GameUIControl.SetGameInfo(gameInfomation);
        }
        public void SetCardsInfo(GameInfomation gameInfomation)//更新卡牌类型数据
        {
            _code.GetComponent<GameCode>().GameCardsControl.SetCardsInfo(gameInfomation);
        }
        //
        public void SetCoinInfo(bool isBlueCoin)
        {
            _code.GetComponent<GameCode>().GameEvent.SetCoinInfo(isBlueCoin);
        }
        public void SetPointInfo(GameInfomation gameInfomation)
        {
            _code.GetComponent<GameCode>().GameUIControl.SetPointInfo(gameInfomation);
        }
        public void SetCountInfo(GameInfomation gameInfomation)
        {
            _code.GetComponent<GameCode>().GameUIControl.SetCountInfo(gameInfomation);
        }
        public void SetPassInfo(GameInfomation gameInfomation)
        {
            _code.GetComponent<GameCode>().GameUIControl.SetPassInfo(gameInfomation);
        }
        public void SetWinCountInfo(GameInfomation gameInfomation)
        {
            _code.GetComponent<GameCode>().GameUIControl.SetWinCountInfo(gameInfomation);
        }
        public void SetNameInfo(GameInfomation gameInfomation)
        {
            _code.GetComponent<GameCode>().GameUIControl.SetNameInfo(gameInfomation);
        }
        //-------------------------------------------------------------------------------------------
        public void LeaveGame()//立刻离开游戏,进入主菜单
        {
            _code.GetComponent<GameCode>().LeaveGame();
        }
        public void ShowCardsToCemetery(GameCardsPart cards)
        {
            _code.GetComponent<GameCode>().GameEvent.ShowCardsToCemetery(cards);
        }
        public void ShowGameResult(GameResultInfomation gameResult)//设定并展示游戏结束画面
        {
            _code.GetComponent<GameCode>().GameResultControl.ShowGameResult(gameResult);
        }
        public Task<RoundInfo> GetPlayerDrag()//玩家的回合到了
        {
            return _code.GetComponent<GameCode>().GameEvent.GetPlayerDrag();
        }
        public void MyCardEffectEnd()//结束卡牌效果
        {
            _code.GetComponent<GameCode>().GameEvent.MyCardEffectEnd();
        }
        public void RoundEnd()
        {
            _code.GetComponent<GameCode>().GameEvent.RoundEnd();
        }
        public void EnemyDrag(RoundInfo enemyRoundInfo,CardStatus cardInfo)
        {
            _code.GetComponent<GameCode>().GameEvent.EnemyDrag(enemyRoundInfo,cardInfo);
        }
        public void EnemyCardEffectEnd()//结束卡牌效果
        {
            _code.GetComponent<GameCode>().GameEvent.EnemyCardEffectEnd();
        }
        public void SetCardTo(RowPosition rowIndex,int cardIndex,RowPosition tagetRowIndex,int tagetCardIndex)
        {
            _code.GetComponent<GameCode>().GameEvent.SetCardTo(rowIndex, cardIndex, tagetRowIndex, tagetCardIndex);
        }
        public void GetCardFrom(RowPosition getPosition,RowPosition tagetPosition,int tagetCardIndex,CardStatus cardInfo)
        {
            _code.GetComponent<GameCode>().GameEvent.GetCardFrom(getPosition, tagetPosition, tagetCardIndex, cardInfo);
        }
        //-------------------------------------------------
        public Transform GetGameScale()
        {
            return _code.GetComponent<GameCode>().GameScale;
        }
    }
}