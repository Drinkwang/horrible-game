
public class ChangeGoodcommand : IC
{
    PackProxy packproxy = PackProxy.instances();
    Goodproxy goodproxy = Goodproxy.instances();

    public void Todo(Observer o)
    {
        Packagemodel[] body = (Packagemodel[])o.body;
        //     Debug.Log("uncompelet");
      //  Packagemodel one, two = new Packagemodel();
        if (body[0].good.id != body[1].good.id)

            if (packproxy.TryGeGoodtModel(body[0].good.id, out body[0]) == true)
                if (packproxy.TryGeGoodtModel(body[1].good.id, out body[1]) == true)
                {
                    int tid, tcont;
                    tid = body[0].goodid;
                    tcont = body[0].count;
                    body[0].goodid= body[1].goodid;
                    body[0].count = body[1].count;
                    body[1].goodid =tid;
                    body[1].count = tcont;


                }

        // Use this for initialization

    }
}
