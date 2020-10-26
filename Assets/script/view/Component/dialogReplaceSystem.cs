using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class dialogReplaceSystem : MonoBehaviour
{
    public static dialogReplaceSystem instance;

    public ReplaceNextDiaglogData jqk;


    void Awake()
    {
        instance = this;
        this.initNextDialogData();
    }


    void initNextDialogData()
    {
        jqk.initDiaglog();

    }


    public void ReplaceJqk(int index, ReplaceNextDiaglogData.SessionAddIndex sai)
    {
        jqk.replace(index,sai);

    }

}








