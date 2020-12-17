using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Newtonsoft.Json;

public class PackProxy : Baseproxy<Packagemodel> {

	[JsonIgnore]
	private List<Inventory> invenToryList;
	private static PackProxy  instance;

	public static PackProxy instances()
	{
		if (instance == null) {
			instance = new PackProxy ();
		
		} 
			return instance;
		
	}
	public void crateInventory(int index)
	{
		for (int i = 0; i <= index; i++) {
			this.addmodeltolist (new Packagemodel (i));
		}
		
		//默认index=10;

	}
	internal bool isfull()
	{
		int count = this.modellist.Count (a => a.goodid == 0);
		if (count == 0) {
			return true;
		} else
			return false;
	}
	public Packagemodel getback()
	{
		return this.modellist.FirstOrDefault (a=>a.goodid==0);
	}
	public  bool TryGeGoodtModel(int id,out Packagemodel model)
	{model = null;
		model= modellist.FirstOrDefault (a => a.goodid == id);
		if (model != null)
			return true;
		else
			return false;
	}
    public bool TryGeGoodtModel(int id)
    {
       
       
        if (modellist.FirstOrDefault(a => a.goodid == id) != null)
            return true;
        else
            return false;
    }

    internal void setPackProxy(PackProxy packProxy)
    {
		this.modellist = packProxy.getmodellist();
		this.modellist.ForEach(e => { e.hashId.ForEach(hash => { invenToryList.ForEach(inven => { if (inven.GetHashCode() == hash) { inven.gameObject.SetActive(false);return; } });  }); });

	}

	public void AddInventory(Inventory temp) {
		if (invenToryList == null)
		{
			invenToryList = new List<Inventory>();
		}
		invenToryList.Add(temp);
	}
}
