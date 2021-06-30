using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendertoViewcommand : IC {
	Goodproxy goodproxy=Goodproxy.instances();
	PackProxy packproxy=PackProxy.instances();

	// Use this for initialization

	public void Todo(Observer a)
	{

		if ((string)a.msg == Cmd.renderAllItem)
		{
			List<Packagemodel> packmodellist = packproxy.getmodellist();
			for (int i = 0; i < packmodellist.Count; i++)
			{
				if (packmodellist[i].goodid != 0)
				{//Debug .Log("a");
					packmodellist[i].good = goodproxy.GetmodelbyId(packmodellist[i].goodid);
				}

			}
			if ((string)a.body == "else")
			{
				packproxy.modellist = solve(packmodellist);
			}


			string tempMsg = (string)a.data;


			AppFactory.instances.viewTodo(new Observer("show", packmodellist, tempMsg));
		}
	}

	public static List<Packagemodel> solve(List<Packagemodel> arr)
	{
		int len = arr.Count;
		List<Packagemodel> arr2 = new List<Packagemodel>();
		List<Packagemodel> arr3= new List<Packagemodel>();
	//	int j = 0, count = 0;
		for (int i = 0; i < len; i++)
		{
			if (arr[i].goodid != 0)
			{
				arr2.Add(arr[i]);
			}
			else
			{
				arr3.Add(arr[i]);
			}
		}
		arr2.AddRange(arr3);

		return arr2;
	}
}
