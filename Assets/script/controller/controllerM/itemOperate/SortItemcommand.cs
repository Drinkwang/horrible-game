using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SortItemcommand : IC {
	Goodproxy goodproxy=Goodproxy.instances();
	PackProxy packproxy=PackProxy.instances();

	// Use this for initialization

	public void Todo(Observer a)
	{
		List<Packagemodel>packmodellist=packproxy.getmodellist ();
		for(int i=0;i<packmodellist.Count;i++)
		{
			if(packmodellist[i].goodid!=0)
			{//Debug .Log("a");
				packmodellist[i].good=goodproxy.GetmodelbyId(packmodellist[i].goodid);
			}
			
		}

		packmodellist.Sort((a1, b1) => {
			var o = a1.id - b1.id;
			if (a1.goodid == 0)
				return 1;
				if (b1.goodid == 0)
				return -1;
			return -o;
		});
		AppFactory.instances.viewTodo (new Observer ("show", packmodellist,null));

	}
}
