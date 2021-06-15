using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class CameraProxy:Baseproxy<Cameramodel>{
    private int nowCameraID;
    private static CameraProxy instance;

    public int NowCameraID
    {
        get
        {
            return nowCameraID;
        }

        set
        {
            nowCameraID = value;
        }
    }
    public static CameraProxy instances()
    {
        if (instance == null)
        {
            instance = new CameraProxy();

        }
        instance.ModelToDoView();
        return instance;

    }

    internal void clear()
    {
        this.modellist.Clear();
    }

    internal void SetCamera(CameraProxy cameraProxy)
    {
        nowCameraID = cameraProxy.nowCameraID;
        
    }
}


