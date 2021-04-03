
using System.Collections.Generic;

public class ChangeGoodcommand : IC
{
    PackProxy packproxy = PackProxy.instances();
 //   Goodproxy goodproxy = Goodproxy.instances();

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
                    bool is3DModel;
                    List<int> thashId;
                    Goodsmodel tGood;
                    tid = body[0].goodid;
                    tcont = body[0].count;
                    thashId = body[0].hashId;
                    tGood=body[0].good;
                    is3DModel = body[0].is3DModel;

                    body[0].goodid= body[1].goodid;
                    body[0].count = body[1].count;
                    body[0].is3DModel = body[1].is3DModel;
                    body[0].hashId = body[1].hashId;
                    body[0].good = body[1].good;

                    body[1].goodid =tid;
                    body[1].count = tcont;
                    body[1].hashId = thashId;
                    body[1].is3DModel = is3DModel;
                    body[1].good = tGood;

                }

        // Use this for initialization

    }
}
