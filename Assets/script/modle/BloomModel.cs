﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloomModel : MonoBehaviour
{
    public GameObject[] cardback;
    public GameObject[] myback;
    public GameObject[] cardBorad;
    public GameObject bloomBeacon;
    public BloomData bloomData;
    
    public static BloomModel _instance;
    void Awake()
    {

        if (_instance == null)
            _instance = this;
    }

    

    public static BloomModel instance() {

        return _instance;
    }

    
}
