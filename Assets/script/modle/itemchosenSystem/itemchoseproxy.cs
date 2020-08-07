using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemchoseproxy : Baseproxy<itemchosenmodel> {
    private static itemchoseproxy instance;
    public static itemchoseproxy instances()
    {
        if (instance == null)
        {
            instance = new itemchoseproxy();

        }
        return instance;

    }
    public void clear()
    {
        getmodellist().Clear();
    }
    // Use this for initialization
    public void add(itemchosenmodel a)
    { this.addmodeltolist(a);
    }

    // Update is called once per frame



}
