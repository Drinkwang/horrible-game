using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System;
using Cinemachine;
using System.Linq;

public class CinemacineComponent:MonoBehaviour{
    private static CinemacineComponent _instance;
    public CinemachineVirtualCamera CinemacineMain;
   
    public List<CinemachineVirtualCamera> cinemacineList; 
    public void Awake() {
        if (_instance == null)
            _instance = this;
    
    }
    public static CinemacineComponent Instance() {
        if(_instance!=null)
            return _instance;
        return null;
    }
    public void addAllCamera() {
        cinemacineList = new List<CinemachineVirtualCamera>();
        cinemacineList.Add(CinemacineMain);
        List<CinemachineVirtualCamera> temp = new List<CinemachineVirtualCamera>();
        temp = this.transform.GetComponentsInChildren<CinemachineVirtualCamera>().ToList();
        cinemacineList.AddRange(temp);
        List < CameraModel > addList= new List<CameraModel>();
        for (int i=0;i<cinemacineList.Count;i++) {
            CinemachineVirtualCamera tcv = cinemacineList[i];
            CameraModel t = new CameraModel(i+1,tcv.m_Lens.FieldOfView,tcv.m_Priority,tcv.m_LookAt);
            addList.Add(t);
        }
        AppFactory.instances.Todo(new Observer("addCamera",addList));
    }

    public void moveCamera(int body)
    {   
        for (int j=0; j< cinemacineList.Count;j++)
            cinemacineList[j].Priority = j+1;
        if(body-1>=-1)
            cinemacineList[body].Priority = 100;
        CinemacineMain = cinemacineList[body];
        middleLayer.Instance.changeCamera(body);
    }

    public void changeCamera(object body)
    {
       CameraModel t= body as CameraModel;
        for (int j = 0; j < cinemacineList.Count; j++)
        {
            if (t.id == j + 1){
                cinemacineList[j].Priority =t.priority;
                cinemacineList[j].Follow = t.follow as Transform;
                cinemacineList[j].m_Lens.FieldOfView = t.fieldValue;
                this.addAllCamera();

            }
        }
    }
}

