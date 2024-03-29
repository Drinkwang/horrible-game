﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Text;
using System;
using Assets.script.Utils;

public class Onobjsession : MonoBehaviour {
    private string[] textFile;
    public int fontSize= 0;
    public void Awake()
    { 
        if (!this.GetComponent<Onobjsession>().isActiveAndEnabled){
            MySingleD = null;
        }
        Sayingproxy.instances().addHashSession(this.GetHashCode(), this);
        textFile = new string[Multilingual.LanguageLength()];
        foreach (languageType language in  Multilingual.getLanguage())
        {
            string streamOpenFileName =  Application.streamingAssetsPath + "/"+language+"/"+ this.gameObject.name + ".text";
        
            if (!Directory.Exists(Application.streamingAssetsPath + "/" + language)) {
                Directory.CreateDirectory(Application.streamingAssetsPath + "/" + language);
            }
            if (File.Exists(streamOpenFileName))
            {
               
                StreamReader sr = new StreamReader(streamOpenFileName);
                if (sr != null)
                {
                    textFile[(int)language] = sr.ReadToEnd();
                }
                
            }
            else if (textFile[(int)language] == null)
            {
                if (!File.Exists(streamOpenFileName))
                {
                    string tex = GenerateText((int)language);
                    File.WriteAllText(streamOpenFileName, tex, Encoding.UTF8);

                }
            }
        }


    }
    private void Start()
    {
        runSingleDialogT(SingledialogText.executeSequence.RunInStart);
    }

    private string GenerateText(int language) {
        string tex="";
        if (MySingleD != null)
        {
            for (int i = 0; i < MySingleD.Length; i++)
            {
                tex += MySingleD[i].talkobj.name + ">";
                if (MySingleD[i].ChineseVersion != null&&language==(int)languageType.china)
                    tex += MySingleD[i].ChineseVersion;
                else if(MySingleD[i].ChineseVersion == null && language == (int)languageType.china)
                    tex += "中文";
                else if (MySingleD[i].EnglishVersion != null && language == (int)languageType.english)
                    tex +=MySingleD[i].EnglishVersion;
                else if (MySingleD[i].EnglishVersion == null && language == (int)languageType.english)
                    tex += "null";
                else if (MySingleD[i].JapanVersion != null && language == (int)languageType.japanense)
                    tex += MySingleD[i].JapanVersion;
                else if(MySingleD[i].JapanVersion == null && language == (int)languageType.japanense)
                    tex += "存在しない";
                if(i!=MySingleD.Length-1)
                    tex += "\n";
            }
        }
        return tex;
    }


    public void ReadToText(int language)
    {
        if (textFile[language] != null)
        {
            string[] eachParagraph = textFile[language].Split('\n');
            for (int i = 0; i < eachParagraph.Length; i++)
            {
                String[] talkAndSpeak = eachParagraph[i].Split('>');
                if(language==(int)languageType.china)
                    MySingleD[i].ChineseVersion = talkAndSpeak[1];
                else if (language == (int)languageType.english)
                    MySingleD[i].EnglishVersion = talkAndSpeak[1];
                else if (language == (int)languageType.japanense)
                    MySingleD[i].JapanVersion = talkAndSpeak[1];
            }
        }
    }


    public SingledialogText[] MySingleD;
    public void add(int index=0){
        if (MySingleD != null){

            foreach (languageType language in Multilingual.getLanguage())
            {
                ReadToText((int)language);
            }
            AppFactory.instances.viewTodo(new Observer(Cmd.dialogClear));
   
            runSingleDialogT(SingledialogText.executeSequence.RunInAdd);    
            List<SingledialogText> t = MySingleD.ToList();
            Sayingproxy.HashIdAndIndex tempHashIdAndIndex = new Sayingproxy.HashIdAndIndex();
            tempHashIdAndIndex.hashId = this.GetHashCode();
            tempHashIdAndIndex.index = index;
            //tempHashIdAndIndex.FontSize = fontSize;
            //hashId和index内容是存档使用的
            if(fontSize!=0)
                AppFactory.instances.viewTodo(new Observer(Cmd.dialogChangeFontSize, fontSize,false));
            else
                AppFactory.instances.viewTodo(new Observer(Cmd.dialogChangeFontSize, fontSize, true));
            AppFactory.instances.Todo(new Observer(Cmd.dialog, t, tempHashIdAndIndex));
            Audomanage.instance.huhu.Stop();
        }
        else
        { middleLayer.Instance.OnChangSpeed(5, 10, 9.5f); }

 
        
    }


    private void runSingleDialogT(SingledialogText.executeSequence TSequence) {


        for (int i = 0; i < MySingleD.Length; i++)
        {
            if (MySingleD[i].t != null)
            {
                MySingleD[i].t.calledObj = this;
                MySingleD[i].t.sai = new ReplaceNextDiaglogData.SessionAddIndex(this, i);
                if (MySingleD[i].Sequence == TSequence)
                {
                    //mpSingdialogText.t.A
                    MySingleD[i].t.runa(MySingleD[i].value, MySingleD[i].values);

                }
            }
        }

    }

}
