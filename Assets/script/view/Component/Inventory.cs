using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GoodType id;
    public string invName;
    public string[] language; 

    private void Start()
    {

        ReplaceLanguege();//代编辑
        PackProxy.instances().AddInventory(this);
        Goodproxy.instances().addInventory(new Goodsmodel(invName, (int)id));

        //            this.addmodeltolist(new Goodsmodel("♠J", this.getMaxid() + 1));
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

    void Update()
    {
        
    }

   public void ReplaceLanguege() {
        
    
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
    刚画好的油画
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