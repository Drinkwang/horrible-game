using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetManagerComponent : MonoBehaviour
{

    public static CabinetManagerComponent instance;
    public float[] lengths;
    public GameObject[] cabinets;
    public string[] canUseHave;

    public Dictionary<GameObject, cabineValue> cabinetLengthTable;


    // Start is called before the first frame update
    void Start()
    {
        
    }
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

            }
            else
            {
                length = -length;
                //StopCoroutine("moveEnd");
                cabinetLengthTable[t].isPull = false;
            }
            cabinetLengthTable[t].isProcess =true;
            //isProcess[t] = true; ;


   

            iTween.MoveTo(t, iTween.Hash("z", t.transform.position.z + length, "time", 1, "oncomplete", "moveComplete", "oncompleteparams", t, "oncompletetarget",this.gameObject));
      

        }
    }

    public void moveComplete(GameObject t) {
        cabinetLengthTable[t].isProcess = false;
        StartCoroutine("moveEnd",t);
        
    }

    public IEnumerator moveEnd(GameObject t)
    {
        if (cabinetLengthTable[t].isPull == true)
        {
            yield return new WaitForSeconds(5f);
            if (cabinetLengthTable[t].isPull == true)
            {
                float length = cabinetLengthTable[t].values;


                iTween.MoveTo(t, iTween.Hash("z", t.transform.position.z + length, "time", 1));
                cabinetLengthTable[t].isPull = false;
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
    public List<int> haveItem;

}
