using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GoodType id;
    public string invName;
    public string[] language;
    public GameObject cabinet;
    public bool is3DModel=false;



    private void Start()
    {

        //ReplaceLanguege();//代编辑
        PackProxy.instances().AddInventory(this);

    }

    void Update()
    {
        
    }

   public void ReplaceLanguege() {
        if (language.Length < Globelstate.LanguageLength()) {

            language = new string[Globelstate.LanguageLength()];

        }
        //一次读档所有获取

        for (int i= 0;i< language.Length; i++) {
            if (language[i]==null) {
                language[i] = invName;
            }
        
        }

        foreach (Globelstate.language lan in Globelstate.getLanguage()) {
            PackProxy.instances().inventoryDic[(int)lan].TryGetValue(this.gameObject.GetHashCode(), out language[(int)lan]);
        }
        GenerateText();
           
            
    }
    private void GenerateText()
    {
        string tempUrl=invName;
        Globelstate.language myLanguege=OpnionProxy.instances().mylanguage;
        if (language != null)
        {
            int index =(int)myLanguege;
            if (index < language.Length) {
                invName = language[index];


            }
            
            
   


        }

        Goodproxy.instances().addInventory(new Goodsmodel(tempUrl, (int)id, invName, is3DModel));
        //    for (int i = 0; i < language.Length; i++)
        //    {
        //        tex += MySingleD[i].talkobj.name + ">";
        //        if (MySingleD[i].ChineseVersion != null && language == (int)Globelstate.language.china)
        //            tex += MySingleD[i].ChineseVersion;
        //        else if (MySingleD[i].ChineseVersion == null && language == (int)Globelstate.language.china)
        //            tex += "中文";
        //        else if (MySingleD[i].EnglishVersion != null && language == (int)Globelstate.language.english)
        //            tex += MySingleD[i].EnglishVersion;
        //        else if
    }




    public void Refresh() {
        if (id == GoodType.世界名画1)
        {
        }
        else if (id == GoodType.世界名画2) {
        } else if (id== GoodType.刚画好的油画) { 
            
       }

    }
}


public enum GoodType {

    
    J=1,
    Q=2,
    K=3,
    一些扑克,
    扑克_小鬼,
    扑克_大鬼,
    cd_1,
    cd_2,
    cd_3,
    世界名画1,
    世界名画2,
    刚画好的油画,
    撬棍
    //this.addmodeltolist(new Goodsmodel("♠Q", this.getMaxid() + 1));
    //this.addmodeltolist(new Goodsmodel("♠K", this.getMaxid() + 1));
    //this.addmodeltolist(new Goodsmodel("一些扑克", this.getMaxid() + 1));
    //this.addmodeltolist(new Goodsmodel("扑克-小鬼", this.getMaxid() + 1));
    //this.addmodeltolist(new Goodsmodel("扑克-大鬼", this.getMaxid() + 1));
    //this.addmodeltolist(new Goodsmodel("cd-1", this.getMaxid() + 1));
    //this.addmodeltolist(new Goodsmodel("cd-2", this.getMaxid() + 1));
    //this.addmodeltolist(new Goodsmodel("cd-3", this.getMaxid() + 1));
    //this.addmodeltolist(new Goodsmodel("世界名画1", this.getMaxid() + 1));
    //this.addmodeltolist(new Goodsmodel("世界名画2", this.getMaxid() + 1));
    //this.addmodeltolist(new Goodsmodel("刚画好的油画", this.getMaxid() + 1));

}