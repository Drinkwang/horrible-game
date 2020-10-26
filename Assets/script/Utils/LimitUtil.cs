

using System;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections;
using UnityEngine;


public static class LimitUtil
{
    public static bool isOverScreenPos(float mosX, float mosY, float value)
    {
        Vector2 pos;
        if (AppFactory.instances.GetbeUseObj() != null)
        {
            pos = Camera.main.WorldToScreenPoint(AppFactory.instances.GetbeUseObj().transform.position);
            float dis = Mathf.Sqrt(Mathf.Pow(Mathf.Abs(mosY - pos.y), 2) + Mathf.Pow(Mathf.Abs(mosX - pos.x), 2));
            return (dis > value) ? true : false;
        }
        //Camera.main.WorldToScreenPoint(DragObj.transform.position).x, Camera.main.WorldToScreenPoint(DragObj.transform.position).y
        return true;

    }
}
   
       




