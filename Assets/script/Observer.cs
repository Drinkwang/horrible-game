using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer  {
	
	public string msg;
	public object body;
    /// <summary>
    /// date 字段是特殊時期使用的，非特殊情況盡可能保留
    /// </summary>
    public object data;
    public object data2;
    public object data3;



    public Observer(string msg, object body, object date, object data2, object data3) {
        this.msg = msg;
        this.body = body;
        this.data = date;
        this.data2 = data2;
        this.data3 = data3;

    }

    public Observer(string msg, object body, object date,object data2)
    {
        this.msg = msg;
        this.body = body;
        this.data = date;
        this.data2 = data2;

    }
    // Use this for initialization

    public Observer(string msg,object body,object date) {
        this.msg = msg;
        this.body = body;
        this.data = date;

    }


	public Observer(string msg,object body){
        this.msg = msg;
		this.body = body;
	
	}
	public Observer(string msg):this(msg,null)
	{

	}

  
}
