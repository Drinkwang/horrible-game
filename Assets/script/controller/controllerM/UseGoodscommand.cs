using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseGoodscommand : IC {
	PackProxy packproxy=PackProxy.instances();
	//Goodproxy goodproxy=Goodproxy.instances();

	// Use this for initialization
	public void Todo(Observer io)
	{//Debug.Log ("as2sa");
		int id = 1;
		Packagemodel model = null;
		if (!int.TryParse (io.body.ToString (), out id)) {
			return;}
		if (packproxy.TryGeGoodtModel (id, out model)) {
			--model.count;
            if (model.count > 0)
                packproxy.update(id, model);
            else {
                model.count=0;
                model.goodid = 0;
                packproxy.update(id, model); }
           
            AppFactory.instances.Todo(new Observer("RendertoViewcommand", "main"));
        } 

        
        //AppFactory.instances.Todo (new Observer ("RendertoViewcommand","main"));
       

//		Debug.Log ("assa");

	}
}
