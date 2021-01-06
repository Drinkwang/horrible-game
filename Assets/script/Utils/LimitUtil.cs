

using System;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections;
using UnityEngine;


public static class LimitUtil
{   
    public static float value =300;
    public static bool isOverScreenPos(float mosX, float mosY)
    {
        Vector2 pos;
        if (AppFactory.instances.GetbeUseObj() != null)
        {
            pos = Camera.main.WorldToScreenPoint(AppFactory.instances.GetbeUseObj().transform.position);
            //Debug.Log("sizeX:" + AppFactory.instances.GetbeUseObj().GetComponent<Collider>().bounds.size.x+ "sizeY:" + AppFactory.instances.GetbeUseObj().GetComponent<Collider>().bounds.size.y+ "sizeZ:" + AppFactory.instances.GetbeUseObj().GetComponent<Collider>().bounds.size.z);
            float dis = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(mosY - pos.y), 2) + Mathf.Pow(Mathf.Abs(mosX - pos.x), 2));
            return (dis > value) ? true : false;
        }
        //Camera.main.WorldToScreenPoint(DragObj.transform.position).x, Camera.main.WorldToScreenPoint(DragObj.transform.position).y
        return true;

    }
}
   
       




