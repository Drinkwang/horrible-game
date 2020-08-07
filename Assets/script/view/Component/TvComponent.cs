using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;
using Cinemachine;
using System.Linq;
using UnityEngine.Video;

public class TvComponent:MonoBehaviour{
    private static TvComponent _instance;

    // CinemachineVirtualCamera vcam;
    //CinemachineFreeLook freelook;
    // private CameraProxy cameraProxy;
    private VideoPlayer tv;
    public void Awake() {
        //   cameraProxy = CameraProxy.instances();
        if (_instance == null)
        {
            _instance = this;
            tv = this.GetComponent<VideoPlayer>();
        }       
    }
    public static TvComponent Instance() {
        if(_instance!=null)
            return _instance;
        return null;
    }
    public void initTv() {
        //cinemacineList = new List<CinemachineVirtualCamera>();
        //cinemacineList.Add(CinemacineMain);
        //List<CinemachineVirtualCamera> temp = new List<CinemachineVirtualCamera>();
        //temp = this.transform.GetComponentsInChildren<CinemachineVirtualCamera>().ToList();
        //cinemacineList.AddRange(temp);
        //List < CameraModel > addList= new List<CameraModel>();
        //for (int i=0;i<cinemacineList.Count;i++) {
        //    CinemachineVirtualCamera tcv = cinemacineList[i];
        //    CameraModel t = new CameraModel(i+1,tcv.m_Lens.FieldOfView,tcv.m_Priority,tcv.m_LookAt);
        //    addList.Add(t);
        //}
        //AppFactory.instances.Todo(new Observer("addCamera",addList));
    }

    internal void playTv(bool t)
    {
        if (t == true)
            tv.Play();
        else
            tv.Stop();
    }

    internal void changeTv(object body)
    {

        tv.url = body as string;
        //{if (t.id == j + 1){
        //        cinemacineList[j].Priority =t.priority;
        //        cinemacineList[j].Follow = t.follow as Transform;
        //        cinemacineList[j].m_Lens.FieldOfView = t.fieldValue;
        //        this.addAllCamera();

        //    }
        //}
    }
}

