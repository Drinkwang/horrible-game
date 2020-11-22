using System;
using System.Collections;
using Assets.script.Utils;
using System.Collections.Generic;
using UnityEngine;
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
        if (beUseItemId >= 10 && beUseItemId <= 12)
        {
            if (beFuncObj.name == "paint1_base" || beFuncObj.name == "paint2_base" || beFuncObj.name == "paint3_base")
            {
                int beFuncId = beUseItemId - 9;
                GameObject beUsePaint = AppFactory.instances.postObj.paint[beFuncId - 1];
                GameObject paint = AppFactory.instances.postObj.paint[CUtil.GetResidueNum(beFuncObj.name) - 1];
                Vector3 tempV3 = paint.transform.position;
                paint.transform.position = beUsePaint.transform.position;
                beUsePaint.transform.position = tempV3;
                beUsePaint.SetActive(true);
                beFuncObj.SetActive(false);


                GameObject beUsePaintBase = AppFactory.instances.postObj.paintbase[beFuncId - 1];
                GameObject paintBase = AppFactory.instances.postObj.paintbase[CUtil.GetResidueNum(beFuncObj.name) - 1];

                tempV3 = paintBase.transform.position;
                paintBase.transform.position = beUsePaintBase.transform.position;
                beUsePaintBase.transform.position = tempV3;
                AppFactory.instances.generalPaintBase();
                AppFactory.instances.Todo(new Observer(Cmd.consumeItem, beUseItemId));
                AppFactory.instances.closePackage(null, false);
                

            }
        }
        if (beUseItemId >= 1 && beUseItemId <= 3)
        {
            if (beFuncObj.name == "0" || beFuncObj.name == "1" || beFuncObj.name == "2")
            {
                BloomModel Tempmodel = BloomModel.instance();
                int index = int.Parse(beFuncObj.name);
                if (index == 0)
                {
                    index = 1;
                }
                else if (index == 1)
                {
                    index = 0;
                }
                Tempmodel.myback[index].SetActive(true);
                Tempmodel.cardBorad[index].layer = 1;
                Tempmodel.myback[index].GetComponent<MeshRenderer>().material = Resources.Load<Material>(CUtil.idToCardBackString(beUseItemId+10));
                AppFactory.instances.Todo(new Observer(Cmd.consumeItem, beUseItemId));
                AppFactory.instances.closePackage(null, false);
                BloomModel.instance().bloomData.currenceUseCardNum++;
                BloomModel.instance().bloomData.MyTablecards[index] = BloomModel.instance().bloomData.deckHold[beUseItemId-1];
                
                if (BloomModel.instance().bloomData.currenceUseCardNum == 3) {
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

        GameObject selectitemMenu = GameObject.FindGameObjectWithTag("itemchosen").transform.GetChild(0).gameObject;
        selectitemMenu.SetActive(false);
    }

}