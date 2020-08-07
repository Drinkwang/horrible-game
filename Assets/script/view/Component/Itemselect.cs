using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Itemselect : MonoBehaviour {
    public static Itemselect instance;
    public GameObject mychild;
    public void Awake()
    {
        instance = this;
        mychild = this.transform.GetChild(0).gameObject;
    }
    // Use this for initialization
    public void hide () {
        this.transform.GetChild(0).gameObject.SetActive(false);		
	}

    // Update is called once per frame
    public void show(List<itemchosenmodel> temp)
    {
        this.gameObject.SetActive(true);
        foreach (Transform t in mychild.transform)
        {//print (t.name);
            Destroy(t.gameObject);
        }
        for (int i=0;i<temp.Count;i++)
        {
          GameObject t=  Instantiate((GameObject)Resources.Load("itemchosen"),mychild.transform);
            
            t.transform.SetParent(mychild.transform);
            t.GetComponent<selectitem>().Model = temp[i];
            t.GetComponentInChildren<Text>().text = t.GetComponent<selectitem>().Model.button_num.Split(' ')[0];
           }
    }



       
 }


