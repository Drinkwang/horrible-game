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

        ReplaceAudio_Merge_Score=2,
        ReplaceAudio_Break_Final=3


        //IGG_MobileRoyale,
    }
    public ReplaceDiagType type = 0;
 //   private BloomData bloomData;

 
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
        //if(bloomData==null)
        //    bloomData = BloomModel.instance().bloomData;
        ////0是j，1是q，2是k
        var beChangePoint=BloomModel.instance().myback[changeId].GetComponent<CardBase>().data.Point;
        int index = CUtil.cardPointToId(beChangePoint);
        dialogReplaceSystem.instance.ReplaceJqk(index, this.sai);

    }


    public void changeWinOrLost(int changeId,bool isReplaceD){


        var mycardpoint = BloomModel.instance().myback[changeId].GetComponent<CardBase>().data.Point;
        var enemycardpoint = BloomModel.instance().cardback[changeId].GetComponent<CardBase>().data.Point;
        int bewincard = CUtil.getBeWinCard(mycardpoint, true);
        int belostcard = CUtil.getBeWinCard(mycardpoint, false);

        if (bewincard == enemycardpoint)
        {

            //你输了
            if (isReplaceD==true)
                Lost();

            BloomModel.instance().enenmyScore++;

        }
        else if (belostcard == enemycardpoint)
        {
            //你赢了
            if (isReplaceD == true)
                Win();
            BloomModel.instance().myScore++;
        }
        else if (mycardpoint == enemycardpoint)
        {
            if (isReplaceD == true)
                Draw();
        }
        else
        {
            Debug.LogError("不可能出现输、赢、平之外的第四种情况，请检查源代码");
        }
    }

    public void changeAudioMerge(int changeId,List<int> point){

        dialogReplaceSystem.instance.ReplaceAudioMerge(this.sai,point);
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
        type = (ReplaceDiagType)a;
        int changeId;

        if (b != null && b.Count > 0)
            changeId = b[0];
        else
            changeId = 0;



        if (type == ReplaceDiagType.ReplaceDiaglog_jqk)
            changeJqk(changeId);
        else if (type == ReplaceDiagType.ReplaceDiaglog_winOrLost)
        {
            if (b.Count < 2 || b[1] == 0)
                changeWinOrLost(changeId, true);
            else
            {
                changeWinOrLost(changeId, false);
            }

        }
        else if (type == ReplaceDiagType.ReplaceAudio_Merge_Score)
        {
            b = new List<int>();
            b.Add(BloomModel.instance().myScore);
            b.Add(3);
            b.Add(BloomModel.instance().enenmyScore);
            changeAudioMerge(changeId, b);
        }
        else if (type == ReplaceDiagType.ReplaceAudio_Break_Final) {
            if(BloomModel.instance().enenmyScore==2|| BloomModel.instance().myScore==2)
                breakFinal(changeId,true);
            else if(BloomModel.instance().enenmyScore == 0 && BloomModel.instance().myScore == 0){
                breakFinal(changeId, false);
            }

        }
        Reset();

    }


    public void breakFinal(int changeId,bool isWin)
    {
        dialogReplaceSystem.instance.ReplaceNextDiaglog(this.sai,changeId,isWin);
    }



}
