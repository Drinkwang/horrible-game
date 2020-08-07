using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AppFactory : MonoBehaviour
{
    public static AppFactory instances;
    public controller c;
    public view v;
    public RendertoViewcommand render;
    public AddGoodscommand add;
    public UseGoodscommand useGoodCommand;
    public Oncesessioncommand once;
    public AddTaskcommand task;
    public RenderTaskcommand rtask;
    private itemchosenCommand ichosen;
    private scriptcommand scribe;
    public GameObject talkobj;
    private TvCommand tvShow;
    public ChangeGoodcommand changegoodat;
    private CinemaControl cinemaContorl;
    private PostProcessController postProcessController;

    public bool isopenpackage = false;
    private allsave mysave;
    public GameObject entrytab;
    public GameObject testSystem;
    //public GameObject quiver,enemy;
    // public string character;
    //public move playercontrolpower;
    public Image hp;
    public Text tasktitle;
    private GameObject beUseObj;
    public post postObj;
    public void SetbeUseObj(GameObject temp) {

        beUseObj =temp;
    }

    public GameObject GetbeUseObj()
    {
        return beUseObj;
    }

    private Globelstate.state globelstate;
    public Globelstate.state myglobelstate
    {
        get { return globelstate; }
        private set { globelstate = value; }
    }
    private Globelstate.language elanguage;
    public Globelstate.language mylanguage
    {
        get { return elanguage; }
        private set { elanguage = value; }
    }

    public void changevalue(Dropdown change)
    {
        Debug.Log(change.value);
        if (change.value == 0)
        { mylanguage = Globelstate.language.china; }
        else if (change.value == 1)
        { mylanguage = Globelstate.language.english; }
        else if (change.value == 2)
        { mylanguage = Globelstate.language.japanense; }
    }

    public enum itemstate
    {
        package,
        task
    };
    itemstate nowstate;
    private bool kaca = true;
    public void changekacasound(bool t){
        t = !t;
    }


    void Update()
    {

    }

    void Awake()
    {
        if (instances == null)
        {
            instances = this;
        }
        globelstate = Globelstate.state.unstart;
        nowstate = itemstate.package;
    }

    public void changestate(Globelstate.state a)
    { globelstate = a; }
    public void AdjustCommand(string msg, IC i)
    {
        this.c.AdjustCommand(msg, i);

    }
    void Start()
    {
        mysave = allsave.instance;
        c = new controller();
        v = new view();
        render = new RendertoViewcommand();
        once = new Oncesessioncommand();
        scribe = new scriptcommand();
        task = new AddTaskcommand();
        rtask = new RenderTaskcommand();
        ichosen = new itemchosenCommand();
        postProcessController = new PostProcessController();

        add = new AddGoodscommand();
        changegoodat = new ChangeGoodcommand();
        useGoodCommand = new UseGoodscommand();

        cinemaContorl = new CinemaControl();

        tvShow = new TvCommand();
        //	Packageview packageview = 
        //THIS IS MORE VIEW BE WRITTER
        AdjustView(new ItemselectView());
        AdjustView(new Packageview());
        AdjustView(new dialogview());
        AdjustView(new taskview());
        AdjustView(new Scribeview());
        AdjustView(new CinemaView());
        AdjustView(new TvView());
        AdjustView(new PostEffectView());

        AdjustCommand("once", once);
        AdjustCommand("RendertoViewcommand", render);
        AdjustCommand("exchange", changegoodat);
        AdjustCommand("AddGoodscommand", add);
        AdjustCommand(Cmd.consumeItem, useGoodCommand);
        //below code present itemchosenCommand
        AdjustCommand("add", ichosen);
        AdjustCommand("render", ichosen);
        AdjustCommand("hide", ichosen);
        AdjustCommand("tvShow", tvShow);

        // later will be add delete task
        AdjustCommand("addtask", task);
        AdjustCommand("rtask", rtask);
        AdjustCommand("changeM", scribe);

        //relative Camera about 
        AdjustCommand("changeCamere", cinemaContorl);
        AdjustCommand("moveCamera", cinemaContorl);
        AdjustCommand("addCamera", cinemaContorl);


        //relative To postEffct 
        AdjustCommand(Cmd.shaderPostEffectOperate, postProcessController);
        AdjustCommand(Cmd.initPostEffectOperate,postProcessController);
        AdjustCommand(Cmd.initPostEffectModel, postProcessController);
        AdjustCommand(Cmd.postEffectOperate, postProcessController);

        //为了防止出错，新的命令层和view层指令尽量统一，并且放在cmd类里面
        AdjustCommand(Cmd.changeTv, tvShow);
        AdjustCommand(Cmd.initTv, tvShow);
        AdjustCommand(Cmd.playTv, tvShow);
        AdjustCommand(Cmd.stopTv, tvShow);



    }


    void AdjustView(Vmediator mediator)
    {
        if (mediator != null)
        {
            //			Debug.Log ("xx");
            v.AdjustView(mediator);

        }
    }
    public void viewTodo(Observer mediator)
    {
        if (mediator != null)
        {
            v.viewTodo(mediator);
        }

    }
    public void Todo(Observer o)
    {
        c.Todo(o);


    }
    public void addchosenitem(List<itemchosenmodel> t)
    {
        for (int i = 0; i < t.Count; i++)
        { Todo(new Observer("add")); }
    }


    public void showpack(GameObject blind=null,bool playAudio=true,bool isMove=false)
    {
        if (isopenpackage == false)
        {
            isopenpackage = true;
            if(blind!=null)
                blind.SetActive(true);
            //     Audomanage.instance.bg.Pause();
            if(playAudio==true)
                Audomanage.instance.OnPlay("pick");
            if(isMove==false)
                middleLayer.Instance.MousePause();
            //Time.timeScale = 0;

            if (nowstate == itemstate.package)
            {
                Todo(new Observer("RendertoViewcommand"));
            }
            else if (nowstate == itemstate.task)
            { //Todo(new Observer("rtask")); 
                TaskComponent.instance.transform.GetChild(0).gameObject.SetActive(true);
                Todo(new Observer("rtask", "main"));

            }
        }
        else 
        {
            //       Audomanage.instance.bg.Play();
            packageComponent.instante.closePackage();
            //  TaskComponent.instance.transform.GetChild(0).gameObject.SetActive(false);
            //close taskitem
            if(blind!=null)
                blind.SetActive(false);
            // Time.timeScale = 1;
            isopenpackage = false;

            middleLayer.Instance.MouseRun();
            // if(kaca==true)
            if (playAudio == true)
                Audomanage.instance.OnPlay("kaca");
        }
     
    }

    public void closePackage(GameObject blind = null,bool isPlayAudio=true) {
        if (isopenpackage == true)
        {
            packageComponent.instante.closePackage();
            //close taskitem
            if (blind != null)
                blind.SetActive(false);
            // Time.timeScale = 1;
            StartCoroutine("ClosePackage");
            middleLayer.Instance.MouseRun();
            // if(kaca==true)
            if(isPlayAudio==true)
                Audomanage.instance.OnPlay("kaca");
        }
    }

    public IEnumerator ClosePackage() {
        yield return new WaitForSeconds(0.01f);
        isopenpackage = false;

    }

    public void ssinvoke()
    {
        isopenpackage = false;
        CancelInvoke("sinvoke");
        Invoke("sinvoke", 3f);

    }
    public void sinvoke()
    {
        if (isopenpackage != true)
            packageComponent.instante.closePackage();
            entrytab.SetActive(false);
        //  TaskComponent.instance.transform.GetChild(0).gameObject.SetActive(false);
        //close taskitem

        // Time.timeScale = 1;

    }

    public void taskadd(int tasknum)
    {
        Todo(new Observer("addtask", tasknum));

    }
    public bool eventTodo(string t) {
        if (mysave.every.ContainsKey(t)&&mysave.every[t]==false) {
            mysave.every[t] = true;
            return true;
        }
        return false;

    }
    public void StartGame()
    {

        talkobj.GetComponent<Onobjsession>().add();
        viewTodo(new Observer(Cmd.initCamera));
        Todo(new Observer(Cmd.initPostEffectOperate));

    }
    public void Cleardialog()
    {

    }

    public void generalPaintBase() {
        for (int i = 0; i < this.postObj.paint.Length; i++) {

            if (this.postObj.paint[i].activeSelf== false)
                this.postObj.paintbase[i].SetActive(true);
            else if(postObj.paint[i].activeSelf == true){ 
                this.postObj.paintbase[i].SetActive(false);
            }
        }
       

    }
    /// <summary>
    /// this param is very import,it is dialogText creator;
    /// </summary>
    /// <param name="chinese"></param>
    /// <param name="eng"></param>
    /// <param name="chineseAC"></param>
    /// <param name="engAC"></param>
    /// <returns></returns>
    /*
    public SingledialogText addDiaglog(string chinese,string eng,AudioClip chineseAC,AudioClip engAC)
    {
       SingledialogText a = new SingledialogText();
        a.ChineseAC =chineseAC;
        a.EnglishAC =engAC;
        a.ChineseVersion =chinese;
        a.EnglishVersion =eng;
        return a;
        // Todo(new Observer("addtask",1));
     

    }*/
    /*  public SingledialogText addDiaglog(string talk)
      {
          SingledialogText a = new SingledialogText();
          a.ChineseAC = null;
          a.EnglishAC = null;
          a.ChineseVersion = null;
          a.EnglishVersion = null;
          a.talkobj = talk;
          return a;
          // Todo(new Observer("addtask",1));


      }
      */
    /* public void getenemy(Transform t)
     {

           mainpool.GetObject("eneyNum").GetComponent<MonsterWander>().initialPosition = t.position;
         mainpool.GetObject("eneyNum").transform.position = t.position;
     }*/

    public void changetitle(string a)
    { tasktitle.text = a; }

}
