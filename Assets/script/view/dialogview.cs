using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class dialogview : Vmediator
{
    public dialogComponent D;
    public override List<string> msglist
    {
        get
        {
            List<string> mlist = new List<string>();
            mlist.Add (Cmd.dialogAdd);
            mlist.Add(Cmd.dialog);
            mlist.Add(Cmd.dialogClear);
            mlist.Add(Cmd.dialogReplace);
            mlist.Add(Cmd.dialogRemove);
            return mlist;
        }
    }
    public override string name
    {
        get
        {
            return "dialogview";
        }
    }
    public override void Todo(Observer o)
    {//Debug.Log ("aaaa");
        switch (o.msg)
        {
            case Cmd.dialogAdd:
                D.add();
                break;
            case Cmd.dialog:
                D.todo(null);
                break;
            case Cmd.dialogClear:
                D.clear();
                break;
            case Cmd.dialogReplace:
                if (o.body is SingledialogText)
                {
                    SingledialogText reST1 = (SingledialogText)o.body;
                    ReplaceNextDiaglogData.SessionAddIndex tempSession = (ReplaceNextDiaglogData.SessionAddIndex)o.data;
                    D.Replace(reST1, tempSession.tempSession, tempSession.index);
            
                }
                else
                {
                    List<SingledialogText> reST = (List<SingledialogText>)o.body;
                    D.ReplaceAll(reST);
                }
                break;
            case Cmd.dialogRemove:


                ReplaceNextDiaglogData.SessionAddIndex temp = (ReplaceNextDiaglogData.SessionAddIndex)o.body;
                int index = (int)temp.index;
                int count = (int)(o.data);
                List<SingledialogText> mySingleD=temp.tempSession.MySingleD.ToList();
                mySingleD.RemoveRange(index+1, count);
                temp.tempSession.MySingleD=mySingleD.ToArray();
     

                break;
            default:
                ;
                break;

        }
    }
    public dialogview()
    { D = dialogComponent.instance; }


}
