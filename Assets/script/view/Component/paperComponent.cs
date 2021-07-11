using Assets.script.Utils;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paperComponent : MonoBehaviour
{
    public languageString top;
    public languageString center;
    public languageString inscribe;
    public Color topC;
    public Color centerC;
    public Color inscribeC;
    public PaperType id=PaperType.相机1;

    public bool isExit;
    public bool IsDestory;
    // Start is called before the first frame update
    void Start()
    {
        OnReadPaper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReadPaper() {

        //可以用反射的来实现多语言变化，目前只实现三种语言

        PaperModel model= PaperProxy.instances().getModelByElement("PaperId", (int)id);
        top.china = model.china[0];
        top.english = model.english[0];
        top.japanense = model.japanense[0];

        center.china = model.china[1];
        center.english = model.english[1];
        center.japanense = model.japanense[1];

        inscribe.china = model.china[2];
        inscribe.english = model.english[2];
        inscribe.japanense = model.japanense[2];

    }
    public void OnPaperShow() {

        string[] temp = new string[] { top.china, center.china, inscribe.china };
        AppFactory.instances.Todo(new Observer("changeM", temp));
    }
}




public enum PaperType
{


    相机1 = 1,

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