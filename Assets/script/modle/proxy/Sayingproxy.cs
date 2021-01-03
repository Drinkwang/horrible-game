using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SingledialogText
{ public string ChineseVersion;
    public enum executeSequence {
        RunInDiaglogEnd,
        RunInDiaglogBegan,
        RunInStart,
        RunInAdd,
        
    }
   
   public string EnglishVersion;
   public string JapanVersion;
   public AudioClip EnglishAC;
   public AudioClip ChineseAC;
   public AudioClip JapanAC;
    public GameObject talkobj;
    public Befunction t;
    public executeSequence Sequence;
    public int value;
    public List<int> values;
    public void Assignment(Onobjsession Single,int index) {
 

        Debug.Log("老对话" + Single.MySingleD[index].ChineseVersion);
        Single.MySingleD[index].ChineseVersion = this.ChineseVersion;
        Single.MySingleD[index].EnglishVersion = this.EnglishVersion;
        Single.MySingleD[index].JapanVersion = this.JapanVersion;



        Single.MySingleD[index].EnglishAC = this.EnglishAC;
        Single.MySingleD[index].ChineseAC = this.ChineseAC;
        Single.MySingleD[index].JapanAC = this.JapanAC;
        Single.MySingleD[index].t = this.t;
        Single.MySingleD[index].value = this.value;
        Single.MySingleD[index].values = this.values;
        Debug.Log("新对话" + ChineseVersion);

    }


    public void Assignment(string ChineseVersion, string EnglishVersion,
    string JapanVersion,
    AudioClip EnglishAC,
    AudioClip ChineseAC,
    AudioClip JapanAC,
    GameObject talkobj = null,
    Befunction t = null,
    int value = 0,
    List<int> values = null)
    {
        this.ChineseVersion = ChineseVersion;
        this.EnglishVersion = EnglishVersion;
        this.JapanVersion = JapanVersion;
        this.EnglishAC = EnglishAC;
        this.ChineseAC = ChineseAC;
        this.JapanAC = JapanAC;
        this.talkobj = talkobj;
        this.t = t;
        this.value = value;
        this.values = values;
    }
}




public class Sayingproxy {

    private List<SingledialogText> saywhat;
    // Use this for initialization
    //public string src;
    private static Sayingproxy instance;
    private Dictionary<int, Onobjsession> hashOnSession;
    //public int currenceHashId;
    //public int index;
    public HashIdAndIndex hashIdAndIndex;
    public static Sayingproxy instances()
    { if (instance == null) {

            instance = new Sayingproxy();
            instance.saywhat = new List<SingledialogText>();

        }
        return instance;
    }
    public void Add(SingledialogText what)
    {
        if (saywhat == null) {
            instance.saywhat = new List<SingledialogText>();
        }
        saywhat.Add(what);

    }
    public List<SingledialogText> returnLs()
    {
        return saywhat;

    }
    public void clear()
    {
        if (saywhat != null)
        {
            saywhat.Clear();
        }

    }


    public void SetSaveContent(HashIdAndIndex temp) {

        Sayingproxy.instances().hashIdAndIndex = temp;
        Onobjsession result = getHashSession(Sayingproxy.instances().hashIdAndIndex.hashId);
        if (hashIdAndIndex.index - 1 >= 0)
            result.add(hashIdAndIndex.index - 1);
        else
            result.add();
    }

    public void addHashSession(int hashId, Onobjsession tempSession) {

        if (hashOnSession == null) {
            hashOnSession = new Dictionary<int, Onobjsession>();
        }

        hashOnSession.Add(hashId, tempSession);
    }


    public Onobjsession getHashSession(int hashId)
    {


        Onobjsession tempOnsession;

        hashOnSession.TryGetValue(hashId, out tempOnsession);
        return tempOnsession;
    }


    // Update is called once per frame

    public class HashIdAndIndex{
        public int hashId;
        public int index;
   }

}
