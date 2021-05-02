using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
public class Baseproxy<T> where T:Basemodel,new()  {
	public List<T> modellist;
	public List<view> IComponentList;
	// Use this for initialization
	public Baseproxy()
	{
		modellist=new List<T>();
	}

	public void regiestNewComponent(view t) {
		if (IComponentList == null) {
			IComponentList = new List<view>();
		}
		IComponentList.Add(t);
	}

	public void removeNewComponent(view t)
	{
		if (IComponentList != null && IComponentList.Count > 0)
		{
			IComponentList.Remove(t);
		}

	}


	public void ModelToDoView() {
		if (IComponentList != null&&IComponentList.Count>0)
		{
			foreach (view t in IComponentList) {

				t.refresh();
			}
		}

	}



	public bool TryGetModel(int id,out T model)
	{model=modellist.FirstOrDefault(a=>a.id==id);
		if (model == null) {
			return false;
		} else {
		
			return true;}
	
	}
	public List<T>getmodellist()
	{return modellist;
	}
	public int getMaxid()
	{
		if (this.modellist.Count == 0)
			return 0;
		return this.modellist.Max (a => a.id);
	}
	public void update(int id,T model)
	{
		T temp = this.GetmodelbyId (id);
		model = temp;
	}
    public void removeModeltoList(T xxx) {
        modellist.Remove(xxx);
    }

	public void addmodeltolist(T xxx)
	{modellist.Add (xxx);
	}
	public T GetmodelbyId(int id)
	{T model=modellist.FirstOrDefault (a => a.id == id);
		return model;
	}
}
