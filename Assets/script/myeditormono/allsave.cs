using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class allsave : MonoBehaviour {
	public static allsave instance; 
	public Dictionary<eventCmd, bool> every;
	public eventCmd[] a;
	public bool[] b;
	// Use this for initialization
	void Awake()
	{if (instance == null)
			instance = this;
	}
	void Start () {
		every = new Dictionary<eventCmd, bool> ();
		for (int i = 0; i < a.Length; i++) {
			every.Add (a[i], b[i]);
		}
        
	}
	
	// Update is called once per frame
	void Update () {
        every.Values.CopyTo(b, 0);
    }
}


public enum eventCmd {
	第一次交互,
	第一张卡牌,
	三张卡牌,
	赌桌事件,
	获取武器,
	打开大门,
	游戏结束,
	打开地窖,
	画板排序,
	播放电视,
	小游戏,
	不能回收手牌,
	demo结束,
	琳的记忆


}