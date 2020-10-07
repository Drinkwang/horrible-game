using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class LinEvent : Befunction
{
    public GameObject stoneScissorCloth;
    private Canvas canvas;
    private packageComponent packageC;
  //  private BloomModel bloomModel;
    public Camera tempCamera;
    private float intensity =0.2f;

    private List<GameObject> hintObj;
    public enum linType 
    {

        Lin_event_beganning=0,
        Lin_event_2=1,
        Lin_event_3=2,
        Lin_event_4=3,
        Lin_event_5FinalNo=4
        //IGG_MobileRoyale,
    }
    public linType type;


    public LinEvent(string temp) : base(temp)
    {
    }

    public void Awake()
    {
        packageC = packageComponent.instante;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
       // bloomModel = BloomModel.instance();
    }

    public void event1 (){
        AppFactory.instances.Todo(new Observer(Cmd.playTv));        
      //  AppFactory.instances.Todo(new Observer(Cmd.moveCamera, 3));
        AppFactory.instances.Todo(new Observer(Cmd.QuetionChangeTitle, "你因为一次和工友回家，被带入一个神秘的场所，哪里充斥着各种牌九、麻将。工友说道：玩玩而已，你是否选择继续进行下去"));
        AppFactory.instances.Todo(new Observer(Cmd.QuetionShow,true));
        Action event1Yes;
        Action event1No;
        event1Yes = BtneventYes;
        event1No = BtneventNo;
        AppFactory.instances.Todo(new Observer(Cmd.QuetionChangeA,event1Yes));
        AppFactory.instances.Todo(new Observer(Cmd.QuetionCHnngeB,event1No));

    }

    public void event2() {
        AppFactory.instances.Todo(new Observer(Cmd.QuetionChangeTitle, "工友鼓吹你，继续呀，你这本钱还是太少，如果投入的多，你有机会赢得更多啊，"));
        AppFactory.instances.Todo(new Observer(Cmd.QuetionShow, true));
        Action event2Yes;
        event2Yes = BtneventYes2;
        AppFactory.instances.Todo(new Observer(Cmd.QuetionChangeA, event2Yes));
    }

    public void event3() {
        //PostprocessModel tempModel = new PostprocessModel();
        //tempModel.id = 0;
        //tempModel.postEffectSrc = "UnityEngine.Rendering.PostProcessing.Vignette";
        //tempModel.intensity = 1;
        //AppFactory.instances.Todo(new Observer(Cmd.postEffectOperate, tempModel));
        AppFactory.instances.Todo(new Observer(Cmd.QuetionChangeTitle, "只是手气不好，我再借你点钱，你一定能够回本"));
        AppFactory.instances.Todo(new Observer(Cmd.QuetionShow, true));
        Action event3Yes;
        event3Yes = BtneventYes3;
;
        AppFactory.instances.Todo(new Observer(Cmd.QuetionChangeA, event3Yes));

    }

    public void event4() {
        AppFactory.instances.Todo(new Observer(Cmd.QuetionChangeTitle, "是否收手，"));
        AppFactory.instances.Todo(new Observer(Cmd.QuetionShow, true));
        Button a = QuetionComponent.instance().no;
        a.interactable = true;
        Action eventFinal= BtnEvenFinal;
        AppFactory.instances.Todo(new Observer(Cmd.QuetionChangeA, eventFinal));
        AppFactory.instances.Todo(new Observer(Cmd.QuetionCHnngeB, eventFinal));
    }



    public void BtneventYes() {

        AppFactory.instances.Todo(new Observer(Cmd.QuetionShow, false));
        GameObject lin2 = GameObject.Find("Linevent2");
        lin2.GetComponent<Onobjsession>().add();
    }

    public void BtneventYes2() {
        PostprocessModel tempModel = new PostprocessModel();
        tempModel.id = 0;
        tempModel.postEffectSrc = "UnityEngine.Rendering.PostProcessing.Vignette";
        intensity = intensity + 0.2f;
        tempModel.intensity = intensity;
        AppFactory.instances.Todo(new Observer(Cmd.postEffectOperate, tempModel));
        AppFactory.instances.Todo(new Observer(Cmd.QuetionShow, false));
        GameObject lin2 = GameObject.Find("Linevent3");
        lin2.GetComponent<Onobjsession>().add();

    }

    public void BtneventYes3() {
        if (intensity < 1)
        {
            PostprocessModel tempModel = new PostprocessModel();
            tempModel.id = 0;
            tempModel.postEffectSrc = "UnityEngine.Rendering.PostProcessing.Vignette";
            intensity = intensity + 0.2f;
            tempModel.intensity = intensity;
            AppFactory.instances.Todo(new Observer(Cmd.postEffectOperate, tempModel));
            AppFactory.instances.Todo(new Observer(Cmd.QuetionShow, false));
            GameObject lin2 = GameObject.Find("Linevent3");
            lin2.GetComponent<Onobjsession>().add();
        }
        else
        {
            GameObject lin4 = GameObject.Find("Linevent4");
            lin4.GetComponent<Onobjsession>().add();
            AppFactory.instances.Todo(new Observer(Cmd.QuetionShow, false));

        }
    }
    public void BtnEvenFinal() {

        GameObject lin5 = GameObject.Find("Linevent5");
        lin5.GetComponent<Onobjsession>().add();
        AppFactory.instances.Todo(new Observer(Cmd.QuetionShow, false));
    }

    public void BtneventNo() {
        this.gameObject.GetComponent<Onobjsession>().add();
        Button a = QuetionComponent.instance().no;
        a.interactable = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        if (type == linType.Lin_event_beganning)
            base.A += event1;
        else if (type == linType.Lin_event_2)
            base.A += event2;
        else if (type == linType.Lin_event_3)
        {
            base.A += event3;
        }
        else if (type == linType.Lin_event_4) {
            base.A += event4;
        }
    }

}
