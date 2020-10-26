using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Determinepossession : IC {
//	Goodproxy goodproxy=Goodproxy.instances();
	PackProxy packproxy=PackProxy.instances();

	// Use this for initialization

	public void Todo(Observer a)
	{
        int id = 1;
        Packagemodel model = null;
        if (a.msg == "use")
        {
            if (packproxy.TryGeGoodtModel(id, out model))
            {
                --model.count;
                packproxy.update(id, model);
            }
        }
      /*  if (a.msg == "use")
        {
            if (packproxy.TryGeGoodtModel(id, out model))
            {
                --model.count;
                packproxy.update(id, model);
            }
        }
        */

    }
}
