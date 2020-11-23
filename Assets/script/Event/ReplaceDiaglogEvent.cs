using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;


public class ReplaceDiaglogEvent : Befunction
{

    
    public enum ReplaceDiagType
    {
        ReplaceDiaglog_jqk = 0,
        ReplaceDiaglog_winOrLost = 1,

        ReplaceAudio_Merge=2


        //IGG_MobileRoyale,
    }
    public ReplaceDiagType type = 0;
    private BloomData bloomData;

 
    public ReplaceDiaglogEvent(string temp) : base(temp)
    {
    }

    public void Awake()
    {

        Reset();
        
    }

    public void Reset()
    {
        base._A = Myfunction;
        base.A = function;
    }
    public void changeJqk(int changeId) {
        if(bloomData==null)
            bloomData = BloomModel.instance().bloomData;
        //0是j，1是q，2是k
        var beChangePoint=bloomData.MyTablecards[changeId].Point;
        int index = CUtil.cardPointToId(beChangePoint);
        dialogReplaceSystem.instance.ReplaceJqk(index, this.sai);

    }


    public void changeWinOrLost(int changeId){

        if(bloomData==null)
            bloomData = BloomModel.instance().bloomData;
        var myCardPoint=bloomData.MyTablecards[changeId].Point;
        var enemyCardPoint=bloomData.enemyTablecards[changeId].Point;
        int bewinCard=CUtil.getBeWinCard(myCardPoint,true);
        int beLostCard=CUtil.getBeWinCard(myCardPoint,false);
        
        if(bewinCard==enemyCardPoint){
            //你赢了
            Win();
            bloomData.MyScore++;
        }else if(beLostCard==enemyCardPoint){
            //你输了
            Lost();
            bloomData.EnemyScore++;
        }else if(myCardPoint==enemyCardPoint){
            Draw();
        }else{
            Debug.LogError("不可能出现输、赢、平之外的第四种情况，请检查源代码");
        }
    }

    public void changeAudioMerge(int changeId){

        dialogReplaceSystem.instance.ReplaceAudioMerge(this.sai);
    }

    public void Lost() {
        dialogReplaceSystem.instance.ReplaceLose(this.sai);
    }


    public void Win() {

        dialogReplaceSystem.instance.ReplaceWin(this.sai);
    }

    public void Draw(){

        dialogReplaceSystem.instance.ReplaceDraw(this.sai);
    }
    public void function() {
        Myfunction();
    }

    // Start is called before the first frame update
    public void Myfunction(int a = 0, List<int> b = null)
    {
        Debug.Log("runa");
        type = (ReplaceDiagType)a;
        int changeId;

        if (b != null && b.Count > 0)
            changeId = b[0];
        else
            changeId = 0;



        if (type == ReplaceDiagType.ReplaceDiaglog_jqk)
            changeJqk(changeId);
        else if(type == ReplaceDiagType.ReplaceDiaglog_winOrLost)
            changeWinOrLost(changeId);
        else if(type==ReplaceDiagType.ReplaceAudio_Merge){
            changeAudioMerge(changeId);
        }
        Reset();

    }


}
