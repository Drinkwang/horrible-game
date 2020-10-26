using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


class PostprocessModel : Basemodel
{
    public string postEffectSrc= "Vignette";
    public float intensity = 0;
    public string beEffectProperty="";
    public Action T;

    public PostprocessModel()
    {
    }
}

