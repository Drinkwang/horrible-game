using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class scribeComponent : MonoBehaviour
{
    public Text top;
    public Text center;
    public Text inscribe;
    //public Color topC, centerC, insribeC;

    public static scribeComponent instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Use this for initialization

    public  void re()
    {
        transform.GetChild(0).gameObject.SetActive(false);
        Time.timeScale = 1;
        middleLayer.Instance.MouseRun();
    }
    internal void changeM(scriptmodel body)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        //  Debug.Log("hekk");
        top.text = body.top;
        center.text = body.center;
        inscribe.text = body.inscribe;
        ///below text present color change, maybe add later;
       /* top.color= color1;
        center.color = body[1];
        inscribe.color = body[2];*/
        middleLayer.Instance.MousePause();
        Time.timeScale = 0;
        
    }
}
