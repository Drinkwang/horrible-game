using System.Drawing;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Text;
using System;
using Assets.script.Utils;

[CreateAssetMenu(fileName = "DiaglogSystem", menuName = "Command/ReplaceData")]
public class ReplaceNextDiaglogData : ScriptableObject
{
    //public Befunction temp;
    public String tName;
    private string[] textFile;
    public SingledialogText[] MySingleD;


    public void initDiaglog()
    {
        // if (!this.GetComponent<ReplaceNextDiaglogData>().isActiveAndEnabled){
        //     MySingleD = null;
        // }
        Debug.Log(this.name + "");
        textFile = new string[Multilingual.LanguageLength()];
        foreach (languageType language in Multilingual.getLanguage())
        {
            string streamOpenFileName = Application.streamingAssetsPath + "/" + language + "/" + this.name + ".text";

            if (!Directory.Exists(Application.streamingAssetsPath + "/" + language))
            {
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

    private string GenerateText(int language)
    {
        string tex = "";
        if (MySingleD != null)
        {
            for (int i = 0; i < MySingleD.Length; i++)
            {
                tex += this.name + i + ">";
                if (MySingleD[i].ChineseVersion != null && language == (int)languageType.china)
                    tex += MySingleD[i].ChineseVersion;
                else if (MySingleD[i].ChineseVersion == null && language == (int)languageType.china)
                    tex += "中文";
                else if (MySingleD[i].EnglishVersion != null && language == (int)languageType.english)
                    tex += MySingleD[i].EnglishVersion;
                else if (MySingleD[i].EnglishVersion == null && language == (int)languageType.english)
                    tex += "null";
                else if (MySingleD[i].JapanVersion != null && language == (int)languageType.japanense)
                    tex += MySingleD[i].JapanVersion;
                else if (MySingleD[i].JapanVersion == null && language == (int)languageType.japanense)
                    tex += "存在しない";
                if (i != MySingleD.Length - 1)
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
                if (language == (int)languageType.china)
                    MySingleD[i].ChineseVersion = talkAndSpeak[1];
                else if (language == (int)languageType.english)
                    MySingleD[i].EnglishVersion = talkAndSpeak[1];
                else if (language == (int)languageType.japanense)
                    MySingleD[i].JapanVersion = talkAndSpeak[1];
            }
        }
    }



    public void replace(int index, SessionAddIndex sai)
    {

        if (MySingleD != null)
        {

            foreach (languageType language in Multilingual.getLanguage())
            {
                ReadToText((int)language);
            }
            //  AppFactory.instances.viewTodo(new Observer(Cmd.dialogClear));
            SingledialogText t = MySingleD[index];

            AppFactory.instances.Todo(new Observer(Cmd.dialogReplace, t, sai));
            Audomanage.instance.huhu.Stop();
        }
        else
        { middleLayer.Instance.OnChangSpeed(5, 10, 9.5f); }



    }

    public void replaceAll()
    {

        if (MySingleD != null)
        {

            foreach (languageType language in Multilingual.getLanguage())
            {
                ReadToText((int)language);
            }
            // AppFactory.instances.viewTodo(new Observer(Cmd.dialogClear));
            List<SingledialogText> t = MySingleD.ToList();

            AppFactory.instances.Todo(new Observer(Cmd.dialogReplace, t));
            Audomanage.instance.huhu.Stop();
        }
        else
        { middleLayer.Instance.OnChangSpeed(5, 10, 9.5f); }



    }
    public void mergeAudio(SessionAddIndex sai,List<int> Point){
        //存在bug
        List<float> ar = new List<float> ();
        SingledialogText t = new SingledialogText();
        for(int i=0;i<Point.Count;i++){
            int index =Point[i];
            AudioClip s1= MySingleD[index].ChineseAC;
            float[] data1 = new float[s1.samples * s1.channels];
            s1.GetData (data1, 0);
            ar.AddRange (data1);
            t.ChineseVersion+=MySingleD[index].ChineseVersion;
            t.EnglishVersion+=MySingleD[index].EnglishVersion;
            t.JapanVersion+=MySingleD[index].JapanVersion;

        }
 
        float[] datas = ar.ToArray ();

        t.Sequence=SingledialogText.executeSequence.RunInDiaglogEnd;
        AudioClip clip = AudioClip.Create ("temp", datas.Length/2, 2, 44100, false);
        clip.SetData (datas, 0);




        t.ChineseAC=clip;


        AppFactory.instances.Todo(new Observer(Cmd.dialogReplace, t, sai));
        // source = this.GetComponent<AudioSource> ();
        // source.clip = clip;
        // source.Play ();
        
    }

    public class SessionAddIndex{
        public Onobjsession tempSession;
        public int index;

        public SessionAddIndex()
        {
        }

        public SessionAddIndex(Onobjsession temp,int index) {
            this.tempSession = temp;
            this.index = index;
        }

    }

}
