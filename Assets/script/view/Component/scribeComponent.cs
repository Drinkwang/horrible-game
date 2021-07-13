using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class scribeComponent : MonoBehaviour
{
    public Text top;
    public Text center;
    public Text inscribe;
    public GameObject exit;
    private bool isExit;

    //public Color topC, centerC, insribeC;

    public static scribeComponent instance;
    void Awake()
    {
        if (instance == null)
            instance = this;
    }
    // Use this for initialization

    public void re()
    {
        if (isExit == true) {

            transform.GetChild(0).gameObject.SetActive(false);
            Time.timeScale = 1;
            middleLayer.Instance.MouseRun();
            OpnionProxy.instances().setState(Globelstate.state.start);

        }

    }
    internal void changeM(scriptmodel body)
    {
        transform.GetChild(0).gameObject.SetActive(true);
        //  Debug.Log("hekk");
        top.text = body.top;
        center.text = body.center;
        inscribe.text = body.inscribe;

        if (body.centerColor!=null) {
            center.color = body.centerColor;
        }
        if (body.inscribeColor != null) {
            inscribe.color = body.inscribeColor;
        }
        if (body.topColor != null) {
            top.color = body.topColor;
        }
        if (body.paper.isExit == true)
        {
            isExit = body.paper.isExit;
            exit.SetActive(true);
        }
        else {

            exit.SetActive(false);
        }
        //    body

        middleLayer.Instance.MousePause();
    //    Time.timeScale = 0;
        OpnionProxy.instances().setState(Globelstate.state.readPaper);
        
    }
}
