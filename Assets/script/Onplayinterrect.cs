using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Onplayinterrect : MonoBehaviour {

    // Use this for initialization
    public void OnPlay(string AUDIO)
    {
        Audomanage.instance.OnPlay(AUDIO);
    }
    
}
