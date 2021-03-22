using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CabinetManagerComponent : MonoBehaviour
{

    public static CabinetManagerComponent instance;
    public float[] lengths;
    public GameObject[] cabinets;
    public bool[] isPull;
    public Dictionary<GameObject, BoolAndFloat> cabinetLengthTable;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void Awake()
    {
        instance = this;
        cabinetLengthTable = new Dictionary<GameObject, BoolAndFloat>();
        isPull = new bool[cabinets.Length];
        for (int i = 0; i < cabinets.Length; i++)
        {

            BoolAndFloat tempBAndF = new BoolAndFloat();
            tempBAndF.values = lengths[i];
            tempBAndF.isPull = isPull[i];

            cabinetLengthTable.Add( cabinets[i], tempBAndF);
            isPull[i] = false;
        }  


    }

    public void shake(object t) {
        GameObject temp = t as GameObject;
        Debug.Log(cabinetLengthTable[temp]);
      
    }


    public void move(object temp,object isPull=null) {

        GameObject t = temp as GameObject;
        if (isPull != null)
        {
            cabinetLengthTable[t].isPull = !(bool)isPull;
        }
        float length = -cabinetLengthTable[t].values;
        if (cabinetLengthTable[t].isPull == false)
        {
            cabinetLengthTable[t].isPull = true;
   
        }
        else {
            length = -length;
            StopCoroutine("moveEnd");
            cabinetLengthTable[t].isPull = false;
        }


  

        //cabinets.index;

        iTween.MoveTo(t, iTween.Hash("z", t.transform.position.z+length, "time", 1));
        //if(isOpen==true)
          // 

    }

    public IEnumerator moveEnd(GameObject t)
    {
        if (cabinetLengthTable[t].isPull == true)
        {
            yield return new WaitForSeconds(0.5f);
            if (cabinetLengthTable[t].isPull == true)
            {
                float length = cabinetLengthTable[t].values;


                iTween.MoveTo(t, iTween.Hash("z", length, "time", 1));
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

public class BoolAndFloat{
    public float values;
    public bool isPull;


}
