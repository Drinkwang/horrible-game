using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class dialogview:Vmediator
{   public dialogComponent D;
	public override List<string> msglist {
		get {
			List<string> mlist = new List<string> ();
			mlist.Add (Cmd.dialogAdd);
			mlist.Add(Cmd.dialog);
            mlist.Add(Cmd.dialogClear);
            return mlist;
		}
	}
	public override string name {
		get {
			return "dialogview";
		}
	}
	public override void Todo (Observer o)
	{//Debug.Log ("aaaa");
		switch (o.msg) {
		case Cmd.dialogAdd:
		    List<SingledialogText> packmodelList = (List<SingledialogText>)o.body;
			D.add (packmodelList);
		break;
		case Cmd.dialog:
			D.todo ();
			break;
        case Cmd.dialogClear:
                D.clear();
                break;
		default: ;
			break;

		}
	}
	public dialogview()
	{D = dialogComponent.instance;}


}
