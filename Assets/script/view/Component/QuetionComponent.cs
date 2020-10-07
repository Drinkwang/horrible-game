using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuetionComponent : MonoBehaviour
{
    private event Action YesBefunction;
    private event Action NoBefunction;
    private static QuetionComponent instances;
    public  static QuetionComponent instance() {

        return instances;

    }


    public Button yes;
    public Button no;
    public Text text;
    public bool isShowBool;
    // Start is called before the first frame update
    public void Awake()
    {

        if (instances == null)
            instances = this;

        yes.onClick.AddListener(delegate ()
        {
            Yes();
        });
        no.onClick.AddListener(delegate ()
        {
            No();
        });
    }



    /// <summary>
    /// Returns a value to an 'oncallback' method interpolated between the supplied 'from' and 'to' values for application as desired.  Requires an 'onupdate' callback that accepts the same type as the supplied 'from' and 'to' properties.
    /// </summary>

    /// <param name="yesButton">
    /// A <see cref="Button"/> for a reference to the GameObject that holds the "onupdate" method.
    /// </param>
    /// <param name="noButton">
    /// A <see cref="Button"/> for a reference to the GameObject that holds the "onupdate" method.
    /// </param>


    public void changeButtonStyle(Observer o)
    {
        GameObject target =(GameObject)o.body;
            
        Hashtable args =(Hashtable)o.date;


        Launch(target, args);

    }


    private void Launch(GameObject target,Hashtable args) {
        if(args["yesButton"]!=null)
            yes = (Button)args["yesButton"];
        else if (args["noButton"] != null)
            no = (Button)args["noButton"];
        
    }
    public void ChangeQuetion(string t)
    {
        text.text = t;
    }


    public void ChangeYesBefunction(Action t) {
        YesBefunction = t;
    }
    public void ChangeNoBefunction(Action t) {
        NoBefunction = t;

    }
    public void show(Observer o) {
        if ((bool)o.body == true)
        {
             text.gameObject.transform.parent.gameObject.SetActive(true);
        }
        else if ((bool)o.body == false) {
            text.gameObject.transform.parent.gameObject.SetActive(false);

        }

    }


    public void Yes() {
        isShowBool = true;
        ShowResult();
    }
    public void No() {
        isShowBool = false;
        ShowResult();
    }

    private void ShowResult() {
        if(isShowBool==true)
            YesBefunction();
        else
            NoBefunction();


    }

}
