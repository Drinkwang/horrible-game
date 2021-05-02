using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Text;

public class PackProxy : Baseproxy<Packagemodel> {

	[JsonIgnore]
	private List<Inventory> inventoryList;
	private static PackProxy  instance;
	[JsonIgnore]
	public Dictionary<int, string>[] inventoryDic; 

	public static PackProxy instances()
	{
		if (instance == null) {
			instance = new PackProxy ();
		
		}
		instance.ModelToDoView();
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
		this.modellist.ForEach(e => {
			if (e.hashId!=null)
			{
				e.hashId.ForEach(hash =>
				{
					inventoryList.ForEach(inven =>
					{
						if (inven.GetHashCode() == hash)
						{
							inven.gameObject.SetActive(false);
							inven.Refresh();
							return;

						}
					});
				});
			}
		});

	}

	public void AddInventory(Inventory temp) {
		if (inventoryList == null)
		{
			inventoryList = new List<Inventory>();
		}
		inventoryList.Add(temp);
		if (temp.cabinet != null)
		{
			if (CabinetManagerComponent.instance.cabinetLengthTable[temp.cabinet].haveItem == null)
			{
				CabinetManagerComponent.instance.cabinetLengthTable[temp.cabinet].haveItem = new List<int>();
			}
			CabinetManagerComponent.instance.cabinetLengthTable[temp.cabinet].haveItem.Add((int)temp.id);
		}
	}

	public void removeInventory(Inventory temp) {
		inventoryList.Remove(temp);


	}

	public void saveAllInventoryLan() {


		foreach (Globelstate.language lan in Globelstate.getLanguage()) {
				string streamOpenFileName = Application.streamingAssetsPath + "/" + lan + "/" + "Inventory" + ".text";
			if (!File.Exists(streamOpenFileName)) {
				if (!Directory.Exists(Application.streamingAssetsPath + "/" + lan))
				{
					Directory.CreateDirectory(Application.streamingAssetsPath + "/" + lan);
				}
				string tex = "";
				for (int i = 0; i < inventoryList.Count; i++)
				{

					if (i != inventoryList.Count - 1)
					{

						if ((int)lan < inventoryList[i].language.Length)
							tex += inventoryList[i].GetHashCode() + "," + inventoryList[i].language[(int)lan] + '\n';
						else
							tex += inventoryList[i].GetHashCode() + "," + inventoryList[i].invName + '\n';
					}
					else {

						if ((int)lan < inventoryList[i].language.Length)
							tex += inventoryList[i].GetHashCode() + "," + inventoryList[i].language[(int)lan];
						else
							tex += inventoryList[i].GetHashCode() + "," + inventoryList[i].invName;
					}



				}


				File.WriteAllText(streamOpenFileName, tex, Encoding.UTF8); 
			}
		}
		loadAllInventoryLan();
	}


	public void loadAllInventoryLan() {
		inventoryDic = new Dictionary<int, string>[Globelstate.LanguageLength()];

		foreach (Globelstate.language lan in Globelstate.getLanguage())
		{
			inventoryDic[(int)lan] = new Dictionary<int, string>();
			string streamOpenFileName = Application.streamingAssetsPath + "/" + lan + "/" + "Inventory" + ".text";

			if (!Directory.Exists(Application.streamingAssetsPath + "/" + lan))
			{
				Directory.CreateDirectory(Application.streamingAssetsPath + "/" + lan);
			}
			if (File.Exists(streamOpenFileName))
			{

				StreamReader sr = new StreamReader(streamOpenFileName);
				if (sr != null)
				{
					string temp = sr.ReadToEnd();
					string[] languages = temp.Split('\n');
					for (int i = 0; i < languages.Length; i++)
					{
						string[] hashAndLang = languages[i].Split(',');
						inventoryDic[(int)lan].Add(int.Parse(hashAndLang[0]),hashAndLang[1]);
					}
				}

			}
		}

		foreach (Inventory inv in inventoryList) {

			inv.ReplaceLanguege();
		}



		
	}
}
