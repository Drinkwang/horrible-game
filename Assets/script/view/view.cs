using System.Collections.Generic;
using UnityEngine;

public class view {
	public Dictionary<string,Vmediator> named;
	public Dictionary<string,Vmediator> msg;
	// Use this for initialization

	public view()
	{named = new Dictionary<string,Vmediator> ();
		msg = new Dictionary<string,Vmediator> ();
	}
	public void AdjustView (Vmediator v)
	{
		if (named.ContainsKey (v.name))
		{Debug.Log("該key已經有了");
        }
    	else {
		foreach(var i in v.msglist)
		{msg.Add (i,v);}
	    }
	}
	public void viewTodo (Observer i)
	{
		if(msg.ContainsKey(i.msg))
		{
			Vmediator a=msg[i.msg];
			Debug.Log (a);
			a.Todo(i);
			}
	}


}
