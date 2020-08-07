using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvCommand : IC {


    // Use this for initialization
    public void Todo(Observer io)
    {
        switch (io.msg) {
            case Cmd.changeTv:
                AppFactory.instances.viewTodo(new Observer(Cmd.changeTv, io.body));
                break;
            case Cmd.playTv:
                AppFactory.instances.viewTodo(new Observer(Cmd.playTv));
                break;
            case Cmd.stopTv:
                AppFactory.instances.viewTodo(new Observer(Cmd.playTv));
                break;
        }
    }
}
