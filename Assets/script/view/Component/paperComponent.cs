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
    // public PaperType id=PaperType.相机1;


    public PaperType type = PaperType.相机1;
    private PaperValue paper;
    //public bool isExit;
    //public bool IsDestory;
    //private int MainId;
    //private int HashId;
    // Start is called before the first frame update
    void Start()
    {

        PaperValueProxy.instances().addPaperComponentToList(this);
        OnReadPaper();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnReadPaper() {



        PaperModel model= PaperProxy.instances().getModelByElement("PaperId", (int)type);


        foreach (languageType lan in Multilingual.getLanguage()) {
            string lanType = lan.ToString();

            string[] t = model.GetType().GetField(lanType).GetValue(model) as string[];
            top.GetType().GetField(lanType).SetValue(top, t[0]);
            center.GetType().GetField(lanType).SetValue(center, t[1]);
            inscribe.GetType().GetField(lanType).SetValue(inscribe, t[2]);
            // Debug.Log();

        }
        this.paper = new PaperValue();
        this.paper.isExit = model.IsExit;
        this.paper.isDestory = model.IsDestory;
        this.paper.hashId = this.gameObject.GetHashCode();
        this.paper.id = model.PaperId;
        if (model.Color.Length >= 12) {
            topC.r= model.Color[0];
            topC.g= model.Color[1];
            topC.b = model.Color[2];
            topC.a= model.Color[3];

            centerC.r = model.Color[4];
            centerC.g = model.Color[5];
            centerC.b = model.Color[6];
            centerC.a = model.Color[7];

            inscribeC.r = model.Color[8];
            inscribeC.g = model.Color[9];
            inscribeC.b = model.Color[10];
            inscribeC.a = model.Color[11];


        }

    //    paper.type = (PaperType)model.PaperId;
      //  Color = new Color( model.Color[0], model.Color[1], model.Color[2], model.Color[3]);


        //top.china = model.china[0];
        //top.english = model.english[0];
        //top.japanense = model.japanense[0];

        //center.china = model.china[1];
        //center.english = model.english[1];
        //center.japanense = model.japanense[1];

        //inscribe.china = model.china[2];
        //inscribe.english = model.english[2];
        //inscribe.japanense = model.japanense[2];

    }
    public void OnPaperShow() {
        string lanType = OpnionProxy.instances().mylanguage.ToString() ;
     //   top.GetType().GetField(lanType).GetValue(top);
        string t = (string)top.GetType().GetField(lanType).GetValue(top);
        string c= (string)center.GetType().GetField(lanType).GetValue(center);
        string i= (string)inscribe.GetType().GetField(lanType).GetValue(inscribe);
        string[] temp = new string[] { t, c, i };
       // string[] temp = new string[] { top.china, center.china, inscribe.china };
        Color[] tempColor = new Color[] {topC,centerC,inscribeC};
       // paperValue paper = new paperValue();
        
        AppFactory.instances.Todo(new Observer("changeM", temp,tempColor,paper));
    }
}




