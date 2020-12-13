using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class post : MonoBehaviour
{
    public GameObject titile;
    public middleLayer a;
    public GameObject player;
    public GameObject mediaplayer;
    public Camera main;
    public GameObject onecardevent, threecardevent;
    public GameObject table;
    public bool ispost = false,isblink = false;
    public GameObject[] paint;
    public GameObject[] paintbase;

    void Update()
    {
        RaycastHit hitpoint;
        if ((Input.GetKeyDown(KeyCode.Tab) && AppFactory.instances.myglobelstate == Globelstate.state.start) || (Input.GetMouseButtonDown(1) && AppFactory.instances.myglobelstate == Globelstate.state.start))
        {
            AppFactory.instances.entrytab.GetComponentInChildren<Text>().text = "点击物品进行使用";
            AppFactory.instances.showpack(AppFactory.instances.entrytab);
            AppFactory.instances.Todo(new Observer("hide"));
            AppFactory.instances.CancelInvoke("sinvoke");

        }
        if (Input.GetKeyDown(KeyCode.Backspace) && Input.GetKeyDown(KeyCode.F4))
        {

            AppFactory.instances.testSystem.SetActive(!AppFactory.instances.testSystem.activeSelf);
            AppFactory.instances.showpack();


        }
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKeyDown(KeyCode.F1))
        {

            AppFactory.instances.saveGame(1);
            Debug.Log("savegame");

        }
        if (Input.GetKeyDown(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.F1))
        {

            AppFactory.instances.loadGame(1);
            Debug.Log("loadgame");

        }

        if (isblink == true)
        {
            a.exit();
            isblink = false;

        }

        if (AppFactory.instances.GetbeUseObj() != null)
        {
            if(Vector3.Distance(this.transform.position, AppFactory.instances.GetbeUseObj().transform.position) >= 4f)
                 AppFactory.instances.SetbeUseObj(null);

        }
        if (ispost == true)
        {
            Ray o = main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
            Debug.DrawRay(o.origin, o.direction,Color.black);
            if (Physics.Raycast(o, out hitpoint, 1.8f,1))
            {//1.8
               
 
                if (hitpoint.collider.gameObject.layer == 0)
                {
                    a.intel();
                    AppFactory.instances.SetbeUseObj(hitpoint.collider.gameObject);
                    isblink = true;
                }

                if (hitpoint.collider.tag == "bloomtable" )
                {
                    hitpoint.collider.gameObject.layer = 1;
                    if (AppFactory.instances.eventTodo("赌桌事件")){
                        middleLayer.Instance.canMove = false;
                        middleLayer.Instance.MousePause();
                        hitpoint.collider.GetComponent<Onobjsession>().add();
                        AppFactory.instances.Todo(new Observer(Cmd.moveCamera, 4));
                        AppFactory.instances.closePackage(AppFactory.instances.entrytab);
                        AppFactory.instances.changestate(Globelstate.state.load);
                    }
                }

                if ((Input.GetKeyDown(KeyCode.E) && AppFactory.instances.isopenpackage == true || Input.GetMouseButtonDown(1) && AppFactory.instances.isopenpackage == true)&&AppFactory.instances.myglobelstate==Globelstate.state.start)
                {
                    AppFactory.instances.closePackage(AppFactory.instances.entrytab);
                }
                else if ((Input.GetKeyDown(KeyCode.E) && AppFactory.instances.isopenpackage == false || Input.GetMouseButtonDown(0)&& AppFactory.instances.isopenpackage==false) && AppFactory.instances.myglobelstate == Globelstate.state.start)
                {

                    AppFactory.instances.entrytab.GetComponentInChildren<Text>().text = "按tab开启物品栏";
                    if (hitpoint.collider.tag == "card")
                    {
                        cardDeal(hitpoint.collider);

                    }

                    else if (hitpoint.collider.name == "tv")
                    {
                        if (AppFactory.instances.eventTodo("播放电视"))
                        {
                            player.GetComponent<Animator>().SetTrigger("grag");
                            AppFactory.instances.Todo(new Observer(Cmd.playTv));

                        }
                    }

                    else if (hitpoint.collider.tag == "cd")
                    {

                        if (hitpoint.collider.name == "cd1")
                        {
                            player.GetComponent<Animator>().SetTrigger("grag");
                            AppFactory.instances.Todo(new Observer("AddGoodscommand", 7));
                            Destroy(hitpoint.collider.gameObject);
                        }
                        if (hitpoint.collider.name == "cd2")
                        {
                            player.GetComponent<Animator>().SetTrigger("grag");
                            AppFactory.instances.Todo(new Observer("AddGoodscommand", 8));
                            Destroy(hitpoint.collider.gameObject);
                        }
                        if (hitpoint.collider.name == "cd3")
                        {
                            player.GetComponent<Animator>().SetTrigger("grag");
                            AppFactory.instances.Todo(new Observer("AddGoodscommand", 9));
                            Destroy(hitpoint.collider.gameObject);
                        }


                    }
                    else if (hitpoint.collider.tag == "paint")
                    {
                        if (hitpoint.collider.name == "paint1")
                        {
                            player.GetComponent<Animator>().SetTrigger("grag");
                            AppFactory.instances.Todo(new Observer("AddGoodscommand", 10));
                            hitpoint.collider.gameObject.SetActive(false);
                            paintbase[0].SetActive(true);
                        }
                        if (hitpoint.collider.name == "paint2")
                        {
                            player.GetComponent<Animator>().SetTrigger("grag");
                            AppFactory.instances.Todo(new Observer("AddGoodscommand", 11));
                            hitpoint.collider.gameObject.SetActive(false);
                            paintbase[1].SetActive(true);
                        }
                        if (hitpoint.collider.name == "paint3")
                        {
                            player.GetComponent<Animator>().SetTrigger("grag");
                            AppFactory.instances.Todo(new Observer("AddGoodscommand", 12));
                            hitpoint.collider.gameObject.SetActive(false);
                            paintbase[2].SetActive(true);
                        }
                        if (hitpoint.collider.name == "paint1_base")
                        {

                            useItem("物品");
                        }
                        if (hitpoint.collider.name == "paint2_base")
                        {

                            useItem("物品");
                        }
                        if (hitpoint.collider.name == "paint3_base")
                        {
                            useItem("物品");

                        }
                    }
                    else if (hitpoint.collider.tag == "cardBase") {
                        useItem("卡牌");
                    }

                }

            }

        }



    }
    private void useItem(string itemName="物品") {
        AppFactory.instances.closePackage();
        AppFactory.instances.entrytab.GetComponentInChildren<Text>().text = "点击"+itemName+"进行使用";
        AppFactory.instances.showpack(AppFactory.instances.entrytab);
        return;

    }
    public void cardDeal(Collider t) {
        if (AppFactory.instances.eventTodo("第一张卡牌"))
        {
            onecardevent.GetComponent<Onobjsession>().add();

        }
        if (t.name == "card -j")
        {
            player.GetComponent<Animator>().SetTrigger("grag");
            AppFactory.instances.Todo(new Observer("AddGoodscommand", 1));
            Destroy(t.gameObject);
        }
        else if (t.name == "card -q")
        {
            player.GetComponent<Animator>().SetTrigger("grag");
            AppFactory.instances.Todo(new Observer("AddGoodscommand", 2));
            Destroy(t.gameObject);
        }
        else if (t.name == "card -k")
        {
            player.GetComponent<Animator>().SetTrigger("grag");
            AppFactory.instances.Todo(new Observer("AddGoodscommand", 3));
            Destroy(t.gameObject);
            //   getItem(hitpoint, 3);
        }
        else if ((t.name == "mycard0" || t.name == "mycard1"|| t.name == "mycard2")&& AppFactory.instances.eventTodo("不能回收手牌")) {
          
            //PostprocessModel tempModel = new PostprocessModel();
            //tempModel.id = 0;
            //tempModel.postEffectSrc = "UnityEngine.Rendering.PostProcessing.Vignette";
            //tempModel.intensity = 1;
            //tempModel.T+=M
            //AppFactory.instances.Todo(new Observer(Cmd.postEffectOperate, tempModel));
            player.GetComponent<Animator>().SetTrigger("grag");
            BloomModel.instance().gameObject.GetComponent<Onobjsession>().add();
        }

        if (PackProxy.instances().TryGeGoodtModel(1) == true && PackProxy.instances().TryGeGoodtModel(2) == true && PackProxy.instances().TryGeGoodtModel(3) == true)
        {
            if (AppFactory.instances.eventTodo("三张卡牌"))
            {
                threecardevent.GetComponent<Onobjsession>().add();
                table.SetActive(true);
                Audomanage.instance.OnPlay("duang");
            }
        }
    }
    private void getItem(RaycastHit hitpoint,int id) {
        player.GetComponent<Animator>().SetTrigger("grag");
        AppFactory.instances.Todo(new Observer("AddGoodscommand", id));
        hitpoint.collider.gameObject.SetActive(false);
    }


}

