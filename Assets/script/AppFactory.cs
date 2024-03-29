﻿using Assets.script.Utils;
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
    private SortItemcommand sortItemcommand;

    public Oncesessioncommand once;
    public AddTaskcommand task;
    public RenderTaskcommand rtask;
    private itemchosenCommand ichosen;
    private scriptcommand scribeObj;
    public GameObject talkobj;
    private TvCommand tvShow;
    public ChangeGoodcommand changegoodat;
    private CinemaControl cinemaContorl;
    private PostProcessController postProcessController;
    private QuetionController quetionController;
    private SaveSystemController saveSystemController;
    
    public bool isopenpackage = false;
    private allsave mysave;
    //public GameObject entrytab;
    public GameObject testSystem;
    public GameObject raceEvent;
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

    public void changePost(bool active) {
        postObj.ispost = active;

    }

    public void ChangeIsHitChangeObj(bool active){
        postObj.isHitChangeObj = active;
    }
    public bool IsHitItem() {

        return postObj.IsHit();
    }


    public GameObject GetbeUseObj()
    {
        return beUseObj;
    }

    //private Globelstate.state globelstate;
    //public Globelstate.state myglobelstate
    //{
    //    get { return globelstate; }
    //    private set { globelstate = value; }
    //}
    //private languageType elanguage;
    //public languageType mylanguage
    //{
    //    get { return elanguage; }
    //    private set { elanguage = value; }
    //}

    public void changevalue(Dropdown change)
    {
        OpnionProxy opnion=OpnionProxy.instances();
        Debug.Log(change.value);
        if (change.value == 0)
        { opnion.SetLanguage(languageType.china); }
        else if (change.value == 1)
        { opnion.SetLanguage(languageType.english); }
        else if (change.value == 2)
        { opnion.SetLanguage(languageType.japanense); }
    }

    public enum itemstate
    {
        package,
        task
    };
    itemstate nowstate;

    public void changekacasound(bool t){
        t = !t;
    }


    void Awake()
    {
        if (instances == null)
        {
            instances = this;
        }
        OpnionProxy.instances().setState(Globelstate.state.unstart);

        nowstate = itemstate.package;
    }

    public void changestate(Globelstate.state a,bool changeState)
    { 
        OpnionProxy.instances().setState(a);

        if (changeState == true)
        {
            if (a == Globelstate.state.load)
            {
                AppFactory.instances.closePackage(false);
                middleLayer.Instance.canMove = false;
                middleLayer.Instance.MousePause();
            }
            else if (a == Globelstate.state.start)
            {
                middleLayer.Instance.canMove = true;
                middleLayer.Instance.MouseRun();


            }
        }
    
    }
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
        scribeObj = new scriptcommand();
        task = new AddTaskcommand();
        rtask = new RenderTaskcommand();
        ichosen = new itemchosenCommand();
        postProcessController = new PostProcessController();
        quetionController = new QuetionController();
        add = new AddGoodscommand();
        changegoodat = new ChangeGoodcommand();
        useGoodCommand = new UseGoodscommand();
        sortItemcommand = new SortItemcommand() ;

        cinemaContorl = new CinemaControl();
        saveSystemController = new SaveSystemController();

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
        AdjustView(new QuetionView());

        //只有View层，没有model层的方法
        AdjustView(new CabinetManagerView());
        //------------------------------------------------------
        AdjustCommand(Cmd.dialogReplace, once);
        AdjustCommand(Cmd.dialog, once);
        AdjustCommand(Cmd.dialogRemove,once);

        AdjustCommand(Cmd.renderAllItem, render);
        AdjustCommand(Cmd.exchangeMySelfItem, changegoodat);
        AdjustCommand(Cmd.sortAllItem, sortItemcommand);
        AdjustCommand(Cmd.addItem, add);
        AdjustCommand(Cmd.consumeItem, useGoodCommand);
        //below code present itemchosenCommand
        AdjustCommand(Cmd.iChosenAdd, ichosen);
        AdjustCommand(Cmd.iChosenRender, ichosen);
        AdjustCommand(Cmd.iChosenHide, ichosen);


        // later will be add delete task
        AdjustCommand(Cmd.addTask, task);
        AdjustCommand(Cmd.renderTask, rtask);
        AdjustCommand(Cmd.changeM, scribeObj);

        //relative Camera about 
        AdjustCommand(Cmd.changeCamera, cinemaContorl);
        AdjustCommand(Cmd.moveCamera, cinemaContorl);
        AdjustCommand(Cmd.addCamera, cinemaContorl);


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
        //AdjustCommand("tvShow", tvShow);

        //QuetionComponent
        AdjustCommand(Cmd.QuetionChangeButton, quetionController);
        AdjustCommand(Cmd.QuetionChangeTitle, quetionController);
        AdjustCommand(Cmd.QuetionShow, quetionController);
        AdjustCommand(Cmd.QuetionChangeA, quetionController);
        AdjustCommand(Cmd.QuetionCHnngeB, quetionController);

        //saveSystem
        AdjustCommand(Cmd.saveGame, saveSystemController);
        AdjustCommand(Cmd.loadGame, saveSystemController);
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


    /// <summary>
    /// 
    /// </summary>
    /// <param name="blind">是否携带组件进行关闭</param>
    /// <param name="playAudio">播放 kaca 的声音</param>
    /// <param name="isMove">如果该值为false，则关闭主角的移动选项</param>
    /// <param name="IsChangePost">如果该值为false，则关掉主角能交互物品的功能</param>
    /// <param name="changeIsHitChangeObj">如果该值为ture，则关掉物品聚焦锚点，玩家将无法改变使用物品对象</param>
    public void showpack(string tagCmd="",bool playAudio=true,bool isMove=false,bool IsChangePost=true,bool changeIsHitChangeObj=true)
    {
        if (isopenpackage == false)
        {
            if(changeIsHitChangeObj==true)
                ChangeIsHitChangeObj(false);
            if (IsChangePost==true)
                AppFactory.instances.changePost(false);
            isopenpackage = true;

            if(playAudio==true)
                Audomanage.instance.OnPlay("pick");
            if(isMove==false)
                middleLayer.Instance.MousePause();

            if (nowstate == itemstate.package)
            {
                Todo(new Observer(Cmd.renderAllItem, "main", tagCmd));
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
            AppFactory.instances.changePost(true);
            packageComponent.instante.closePackage();
            ChangeIsHitChangeObj(true);
            //if (blind!=null)
            //    blind.SetActive(false);
            isopenpackage = false;

            middleLayer.Instance.MouseRun();
            // if(kaca==true)
            if (playAudio == true)
                Audomanage.instance.OnPlay("kaca");
        }
     
    }

    public void closePackage(bool isPlayAudio=true) {
        if (isopenpackage == true)
        {
            ChangeIsHitChangeObj(true);
            AppFactory.instances.changePost(true);
            packageComponent.instante.closePackage();
            //close taskitem
            //if (blind != null)
            //    blind.SetActive(false);
            StartCoroutine("ClosePackage");
            middleLayer.Instance.MouseRun();

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
        {
            packageComponent.instante.closePackage();
            //entrytab.SetActive(false);
            //ChangeIsHitChangeObj(true);
        }


    }

    public void taskadd(int tasknum)
    {
        Todo(new Observer("addtask", tasknum));

    }


    public bool eventIsCanExcuteState(eventCmd t) {
        if (mysave.every.ContainsKey(t) && mysave.every[t] == false)
        {
            return true;
        }
        return false;

    

    }

    public bool eventTodo(eventCmd t) {
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
        PackProxy.instances().saveAllInventoryLan();

    }



    public void saveGame(int slot) {
        AppFactory.instances.Todo(new Observer(Cmd.saveGame, slot));
    }


    public void loadGame(int slot) {
        AppFactory.instances.Todo(new Observer(Cmd.loadGame, slot));
    }

    public void setPosition(Transform temp) {

        postObj.setPoSition(temp);
    
    }
    public void changetitle(string a)
    { tasktitle.text = a; }

    public bool adjustPlayerIsDown() {
        if (postObj.getPlayerHeight() >= 7)
        {
            return false;

        }
        else if(postObj.getPlayerHeight()<4.5){
            return true ;
        }
        return false;
    
    
    }

}
