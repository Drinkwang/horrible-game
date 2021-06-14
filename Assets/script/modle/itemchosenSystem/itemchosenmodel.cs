using System;
using System.Collections;
using Assets.script.Utils;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
//该对象定义了所有物品
[Serializable]
public class itemchosenmodel : Basemodel {
    public string button_num;
    public Befunction thisb;
    public itemchosenmodel()
    {
    }

    public itemchosenmodel(int id, Befunction temp) : base(id)
    {
        
        thisb = temp;
        button_num = temp.t;
     
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
}



public class newBehaiver {
    internal string t;
    public Action A;
    public newBehaiver(string temp)
    {
        t = temp;
    }
    internal void runa(int res = 0, List<int> resG = null)
    {

            A();
    }
}


[System.Serializable]
public class /*  */Befunction : MonoBehaviour
{
    internal string t;
    public Action A;
    public object calledObj;
    public ReplaceNextDiaglogData.SessionAddIndex sai;
    //  public Hashtable hashtable;

    public Action<int, List<int>> _A;
    public Befunction(string temp)
    {
        t = temp;
    }

    internal void runa(int res = 0, List<int> resG = null)
    {
        //  Debug.Log(t + "isruning");
        if ((res != 0 || (resG!=null&&resG.Count>0))&&_A!=null)
            _A(res, resG);
        else
            A();
    }

    public void checkitem()
    {
        string[] temp = this.t.Split(' ');
        Debug.Log("你已经检查了物品" + temp[1] + temp[2]);


    }
    public void useritem()
    {
        string[] temp = this.t.Split(' ');
        Debug.Log("你已经使用了物品" + temp[1] + temp[2]);
        int beUseItemId = int.Parse(temp[2]);
        GameObject beFuncObj = AppFactory.instances.GetbeUseObj();
        if (beFuncObj != null)
        {
            Debug.Log("作用对象" + beFuncObj);

        }
        else if (beFuncObj == null)
        {

            return;
        }
        if (beUseItemId >= (int)GoodType.世界名画1 && beUseItemId <= (int)GoodType.刚画好的油画)
        {
            if (beFuncObj.name == "paint1_base" || beFuncObj.name == "paint2_base" || beFuncObj.name == "paint3_base")
            {
                int beFuncId = beUseItemId - 9;
                GameObject beUsePaint = PaintModelComponent.instance.paint[beFuncId - 1];
              
                GameObject paint = PaintModelComponent.instance.paint[CUtil.GetResidueNum(beFuncObj.name) - 1];
                Vector3 tempV3 = paint.transform.position;
                paint.transform.position = beUsePaint.transform.position;
                beUsePaint.transform.position = tempV3;
                beUsePaint.SetActive(true);
                beFuncObj.SetActive(false);


                GameObject beUsePaintBase = PaintModelComponent.instance.paintbase[beFuncId - 1];
                int beUsePaintPoint= 
                  PaintModelComponent.instance.paintPoint[beFuncId - 1] ;

                GameObject paintBase = PaintModelComponent.instance.paintbase[CUtil.GetResidueNum(beFuncObj.name) - 1];
                int paintPoint = PaintModelComponent.instance.paintPoint[CUtil.GetResidueNum(beFuncObj.name) - 1];

                PaintModelComponent.instance.paintPoint[beFuncId - 1] = paintPoint;
                PaintModelComponent.instance.paintPoint[CUtil.GetResidueNum(beFuncObj.name) - 1]=beUsePaintPoint;


                tempV3 = paintBase.transform.position;
                paintBase.transform.position = beUsePaintBase.transform.position;
                beUsePaintBase.transform.position = tempV3;


                PaintModelComponent.instance.generalPaintBase();
                PaintModelComponent.instance.settlement();
                AppFactory.instances.Todo(new Observer(Cmd.consumeItem, beUseItemId, beUsePaint.GetComponent<Inventory>().GetHashCode()));
                AppFactory.instances.closePackage(false);
                

            }
        }
        if (beUseItemId >= (int)GoodType.J && beUseItemId <= (int)GoodType.K)
        {
            if (beFuncObj.name == "cardBase0" || beFuncObj.name == "cardBase1" || beFuncObj.name == "cardBase2")
            {
                BloomModel Tempmodel = BloomModel.instance();
                //beFuncObj.name.("cardBase")
                int index = int.Parse(System.Text.RegularExpressions.Regex.Replace(beFuncObj.name, @"[^0-9]+", ""));

                Tempmodel.myback[index].SetActive(true);
                Tempmodel.cardBorad[index].layer = 1;
                //Tempmodel.myback[index].GetComponent<MeshRenderer>().material = Resources.Load<Material>(CUtil.idToCardBackString(beUseItemId+10));
                AppFactory.instances.Todo(new Observer(Cmd.consumeItem, beUseItemId));
                AppFactory.instances.closePackage( false);
                BloomModel.instance().currenceUseCardNum++;
                BloomModel.instance().myback[index].GetComponent<CardBase>().SetData(beUseItemId + 10, true);
                if (BloomModel.instance().currenceUseCardNum == 3)
                {
                    middleLayer.Instance.canMove = false;
                    middleLayer.Instance.MousePause();
                    AppFactory.instances.Todo(new Observer(Cmd.moveCamera, 4));
                    AppFactory.instances.raceEvent.GetComponent<Onobjsession>().add();

                }
                //if (AppFactory.instances.eventTodo("琳的记忆")) {

                //    AppFactory.instances.womanLin.SetActive(true);
                //  
                // AppFactory.instances.womanLin.GetComponent<Onobjsession>().add();

                //}
            }
        }
        else if (beUseItemId == (int)GoodType.撬棍) {
            if (beFuncObj.name == "PCube-move")
            {
                AppFactory.instances.Todo(new Observer(Cmd.consumeItem, beUseItemId));

                AppFactory.instances.changestate(Globelstate.state.load,true);

                AppFactory.instances.Todo(new Observer(Cmd.moveCamera, 5));
                crowDragComponent.instance.OnCrowAni() ;
 
            }
        }

        GameObject selectitemMenu = GameObject.FindGameObjectWithTag("itemchosen").transform.GetChild(0).gameObject;
        selectitemMenu.SetActive(false);
    }





}