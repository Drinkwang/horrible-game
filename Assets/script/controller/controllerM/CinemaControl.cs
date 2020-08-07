using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

    public class CinemaControl:IC
    {

        CameraProxy cameraProxy= CameraProxy.instances();
    // Use this for initialization
    public void Todo(Observer io)
    {
        if (io.msg == Cmd.changeCamera)
        {
            CameraModel ChangeModel = (CameraModel)io.body;
            CameraModel t;
            if (cameraProxy.TryGetModel(ChangeModel.id, out t))
            {
                t = ChangeModel;
            }
            AppFactory.instances.viewTodo(new Observer(Cmd.changeCamera, t));
            AppFactory.instances.ssinvoke();
        }
        else if (io.msg == Cmd.moveCamera)
        {
            cameraProxy.NowCameraID = (int)io.body;
            AppFactory.instances.viewTodo(new Observer(Cmd.moveCamera, (int)io.body));
        }
        else if (io.msg == Cmd.addCamera) {
            cameraProxy.clear();
            List<CameraModel> newL =(List<CameraModel>)io.body;
            foreach (CameraModel i in newL)
                cameraProxy.addmodeltolist(i);
        }

        }
    }
