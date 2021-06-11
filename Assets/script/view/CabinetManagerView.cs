using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class CabinetManagerView : Vmediator
{
    public override string name
    {

        get
        {
            return "cabinetManagerView";
        }
    }

    public override List<string> msglist {
        get
        {
            List<string> mlist = new List<string>();
            mlist.Add(Cmd.CabineMove);
            mlist.Add(Cmd.CabineShake);

            return mlist;
        }

    }

    public override void Todo(Observer o)
    {
        if (o.msg == Cmd.CabineMove)
        {
            CabinetManagerComponent.instance.move(o.body);

        }
        else if (o.msg == Cmd.CabineShake) {
            CabinetManagerComponent.instance.shake(o.body);
        }
    }
    public override void refresh() { 
    }
}

