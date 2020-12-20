using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goodsmodel : Basemodel {
	public string src;
	public string name;
	// Use this for initialization
	public Goodsmodel(string src,int id,string name):base(id)
	{this.src = src;
		this.name = name;
	}
	
	// Update is called once per frame
	public Goodsmodel()
	{}

}
