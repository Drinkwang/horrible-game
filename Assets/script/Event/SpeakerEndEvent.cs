using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakerEndEvent : Befunction
{
    // Start is called before the first frame update
    public SpeakerEndEvent(string temp) : base(temp)
    {

    }


    void Start()
    {
        base.A += function;

    }
    // Use this for initialization
    void function()
    { //Debug.Log("222233");
      // middleLayer.Instance.OnSetSpeed(5.0f, 10.0f, 9.5f);
        AppFactory.instances.postObj.isSpeakerPlaying = false;
    }
}
