using System;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 这个是对话框进行操作的命令，可以添加对话以list的形式
/// </summary>
public class Oncesessioncommand : IC
{
    public Sayingproxy saymore = Sayingproxy.instances();
    public Oncesessioncommand()
    {
    }
    public void Todo(Observer o)
    {//Debug.Log();

        if (o.body == null)
        {
            Debug.Log("thi is nothing todo");

        }
        else if (o.msg == Cmd.dialogReplace)
        {
            if ((o.body is SingledialogText))
            {

                SingledialogText rep = (SingledialogText)o.body;
                AppFactory.instances.viewTodo(new Observer(Cmd.dialogReplace, rep, o.data));
            }
            else
            {

                List<SingledialogText> rep = (List<SingledialogText>)o.body;
                AppFactory.instances.viewTodo(new Observer(Cmd.dialogReplace, rep, o.data));
            }
        }
        else if (o.msg == Cmd.dialogRemove) {
            AppFactory.instances.viewTodo(new Observer(Cmd.dialogRemove, o.body, o.data));

        } 
    

        else if (o.body != null && o.body.GetType().ToString() != "System.String")
        {


            List<SingledialogText> news = (List<SingledialogText>)o.body;
            if (o.data != null)
            {
                Sayingproxy.instances().hashIdAndIndex = (Sayingproxy.HashIdAndIndex)o.data;
                news.RemoveRange(0, Sayingproxy.instances().hashIdAndIndex.index);
            }
            if (news.Capacity != 0)
            {
                foreach (SingledialogText msg in news)
                {
                    saymore.Add(msg);


                }

            }

            AppFactory.instances.viewTodo(new Observer(Cmd.dialogAdd));
            AppFactory.instances.viewTodo(new Observer(Cmd.dialog));

        }
        else if (o.body.GetType().ToString() == "System.String")
        {
            AppFactory.instances.viewTodo(new Observer(Cmd.dialog, o.body.ToString()));

        }



    }
}


