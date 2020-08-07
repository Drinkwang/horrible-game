using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemselectView : Vmediator {
    public override string name
    {
        get
        {
            return "selectView";
        }
    }

    public override List<string> msglist
    {
        get
        {
            List<string> mlist = new List<string>();
            mlist.Add(Cmd.showItem);
            mlist.Add(Cmd.hideItem);
            return mlist;
        }
    }

    public override void Todo(Observer o)
    {
        switch ((string)o.msg)
        {
            case Cmd.showItem: Itemselect.instance.show((List<itemchosenmodel>)o.body);
                break;
            case Cmd.hideItem:Itemselect.instance.hide();
         //       Debug.Log("wodebu")
                ;
                break;
        }

    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
