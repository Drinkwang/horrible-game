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
        bloom_TimeLine = 1,
        bloom_bloomPlayDetail = 2,
        bloom_bloomEnd = 3,
        bloom_discardCard = 4
        //IGG_MobileRoyale,
    }
    public ReplaceDiagType type = 0;

 
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
    public void event1(int changeId) {
        //0是j，1是q，2是k
        dialogReplaceSystem.instance.ReplaceJqk(changeId,this.sai);

    }

    public void event2() {

    }


    public void event3() {

        
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
            event1(changeId);
 
        Reset();

    }


}
