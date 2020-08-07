using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class middleLayer : MonoBehaviour {
	public event Action onInteractive;
	public event Action exitaction;
    public event Action OnMousePause;
    public event Action OnMouseRun;
    public event Action<int> OnChangeCamera;
    public  Action<float,float,float> OnSetSpeed;
    // Use this for initialization
    private static middleLayer instans;
    public bool canMove;
    public static middleLayer Instance
    {
        get
        {if (instans != null)
                return instans;
            else return null;
        }
    }
    private void Awake()
    {
        canMove = true;
        instans = this;
    }

    void Start () {
		
	}
    public void MouseRun()
    {
        if(canMove==true)
            OnMouseRun();
    }
    public void MousePause()
    {
        OnMousePause();
       
    }
    public void intel()
	{onInteractive ();
		//Debug.Log ("dad");
	}
	public void exit()
	{exitaction ();
	}
    public void changeCamera(int i) {
        OnChangeCamera(i);
    }
    /// <summary>
    /// For walk ,run jump Setvalue
    /// </summary>
    /// <param name="walkSpeed">设置移动速度</param>
    /// <param name="runspeed">设置跑步速度</param>
    /// <param name="jumpspeed">设置跳跃速度</param>
    public void OnChangSpeed(float walkSpeed,float runspeed,float jumpspeed)
    {
        OnSetSpeed(walkSpeed, runspeed, jumpspeed);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
