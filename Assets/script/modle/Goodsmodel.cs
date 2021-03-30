using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goodsmodel : Basemodel {
	public string src;
	public string name;
	public bool is3DModel = false;
	// Use this for initialization
	public Goodsmodel(string src,int id,string name, bool is3DModel) :base(id)
	{this.src = src;
		this.name = name;
		this.is3DModel = is3DModel;
	}
	
	// Update is called once per frame
	public Goodsmodel()
	{}

}
