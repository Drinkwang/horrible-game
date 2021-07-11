using Assets.script.Utils;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using static Assets.script.Utils.Multilingual;

public class tagComponent : MonoBehaviour
{

    public tagLanguage[] TagLanguages;

    public static tagComponent instance; 



    string GenerateText()
    {
        string reLs="";
        for (int i = 0; i < TagLanguages.Length; i++) {

            reLs += TagLanguages[i].clickUseItem + "," + TagLanguages[i].pressTabInterrupt+ "\n";
        }
        return reLs;

    }




    void saveLogic()
    {

        string textFile = "";

            string streamOpenFileName = Application.streamingAssetsPath + "/"  + this.gameObject.name + ".text";


            if (File.Exists(streamOpenFileName))
            {

                StreamReader sr = new StreamReader(streamOpenFileName);
                if (sr != null)
                {
                    textFile = sr.ReadToEnd();
                }

            }
            else if (!File.Exists(streamOpenFileName))
            {

                textFile = GenerateText();
                File.WriteAllText(streamOpenFileName, textFile, Encoding.UTF8);

                
            }
        string[] eachTag=textFile.Split('\n');
        foreach (languageType t in getLanguage()) {
            string[] tags = eachTag[(int)t].Split(',');
            TagLanguages[(int)t].clickUseItem = tags[0];
            TagLanguages[(int)t].pressTabInterrupt = tags[1];
        }
      

    }

   


    void Awake()
    {
        if(instance==null)
            instance = this;
        saveLogic();

    }


    public void changeTagWithType(string Content,bool visble=true) {


        if (Content.Length > 0)
        {
            this.GetComponentInChildren<Text>().text = Content;
            for (int i = 0; i < TagLanguages.Length; i++)
            {

                if (TagLanguages[i].lan == OpnionProxy.instances().mylanguage)
                {

                    if (Content == "clickUseItem")
                    {
                        this.GetComponentInChildren<Text>().text = TagLanguages[i].clickUseItem;

                    }
                    else if (Content == "pressTabInterrupt")
                    {

                        this.GetComponentInChildren<Text>().text = TagLanguages[i].pressTabInterrupt;

                    }
                    break;
                }


            }
            this.gameObject.SetActive(true);

        }
        else {

            this.gameObject.SetActive(false);
        }

    
    }
}


[System.Serializable]
public struct tagLanguage
{

    public string clickUseItem;
    public string pressTabInterrupt;

    public languageType lan;

}
static class TagCmd {

    public const string clickUseItem = "clickUseItem";
    public const string pressTabInterrupt = "pressTabInterrupt";
}