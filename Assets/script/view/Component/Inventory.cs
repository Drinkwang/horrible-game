using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventory : MonoBehaviour
{
    public int id;
    public int layer;
    public long hashId;

    private void Start()
    {
        PackProxy.instances().InvenToryList.Add(this);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

    public void Refresh() { 
    }
}
