using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewAnimationEvent : Befunction
{
    // Start is called before the first frame update
    public NewAnimationEvent(string temp) : base(temp)
    {

    }
    public void OnPlayEnd()
    {
        A();
    }
    // Update is called once per frame

}
