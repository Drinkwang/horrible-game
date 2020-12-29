using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class dialogComponent : MonoBehaviour
{
    public static dialogComponent instance;
    private List<SingledialogText> dialogues;
    private Text saying;
    private static int num = 0;
    private AudioSource lastaudio;



    void Awake()
    {
        instance = this;
        saying = this.GetComponent<Text>();

    }


    void Start()
    {


    }

    public void add()
    {
        Audomanage.instance.Stop();
        dialogues = Sayingproxy.instances().returnLs();


        //	a[a[0]];

    }
    public void clear()
    {

        Audomanage.instance.StopSoundEffect(lastaudio);
        Sayingproxy.instances().clear();

    }
    void Update()
    {
    }

    public void Replace(SingledialogText temp,Onobjsession oncession,int index)
    {
        //  Audomanage.instance.Stop();
        // SingledialogText D = dialogues[1];
        temp.Assignment(oncession,index);
         //dialogues[1].Assignment(tempDialog);
        //D.ChineseAC=tempDialog.ChineseAC;
        //D.ChineseVersion

    }


    public void ReplaceAll(List<SingledialogText> tempDialog)
    {
        //  Audomanage.instance.Stop();a 
        //  Audomanage.instance.Stop();a 
        for (int i = 0; i < tempDialog.Count; i++)
        {
            SingledialogText temp = tempDialog[i];
            temp.talkobj = dialogues[0].talkobj;
        }

        tempDialog.AddRange(dialogues);
        dialogues = tempDialog;

    }

    public void todo(Befunction t = null)
    {
        if (dialogues.Count != 0)
        {
            if (dialogues[0].t != null)
            {
                if (dialogues[0].Sequence == SingledialogText.executeSequence.RunInDiaglogEnd)
                    t = dialogues[0].t;
                else if (dialogues[0].Sequence == SingledialogText.executeSequence.RunInDiaglogBegan)
                {
                    dialogues[0].t.runa(dialogues[0].value, dialogues[0].values);
                    t = new Befunction("who know");
                }
                else{
                    t = dialogues[0].t;
                }
            }
            else t = new Befunction("who know");/*  */
            t.A += tempFunction;
            t._A += tempFunction2;

            

            if (AppFactory.instances.mylanguage == Globelstate.language.china)
            {
                textchange(dialogues[0].ChineseVersion.ToString());
                if (dialogues[0].ChineseAC == null)
                {
                    lastaudio = Audomanage.instance.OnPlay(0.8f, null, dialogues[0].talkobj.transform, t, dialogues[0].value, dialogues[0].values);
                }
                else
                    lastaudio = Audomanage.instance.OnPlay(0.8f, dialogues[0].ChineseAC, dialogues[0].talkobj.transform, t, dialogues[0].value, dialogues[0].values);
            }
            else if (AppFactory.instances.mylanguage == Globelstate.language.english)
            {
                textchange(dialogues[0].EnglishVersion.ToString());
                if (dialogues[0].EnglishAC == null)
                    lastaudio = Audomanage.instance.OnPlay(0.8f, null, dialogues[0].talkobj.transform, t, dialogues[0].value, dialogues[0].values);
                else
                    lastaudio = Audomanage.instance.OnPlay(0.8f, dialogues[0].EnglishAC, dialogues[0].talkobj.transform, t, dialogues[0].value, dialogues[0].values);
            }
            else if (AppFactory.instances.mylanguage == Globelstate.language.japanense)
            {
                textchange(dialogues[0].JapanVersion.ToString());
                if (dialogues[0].JapanAC == null)
                    lastaudio = Audomanage.instance.OnPlay(0.8f, null, dialogues[0].talkobj.transform, t, dialogues[0].value, dialogues[0].values);
                else
                    lastaudio = Audomanage.instance.OnPlay(0.8f, dialogues[0].JapanAC, dialogues[0].talkobj.transform, t, dialogues[0].value, dialogues[0].values);
            }
            dialogues.RemoveAt(0);

        }
        else
        {
            saying.text = "";

        }


    }

    void textchange(string a)
    {
        saying.text = a;
        num++;
    }
    void tempFunction()
    {
        //   if (Sayingproxy.instances().returnLs().Count <= 0)
        //      AppFactory.instances.changePost(true);
        tempFunction2();

    }
    void tempFunction2(int res = 0, List<int> values = null)
    {
        //   if (Sayingproxy.instances().returnLs().Count <= 0)
        //      AppFactory.instances.changePost(true);
        AppFactory.instances.viewTodo(new Observer(Cmd.dialog));

    }
}







