using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 static class Cmd
{
    public const string changeCamera = "changeCamera";
    public const string initCamera = "initCamera";
    public const string moveCamera = "moveCamera";
    public const string addCamera = "addCamera";

    //task
    public const string addTask = "addtask";
    public const string renderTask = "rtask";
    //显示游戏内纸质文档
    public const string changeM = "changeM";


    //tv
    public  const string changeTv = "changeTv";
    public  const string playTv = "playTv";
    public const string initTv = "initTv";
    public const string stopTv = "stopTv";


    //ichosen点击物品弹出菜单

    public const string iChosenAdd = "add";
    public const string iChosenRender = "render";
    public const string iChosenHide = "hide";


    //item
    public const string showItem = "showitem";
    public const string hideItem = "hideitem";
    public const string consumeItem = "consumeItem";

    //myinventory--Item
    public const string addItem = "AddGoodscommand";
    public const string renderAllItem = "RendertoViewcommand";
    public const string exchangeMySelfItem = "exchange";
    public const string sortAllItem = "sortAllItem";


    //diaglog
   
    public const string dialogAdd = "dialogadd";
    public const string dialog = "dialog";
    public const string dialogReplace = "dialogReplace";
    public const string dialogRemove = "dialogRemove";
    public const string dialogMerge = "dialogMerge";
    public const string dialogClear = "dialogclear";
    public const string dialogChangeFontSize = "dialogChangeFontSize";

    //saveSystem
    public const string saveGame = "saveGame";
    public const string loadGame = "loadGame";

    //postEffect
    public const string postEffectOperate = "postEffectOperate";
    public const string initPostEffectOperate = "initPostEffectOperate";
    public const string initPostEffectModel = "initPostEffectModel";
    public const string shaderPostEffectOperate = "shaderPostEffectOperate";


    //changeButton
    public const string QuetionChangeButton = "QutionChangeButton";
    public const string QuetionChangeTitle = "QuetionChangeTitle";
    public const string QuetionShow = "QuetionShow";
    public const string QuetionChangeA = "QuetionChangeA";
    public const string QuetionCHnngeB = "QuetionChangeB";

    //cabinetManager

    public const string CabineMove = "CabineMove";
    public const string CabineShake = "CabineShake";


    //后续有可能的话，操作view和操作ctrl也进行分层
}

