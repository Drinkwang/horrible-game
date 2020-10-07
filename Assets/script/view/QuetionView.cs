using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class QuetionView : Vmediator
{
    public QuetionComponent Q = QuetionComponent.instance();
    public override string name
    {
        get
        {
            return "QuetionView";
        }
    }

    public override List<string> msglist {
        get
        {
            List<string> mlist = new List<string>();
            mlist.Add(Cmd.QuetionChangeButton);
            mlist.Add(Cmd.QuetionChangeTitle);
            mlist.Add(Cmd.QuetionShow);
            mlist.Add(Cmd.QuetionChangeA);
            mlist.Add(Cmd.QuetionCHnngeB);
            return mlist;
        }

    }
    //=> throw new NotImplementedException();

    public override void Todo(Observer o)
    {
        switch (o.msg)
        {
            case Cmd.QuetionChangeButton:
                Q.changeButtonStyle(o);
                break;
            case Cmd.QuetionChangeTitle:
                Q.ChangeQuetion((string)(o.body));
                break;
            case Cmd.QuetionShow:
                Q.show(o);
                break;
            case Cmd.QuetionChangeA:
                Q.ChangeYesBefunction((Action)o.body);
                break;
            case Cmd.QuetionCHnngeB:
                Q.ChangeNoBefunction((Action)o.body);
                break;
        }
    }
}

