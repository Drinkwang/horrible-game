using UnityEngine;


public class scriptcommand : IC{
    private string[] myscribe;
    public void Todo(Observer o){
        myscribe =(string[])o.body;
        Color[] color = (Color[])o.data;
        PaperValue ppv = (PaperValue)o.data2;

        switch (o.msg) {
            case "changeM":
                scriptmodel temp;
                if (color!=null && color.Length > 0)
                {
                    temp = new scriptmodel(color[0],color[1],color[2],myscribe[0], myscribe[1], myscribe[2],ppv);;

                }
                else {


                     temp = new scriptmodel(myscribe[0], myscribe[1], myscribe[2],ppv);
                }
                PaperValueProxy.instances().addmodeltolist(temp);
                AppFactory.instances.viewTodo(new Observer("changeM",temp));
                break;

        }
    }
}