﻿
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Packagemodel : Basemodel {
	public int count=0;
	private int Goodid;
	public int goodid
	{get{ return this.Goodid;}
		set{Goodid = value;}}
	public Packagemodel(int id,int count,int goodid):base(id)
	{
		this.goodid=goodid;
		this.count=count;
	}


	public Packagemodel(int id):base(id)
	{
		
	}
	public Goodsmodel good;
	// Use this for initial
	
	// Update is called once per frame
	public Packagemodel()
	{

	}


}
