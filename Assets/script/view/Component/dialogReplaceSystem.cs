
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class dialogReplaceSystem : MonoBehaviour
{
    public static dialogReplaceSystem instance;

    public ReplaceNextDiaglogData jqk;

    public ReplaceNextDiaglogData bossWin;
    public ReplaceNextDiaglogData bossLost;

    public ReplaceNextDiaglogData draw;
    public ReplaceNextDiaglogData audioMerge;

    public ReplaceNextDiaglogData anywin2;
    public ReplaceNextDiaglogData anyDraw2;
    //每次加入新的替换系统，需要在initNextDialogData里面进行初始化

    void Awake()
    {
        instance = this;
        this.initNextDialogData();
    }


    void initNextDialogData()
    {
        jqk.initDiaglog();
        bossWin.initDiaglog();
        bossLost.initDiaglog();
        draw.initDiaglog();
        audioMerge.initDiaglog();
        anywin2.initDiaglog();

    }


    public void ReplaceJqk(int index, ReplaceNextDiaglogData.SessionAddIndex sai)
    {
        jqk.replace(index,sai);

    }

    public void ReplaceLose(ReplaceNextDiaglogData.SessionAddIndex sai){
        int index;
        index=(int)(Random.Range(0, bossWin.MySingleD.Length));
        bossWin.replace(index,sai);
    }

    public void ReplaceWin(ReplaceNextDiaglogData.SessionAddIndex sai)
    {
        int index;
        index= (int)(Random.Range(0,bossLost.MySingleD.Length));
        bossLost.replace(index,sai);
    }


    public void ReplaceDraw(ReplaceNextDiaglogData.SessionAddIndex sai){
        int index;
        index= (int)(Random.Range(0,draw.MySingleD.Length));
        draw.replace(index,sai);
    }


    public void ReplaceAudioMerge(ReplaceNextDiaglogData.SessionAddIndex sai,List<int> Point){

        audioMerge.mergeAudio(sai,Point);
    }

    public void ReplaceNextDiaglog(ReplaceNextDiaglogData.SessionAddIndex sai,int count)
    {
        int index;
        index = (int)(Random.Range(0, anywin2.MySingleD.Length));
        anywin2.replace(index, sai);
       AppFactory.instances.Todo(new Observer(Cmd.dialogRemove, sai, count));
    }

}








