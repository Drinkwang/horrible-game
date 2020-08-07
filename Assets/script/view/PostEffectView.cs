using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class PostEffectView : Vmediator
{
    public override string name
    {
        get
        {
            return "PostEffectView";
        }
    }

    public override List<string> msglist{
        get
        {
            List<string> IList = new List<string>();
            IList.Add(Cmd.postEffectOperate);
            IList.Add(Cmd.initPostEffectOperate);
 
            return IList;
        }
    }

    public override void Todo(Observer o)
    {
        switch (o.msg) {
            case Cmd.shaderPostEffectOperate://view
                PostProcessComponent.getInstance().shaderPostEffctOperate(o.body);
               //暂时不知道什么的 ;
                break;
            case Cmd.initPostEffectOperate://view operate
                PostProcessComponent.getInstance().AddAllProcessVolume() ;
                break;
            case Cmd.postEffectOperate://view
                PostProcessComponent.getInstance().ChangeProcessVolume(o.body);
                break;


        }
    }
}

