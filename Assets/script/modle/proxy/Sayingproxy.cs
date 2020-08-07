using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct SingledialogText
{ public string ChineseVersion;
   public string EnglishVersion;
   public string JapanVersion;
   public AudioClip EnglishAC;
   public AudioClip ChineseAC;
   public AudioClip JapanAC;
    public GameObject talkobj;
    public Befunction t;
}




public class Sayingproxy{

	private List<SingledialogText> saywhat; 
	// Use this for initialization
	//public string src;
	private static Sayingproxy instance;
	public static Sayingproxy instances ()
	{if (instance == null) {
		
			instance = new Sayingproxy ();
			instance.saywhat = new List<SingledialogText>();
		}
	 return instance;
	}
	public void Add(SingledialogText what)
	{
			saywhat.Add (what);

	}
	public List<SingledialogText> returnLs()
	{
			return	saywhat;
		
	}
    public void clear()
    {
        saywhat.Clear();
        
    }

    // Update is called once per frame

}
