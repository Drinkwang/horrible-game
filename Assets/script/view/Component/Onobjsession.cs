using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Text;
using System;

public class Onobjsession : MonoBehaviour {
    public Befunction temp;
    private string[] textFile;
    public void Awake()
    { 
        if (!this.GetComponent<Onobjsession>().isActiveAndEnabled){
            MySingleD = null;
        }
      
        textFile = new string[Globelstate.LanguageLength()];
        foreach (Globelstate.language language in Globelstate.getLanguage())
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
        //待编辑，增加四个状态，分别在游戏初始化，脚本播放完，脚本刚开始播放进行执行脚本


        for (int i = 0; i < MySingleD.Length; i++)
        {
            if (MySingleD[i].t != null) { 
                MySingleD[i].t.calledObj = this;
                MySingleD[i].t.sai = new ReplaceNextDiaglogData.SessionAddIndex(this,i); }
        }
        foreach (SingledialogText tempSingdialogText in MySingleD)
        {
            if (tempSingdialogText.Sequence == SingledialogText.executeSequence.RunInStart)
            {
                //mpSingdialogText.t.A
                tempSingdialogText.t.runa(tempSingdialogText.value, tempSingdialogText.values);

            }

        }
    }

    private string GenerateText(int language) {
        string tex="";
        if (MySingleD != null)
        {
            for (int i = 0; i < MySingleD.Length; i++)
            {
                tex += MySingleD[i].talkobj.name + ">";
                if (MySingleD[i].ChineseVersion != null&&language==(int)Globelstate.language.china)
                    tex += MySingleD[i].ChineseVersion;
                else if(MySingleD[i].ChineseVersion == null && language == (int)Globelstate.language.china)
                    tex += "中文";
                else if (MySingleD[i].EnglishVersion != null && language == (int)Globelstate.language.english)
                    tex +=MySingleD[i].EnglishVersion;
                else if (MySingleD[i].EnglishVersion == null && language == (int)Globelstate.language.english)
                    tex += "null";
                else if (MySingleD[i].JapanVersion != null && language == (int)Globelstate.language.japanense)
                    tex += MySingleD[i].JapanVersion;
                else if(MySingleD[i].JapanVersion == null && language == (int)Globelstate.language.japanense)
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
                if(language==(int)Globelstate.language.china)
                    MySingleD[i].ChineseVersion = talkAndSpeak[1];
                else if (language == (int)Globelstate.language.english)
                    MySingleD[i].EnglishVersion = talkAndSpeak[1];
                else if (language == (int)Globelstate.language.japanense)
                    MySingleD[i].JapanVersion = talkAndSpeak[1];
            }
        }
    }


    public SingledialogText[] MySingleD;
    public void add(){
        if (temp != null)
        {
            temp.runa();

        }

        if (MySingleD != null){

            foreach (Globelstate.language language in Globelstate.getLanguage())
            {
                ReadToText((int)language);
            }
            AppFactory.instances.viewTodo(new Observer(Cmd.dialogClear));
            List<SingledialogText> t = MySingleD.ToList();

            AppFactory.instances.Todo(new Observer("once", t));
            Audomanage.instance.huhu.Stop();
        }
        else
        { middleLayer.Instance.OnChangSpeed(5, 10, 9.5f); }

 
        
    }


}
