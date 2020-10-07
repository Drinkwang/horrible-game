using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuetionController : IC
{
    //private PostprocessProxy proxy=PostprocessProxy.instances();
  
    public void Todo(Observer o) {
        AppFactory.instances.viewTodo(o);
        //switch (o.msg) {
        //    case Cmd.QuetionChangeButton:
        //        AppFactory.instances.viewTodo(new Observer(Cmd.initPostEffectOperate));
        //        break;
        //    case Cmd.QuetionChangeTitle:
        //        AppFactory.instances.viewTodo(new Observer(Cmd.initPostEffectOperate));
        //        break;  
        //    case Cmd.QuetionShow：
                

        //}
    }


}
