using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;

public class post : MonoBehaviour
{
    public GameObject titile;
    public middleLayer a;
    public GameObject player;
    public GameObject mediaplayer;
    public Camera main;
    public GameObject onecardevent, threecardevent;
    public GameObject table;
    public bool ispost = false, isblink = false, isHitChangeObj = true,isSpeakerPlaying=false;


    void Update()
    {
        OpnionProxy opnion = OpnionProxy.instances();
        RaycastHit hitpoint;
        if ((Input.GetKeyDown(KeyCode.Tab) && opnion.myglobelstate == Globelstate.state.start) || (Input.GetMouseButtonDown(1) && opnion.myglobelstate == Globelstate.state.start))
        {
            //AppFactory.instances.entrytab.GetComponentInChildren<Text>().text = "点击物品进行使用";
            AppFactory.instances.showpack(TagCmd.clickUseItem);
            AppFactory.instances.Todo(new Observer("hide"));
            AppFactory.instances.CancelInvoke("sinvoke");

        }
        else if ((Input.GetKeyDown(KeyCode.Tab) && opnion.myglobelstate == Globelstate.state.readPaper) || (Input.GetMouseButtonDown(1) && opnion.myglobelstate == Globelstate.state.readPaper) || (Input.GetKeyDown(KeyCode.Escape) && opnion.myglobelstate == Globelstate.state.readPaper)){

            if (scribeComponent.instance.exit == true) {
                scribeComponent.instance.re();
            
            }
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
            if (Vector3.Distance(this.transform.position, AppFactory.instances.GetbeUseObj().transform.position) >= 4f&& isHitChangeObj == true)
                AppFactory.instances.SetbeUseObj(null);

        }
        Ray o = main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
       // Debug.DrawRay(o.origin, o.direction, Color.black);
        if (Physics.Raycast(o, out hitpoint, 1.8f, 1))
        {//1.8

            GameObject hitGameObj = hitpoint.collider.gameObject;
            bool isActive = true;
            if(hitpoint.collider.tag == "cabinet") { 
                isActive = CabinetManagerComponent.instance.cabinetLengthTable[hitGameObj].isActive;
            }
            if (hitGameObj.layer == 0&&isHitChangeObj==true&&isActive)
            {


                a.intel();
                AppFactory.instances.SetbeUseObj(hitGameObj);
                isblink = true;

            }


            if (hitpoint.collider.tag == "bloomtable")
            {
                if (!AppFactory.instances.eventIsCanExcuteState(eventCmd.三张卡牌))
                {
                    if (AppFactory.instances.eventTodo(eventCmd.赌桌事件))
                    {

                        //middleLayer.Instance.canMove = false;
                        //middleLayer.Instance.MousePause();

                        //AppFactory.instances.closePackage(AppFactory.instances.entrytab);
                        hitpoint.collider.GetComponent<Onobjsession>().add();
                        AppFactory.instances.Todo(new Observer(Cmd.moveCamera, 4));
                
                        AppFactory.instances.changestate(Globelstate.state.load,true);
                        hitpoint.collider.GetComponent<BoxCollider>().enabled = false;
                    }
                }
            }
            if (ispost == true)
            {
                if ((Input.GetKeyDown(KeyCode.E) && AppFactory.instances.isopenpackage == true || Input.GetMouseButtonDown(1) && AppFactory.instances.isopenpackage == true) && opnion.myglobelstate == Globelstate.state.start)
                {
                    AppFactory.instances.closePackage();
                }
                else if ((Input.GetKeyDown(KeyCode.E) && AppFactory.instances.isopenpackage == false || Input.GetMouseButtonDown(0) && AppFactory.instances.isopenpackage == false) && opnion.myglobelstate == Globelstate.state.start)
             {

//                    AppFactory.instances.entrytab.GetComponentInChildren<Text>().text = "按tab开启物品栏";

                    Inventory inv = hitGameObj.GetComponent<Inventory>();
                    if (inv != null && hitpoint.collider.tag != "paint")
                        getItem(inv);
                    if (hitpoint.collider.tag == "card")
                    {
                        cardDeal(hitpoint.collider);

                    }

                    else if (hitpoint.collider.name == "tv")
                    {
                        if (AppFactory.instances.eventTodo(eventCmd.播放电视))
                        {
                            player.GetComponent<Animator>().SetTrigger("grag");
                            AppFactory.instances.Todo(new Observer(Cmd.playTv));

                        }
                    }

                    else if (hitpoint.collider.tag == "paint")
                    {

                        if (PaintModelComponent.instance.isCorrectConsequence() && PaintModelComponent.instance.isCompelete())
                        {

                            PaintModelComponent.instance.paintHave.GetComponent<Onobjsession>().add();
                        }
                        else
                        {

                            if (hitpoint.collider.name == "paint1" || hitpoint.collider.name == "paint2" || hitpoint.collider.name == "paint3")
                            {

                                // 正则表达式剔除非数字字符（不包含小数点.）
                                string str = Regex.Replace(hitpoint.collider.name, @"[^\d.\d]", "");
                                int index = int.Parse(str) - 1;
                                hitGameObj.SetActive(false);
                                PaintModelComponent.instance.paintbase[index].SetActive(true);
                                getItem(inv);
                                //    PaintModelComponent.instance.paintPoint[index]=0;
                            }

                            if (hitpoint.collider.name == "paint1_base" || hitpoint.collider.name == "paint2_base" || hitpoint.collider.name == "paint3_base")
                            {

                                useItem("物品");
                            }

                        }


                    }
                    else if (hitpoint.collider.tag == "cardBase")
                    {
                        useItem("卡牌");
                    }
                    else if (hitpoint.collider.tag == "cabinet")
                    {

                        if (CabinetManagerComponent.instance.cabinetLengthTable[hitGameObj].haveItem == null || CabinetManagerComponent.instance.cabinetLengthTable[hitGameObj].haveItem.Count == 0 || CabinetManagerComponent.instance.cabinetLengthTable[hitpoint.collider.gameObject].isPull == false)
                        {
                            if (CabinetManagerComponent.instance.cabinetLengthTable[hitGameObj].isProcess == false)
                                AppFactory.instances.viewTodo(new Observer(Cmd.CabineMove, hitGameObj));

                        }
                    }
                    else if (hitpoint.collider.tag == "speaker")
                    {

                        if (isSpeakerPlaying == false)
                        {
                            hitpoint.collider.GetComponent<Animator>().SetBool("play", true);
                            hitpoint.collider.GetComponent<Onobjsession>().add();

                        }
                        else
                        {
                            Audomanage.instance.OnPlay("speakerClose", hitGameObj.transform);
                            hitpoint.collider.GetComponent<Animator>().SetBool("play", false);
                            AppFactory.instances.viewTodo(new Observer(Cmd.dialogClear));

                        }
                        isSpeakerPlaying = !isSpeakerPlaying;
                    }
                    else if (hitpoint.collider.tag == "cubeMove")
                    {
                        useItem("物品");
                    }
                    else if (hitpoint.collider.tag == "ladder"&&!AppFactory.instances.eventIsCanExcuteState(eventCmd.打开地窖))
                    {
                        LadderComponent.instance.MoveByLadder();
                        //todo

                    }
                    else if (hitpoint.collider.tag == "paper") {
                        hitpoint.collider.GetComponent<paperComponent>().OnPaperShow();
                       // scribeChange.instance.A();
                    }

                }

            }

        }

    }


    private void useItem(string itemName = "物品")
    {
        //isHitChangeObj = false;
        AppFactory.instances.closePackage();
     
        //AppFactory.instances.entrytab.GetComponentInChildren<Text>().text = "点击" + itemName + "进行使用";
        AppFactory.instances.showpack("点击" + itemName + "进行使用");
        return;

    }
    public void cardDeal(Collider t)
    {
        if (AppFactory.instances.eventTodo(eventCmd.第一张卡牌))
        {
            onecardevent.GetComponent<Onobjsession>().add();

        }

        if ((t.name == "mycard0" || t.name == "mycard1" || t.name == "mycard2") && AppFactory.instances.eventTodo(eventCmd.不能回收手牌))
        {

            player.GetComponent<Animator>().SetTrigger("grag");
            BloomProxy.instance().gameObject.GetComponent<Onobjsession>().add();
        }

        if (PackProxy.instances().TryGeGoodtModel(1) == true && PackProxy.instances().TryGeGoodtModel(2) == true && PackProxy.instances().TryGeGoodtModel(3) == true)
        {
            if (AppFactory.instances.eventTodo(eventCmd.三张卡牌))
            {
                threecardevent.GetComponent<Onobjsession>().add();
                table.SetActive(true);
                Audomanage.instance.OnPlay("duang");
            }
        }
    }
    private void getItem(Inventory inv)
    {

        if (inv.cabinet == null || CabinetManagerComponent.instance.cabinetLengthTable[inv.cabinet].isPull == true)
        {
            if (inv.cabinet != null)
            {
                CabinetManagerComponent.instance.cabinetLengthTable[inv.cabinet].haveItem.Remove((int)inv.id);
            }
            AppFactory.instances.Todo(new Observer("AddGoodscommand", (int)inv.id, inv.GetHashCode()));
            if ((int)inv.id != 0)
            {
                player.GetComponent<Animator>().SetTrigger("grag");
                inv.gameObject.SetActive(false);
            }
        }
    
    }


    public bool IsHit()
    {
        RaycastHit hitpoint;

        Ray o = main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        Debug.DrawRay(o.origin, o.direction, Color.black);
       
        return (Physics.Raycast(o, out hitpoint, 1.8f, 1));


    }

    public void setPoSition(Transform T) {

        this.gameObject.transform.position = T.position;
        this.gameObject.transform.rotation = T.rotation;
    }

    public float getPlayerHeight() {

        return this.gameObject.transform.position.y;
    
    }
    //(Collision collision)
    //{

    //    {

    //        Debug.Log("111");
    //    }

    //}
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "steelPanel" && LadderComponent.instance.isUp == false)
    //    {

    //        LadderComponent.instance.isUp = true;
    //    }

    //    else if (other.tag == "steelUpPanel" && LadderComponent.instance.isUp == true)
    //    {

    //        LadderComponent.instance.isUp = false;
    //    }
    //}

}
