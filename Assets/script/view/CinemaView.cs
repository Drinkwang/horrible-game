using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CinemaView : Vmediator
{
    private CinemacineComponent D; 
    public CinemaView()
    {
        D = CinemacineComponent.Instance();
    }

    public override string name
    {
        get
        {
            return "cinemaView";
        }
    }

    public override List<string> msglist
    {
        get
        {
            List<string> mlist = new List<string>();
            mlist.Add(Cmd.changeCamera);
            mlist.Add(Cmd.moveCamera);
            mlist.Add(Cmd.initCamera);
            return mlist;
        }
    }

    public override void Todo(Observer o){
        switch (o.msg) {
            case Cmd.changeCamera:
                D.changeCamera(o.body);
                break;
            case Cmd.moveCamera:
                D.moveCamera((int)o.body);
                break;
            case Cmd.initCamera:
                D.addAllCamera();
                break;
        }
        
    }
}

