using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetManagerComponent : MonoBehaviour
{

    public static CabinetManagerComponent instance;
    public float[] lengths;
    public bool[] isLock=new bool[6];
    public GameObject[] cabinets;


    public Dictionary<GameObject, cabineValue> cabinetLengthTable;


    void Awake()
    {
        instance = this;
        cabinetLengthTable = new Dictionary<GameObject, cabineValue>();

        for (int i = 0; i < cabinets.Length; i++)
        {

            cabineValue tempBAndF = new cabineValue();
            tempBAndF.values = lengths[i];
            tempBAndF.isPull = false;
            tempBAndF.isProcess = false;
            tempBAndF.isActive = true;
            cabinetLengthTable.Add( cabinets[i], tempBAndF);
       
         
        }  


    }

    public void shake(object t) {
        GameObject temp = t as GameObject;
        Debug.Log(cabinetLengthTable[temp]);
      
    }


    public void move(object temp,object isPull=null) {
    
            GameObject t = temp as GameObject;
        if (cabinetLengthTable[t].isProcess == false)
        {
            if (isPull != null)
            {
                cabinetLengthTable[t].isPull = !(bool)isPull;
            }
            float length = -cabinetLengthTable[t].values;
            if (cabinetLengthTable[t].isPull == false)
            {
                cabinetLengthTable[t].isPull = true;


                Audomanage.instance.OnPlay("cabinetOpen", t.transform);

            }
            else
            {
                length = -length;
                //StopCoroutine("moveEnd");
                Audomanage.instance.OnPlay("cabinetClose", t.transform);
                cabinetLengthTable[t].isPull = false;
            }
            cabinetLengthTable[t].isProcess =true;
            //t.layer = 1;
            cabinetLengthTable[t].isActive = false;
            //isProcess[t] = true; ;


            iTween.MoveTo(t, iTween.Hash("z", t.transform.position.z + length, "time", 2, "oncomplete", "moveComplete", "oncompleteparams", t, "oncompletetarget",this.gameObject));
      

        }
    }

    public void moveComplete(GameObject t) {
        cabinetLengthTable[t].isProcess = false;
        cabinetLengthTable[t].isActive = true;
        // t.layer = 0;
        if (cabinetLengthTable[t].isPull != false)
        {
            StartCoroutine("moveEnd", t);
            if (cabinetLengthTable[t].haveItem != null && cabinetLengthTable[t].haveItem.Count >0)
            {
                //       t.layer = 1;
                cabinetLengthTable[t].isActive = false;
                //cabinetLengthTable[t].isProcess = true;
            }
        }
        
    }

    public IEnumerator moveEnd(GameObject t)
    {
        if (cabinetLengthTable[t].isPull == true&& cabinetLengthTable[t].isProcess == false)
        {
            yield return new WaitForSeconds(5f);
            if (cabinetLengthTable[t].isPull == true && cabinetLengthTable[t].isProcess == false)
            {
                //float length = cabinetLengthTable[t].values;
                //cabinetLengthTable[t].isPull = false;
                //cabinetLengthTable[t].isProcess = true;
                //cabinetLengthTable[t].isActive = false;
                //iTween.MoveTo(t, iTween.Hash("z", t.transform.position.z + length, "time", 1 ,"oncomplete", "moveComplete", "oncompleteparams", t, "oncompletetarget", this.gameObject));
                move(t,false);
            }
        }
    }

    public void testTodo(int i,bool b)
    {
        move(cabinets[i], b);
        //throw new System.NotImplementedException();
    }
}

public class cabineValue{
    public float values;
    public bool isPull;
    public bool isProcess;
    public bool isActive;
    public List<int> haveItem;

}
