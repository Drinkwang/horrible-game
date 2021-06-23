using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class tagComponent : MonoBehaviour
{

    public tagLanguage[] TagLanguage;

    public static tagComponent instance; 



    string GenerateText(int i)
    {

        return "";

    }




    void saveLogic()
    {

        string[] textFile = new string[Globelstate.LanguageLength()];
        foreach (Globelstate.language lan in Globelstate.getLanguage())
        {
            string streamOpenFileName = Application.streamingAssetsPath + "/" + lan + "/" + this.gameObject.name + ".text";

            if (!Directory.Exists(Application.streamingAssetsPath + "/" + lan))
            {
                Directory.CreateDirectory(Application.streamingAssetsPath + "/" + lan);
            }
            if (File.Exists(streamOpenFileName))
            {

                StreamReader sr = new StreamReader(streamOpenFileName);
                if (sr != null)
                {
                    textFile[(int)lan] = sr.ReadToEnd();
                }

            }
            else if (textFile[(int)lan] == null)
            {
                if (!File.Exists(streamOpenFileName))
                {
                    string tex = GenerateText((int)lan);
                    File.WriteAllText(streamOpenFileName, tex, Encoding.UTF8);

                }
            }
        }

    }

   
    // Update is called once per frame
    void Update()
    {

    }


    void Awake()
    {
        if(instance==null)
            instance = this;

    }


    public void changeTagWithType(string Content,bool visble=true) {


        if (Content.Length > 0)
        {
            this.GetComponentInChildren<Text>().text = Content;
            for (int i = 0; i < TagLanguage.Length; i++)
            {

                if (TagLanguage[i].lan == OpnionProxy.instances().mylanguage)
                {

                    if (Content == "clickUseItem")
                    {
                        this.GetComponentInChildren<Text>().text = TagLanguage[i].clickUseItem;

                    }
                    else if (Content == "pressTabInterrupt")
                    {

                        this.GetComponentInChildren<Text>().text = TagLanguage[i].pressTabInterrupt;

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

    public Globelstate.language lan;

}
static class TagCmd {

    public const string clickUseItem = "clickUseItem";
    public const string pressTabInterrupt = "pressTabInterrupt";
}