using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Event2 : Befunction {
    public AudioClip tAudio;
    public Transform pos;
    public Event2(string temp) : base(temp)
    {
       
    }

    void Start()
    { base.A += function;
       
    }
        // Use this for initialization
        void function()
    {
        Audomanage.instance.playHuHu(tAudio, pos.position);
    }

}
