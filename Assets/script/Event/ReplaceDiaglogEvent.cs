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
        ReplaceDiaglog_win = 1,
        ReplaceDiaglog_lose = 2,

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

    public void changeLost(int changeId) {

    }


    public void changeWin(int changeId) {

        
    }
    public void event4()
    {


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
        else if(type == ReplaceDiagType.ReplaceDiaglog_win)
            changeWin(changeId);
        else if(type ==ReplaceDiagType.ReplaceDiaglog_lose)
            changeLost(changeId);
        Reset();

    }


}
