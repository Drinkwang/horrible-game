using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddGoodscommand : IC {
	PackProxy packproxy=PackProxy.instances();
//	Goodproxy goodproxy=Goodproxy.instances();

	// Use this for initialization
	public void Todo(Observer io)
	{
		if (packproxy.modellist.Count <= 0) {
			packproxy.crateInventory(10);
		}
		int id = 1;
		Packagemodel model = null;
		if (!int.TryParse (io.body.ToString (), out id)) {
			return;}
		if (packproxy.TryGeGoodtModel (id, out model)) {
			++model.count;
			packproxy.update (id,model);
		} else if (packproxy.isfull ()) {
			return;
		} else {
            model = packproxy.getback ();
			model.goodid = id;
            model.count = 1;

        }
		if(io.data!=null)
			model.AddHashId((int)io.data);
        AppFactory.instances.Todo (new Observer ("RendertoViewcommand","main"));
        AppFactory.instances.closePackage(AppFactory.instances.entrytab, false);
        AppFactory.instances.showpack(AppFactory.instances.entrytab,false,true,false,false);
        
        AppFactory.instances.ssinvoke();

	}
}
