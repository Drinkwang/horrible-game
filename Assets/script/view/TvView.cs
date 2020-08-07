using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class TvView : Vmediator
{
    private TvComponent D; 
    public TvView()
    {
        D = TvComponent.Instance();
    }

    public override string name
    {
        get
        {
            return "tvView" ;
        }
    }

    public override List<string> msglist
    {
        get
        {
            List<string> mlist = new List<string>();
            mlist.Add(Cmd.changeTv);
            mlist.Add(Cmd.playTv);
            mlist.Add(Cmd.initTv);
            return mlist;
        }
    }

    public override void Todo(Observer o){
        switch (o.msg) {
            case Cmd.changeTv:
                D.changeTv(o.body);
                break;
            case Cmd.playTv:
                D.playTv(true);
                break;
            case Cmd.stopTv:
                D.playTv(false);
                break;

              
        }
        
    }
}

