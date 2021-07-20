using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using Assets.script.Utils;

public class dialogComponent : MonoBehaviour
{
    public static dialogComponent instance;
    private List<SingledialogText> dialogues;
    private Text saying;
    private AudioSource lastaudio;
    private Befunction tempBefunction;


    void Awake()
    {
        instance = this;
        saying = this.GetComponent<Text>();
        tempBefunction=this.gameObject.AddComponent<Befunction>();

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
        saying.text = "";
        Audomanage.instance.StopSoundEffect(lastaudio);
        Sayingproxy.instances().clear();
      //  Sayingproxy.instances().hashIdAndIndex.index = 0;

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

    public void changeFontSize(int fontSize,bool bestFit) {

        saying.resizeTextForBestFit = bestFit;
        saying.fontSize = fontSize;
    }

    public void todo(Befunction t=null)
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
                    tempBefunction.clearDelegate();
                    t = tempBefunction;

                }
                else
                {
                    t = dialogues[0].t;


                }
            }
            else {
                tempBefunction.clearDelegate();
                t = tempBefunction;

            }
            t.A += tempFunction;
            t._A += tempFunction2;

            OpnionProxy opnion=OpnionProxy.instances();

            if (opnion.mylanguage == languageType.china)
            {
                textchange(dialogues[0].ChineseVersion.ToString());
                if (dialogues[0].ChineseAC == null)
                {
                    lastaudio = Audomanage.instance.OnPlay(0.8f, null, dialogues[0].talkobj.transform, t, dialogues[0].value, dialogues[0].values,dialogues[0].delay);
                }
                else
                    lastaudio = Audomanage.instance.OnPlay(0.8f, dialogues[0].ChineseAC, dialogues[0].talkobj.transform, t, dialogues[0].value, dialogues[0].values, dialogues[0].delay);
            }
            else if (opnion.mylanguage == languageType.english)
            {
                textchange(dialogues[0].EnglishVersion.ToString());
                if (dialogues[0].EnglishAC == null)
                    lastaudio = Audomanage.instance.OnPlay(0.8f, null, dialogues[0].talkobj.transform, t, dialogues[0].value, dialogues[0].values, dialogues[0].delay);
                else
                    lastaudio = Audomanage.instance.OnPlay(0.8f, dialogues[0].EnglishAC, dialogues[0].talkobj.transform, t, dialogues[0].value, dialogues[0].values, dialogues[0].delay);
            }
            else if (opnion.mylanguage == languageType.japanense)
            {
                textchange(dialogues[0].JapanVersion.ToString());
                if (dialogues[0].JapanAC == null)
                    lastaudio = Audomanage.instance.OnPlay(0.8f, null, dialogues[0].talkobj.transform, t, dialogues[0].value, dialogues[0].values, dialogues[0].delay);
                else
                    lastaudio = Audomanage.instance.OnPlay(0.8f, dialogues[0].JapanAC, dialogues[0].talkobj.transform, t, dialogues[0].value, dialogues[0].values, dialogues[0].delay);
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
        Sayingproxy.instances().hashIdAndIndex.index++;
    }
    void tempFunction()
    {

        tempFunction2();

    }
    void tempFunction2(int res = 0, List<int> values = null)
    {

        AppFactory.instances.viewTodo(new Observer(Cmd.dialog));

    }
}







