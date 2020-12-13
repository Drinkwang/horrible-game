
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class dialogReplaceSystem : MonoBehaviour
{
    public static dialogReplaceSystem instance;

    public ReplaceNextDiaglogData jqk;

    public ReplaceNextDiaglogData win;
    public ReplaceNextDiaglogData lost;

    public ReplaceNextDiaglogData draw;
    public ReplaceNextDiaglogData audioMerge;


    void Awake()
    {
        instance = this;
        this.initNextDialogData();
    }


    void initNextDialogData()
    {
        jqk.initDiaglog();
        win.initDiaglog();
        lost.initDiaglog();
        draw.initDiaglog();
        audioMerge.initDiaglog();

    }


    public void ReplaceJqk(int index, ReplaceNextDiaglogData.SessionAddIndex sai)
    {
        jqk.replace(index,sai);

    }

    public void ReplaceWin(ReplaceNextDiaglogData.SessionAddIndex sai){
        int index;
        index=(int)(Random.Range(0,win.MySingleD.Length));
        win.replace(index,sai);
    }

    public void ReplaceLose(ReplaceNextDiaglogData.SessionAddIndex sai)
    {
        int index;
        index= (int)(Random.Range(0,lost.MySingleD.Length));
        lost.replace(index,sai);
    }


    public void ReplaceDraw(ReplaceNextDiaglogData.SessionAddIndex sai){
        int index;
        index= (int)(Random.Range(0,draw.MySingleD.Length));
        draw.replace(index,sai);
    }


    public void ReplaceAudioMerge(ReplaceNextDiaglogData.SessionAddIndex sai,List<int> Point){

        audioMerge.mergeAudio(sai,Point);
    }


}








