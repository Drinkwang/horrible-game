using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scribeview : Vmediator {
    public override string name
    {
        get
        {
            return "sribeview";
            
        }
    }

    public override List<string> msglist
    {
        get
        {
            List<string> mlist = new List<string>();
            mlist.Add("changeM");
            return mlist;
        }
    }
    public override void Todo(Observer o)
    {
        switch (o.msg)
        {
            case "changeM":
              
                scribeComponent.instance.changeM((string[])o.body);

                break;
                }
    }

 
}
