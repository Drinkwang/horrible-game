using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allsave : MonoBehaviour {
	public static allsave instance; 
	public Dictionary<string,bool> every;
	public string[] a;
	public bool[] b;
	// Use this for initialization
	void Awake()
	{if (instance == null)
			instance = this;
	}
	void Start () {
		every = new Dictionary<string, bool> ();
		for (int i = 0; i < a.Length; i++) {
			every.Add (a[i], b[i]);
		}
        
	}
	
	// Update is called once per frame
	void Update () {
        every.Values.CopyTo(b, 0);
    }
}
