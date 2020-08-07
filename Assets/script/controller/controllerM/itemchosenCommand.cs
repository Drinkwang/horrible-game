using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemchosenCommand : IC {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
 

    public void Todo(Observer o)
    {

        if ((string)o.msg == "render")
        {
            AppFactory.instances.viewTodo(new Observer("showitem", itemchoseproxy.instances().getmodellist()));
            itemchoseproxy.instances().clear();
        }
        else if ((string)o.msg == "add")
        {
            int i = itemchoseproxy.instances().getMaxid();

            //传递数组
            itemchosenmodel t = new itemchosenmodel(i + 1, o.body as Befunction);
            itemchoseproxy.instances().add(t);

        }
        else if ((string)o.msg == "hide")
        {
        //    Debug.Log("he!!!");
            AppFactory.instances.viewTodo(new Observer("hideitem"));
        }

        //throw new System.NotImplementedException();//if o.date=="render" or “add” Separate execution
    }
}
