using UnityEngine;


public class scriptcommand : IC{
    private string[] myscribe;
    public void Todo(Observer o){
        myscribe =(string[])o.body;
        switch (o.msg){
            case "changeM":scriptmodel temp = new scriptmodel(myscribe[0], myscribe[1], myscribe[2]);
                AppFactory.instances.viewTodo(new Observer("changeM",o.body));
                break;

        }
    }
}