using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int id;
    public int layer;
    private int hashId;

    private void Start()
    {
        hashId = GetHashCode();
        if (PackProxy.instances().InvenToryList == null) { 
            PackProxy.instances().InvenToryList = new List<Inventory>(); 
        }

      
        Debug.Log("HashId" + hashId);
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        
    }

   
    public void Refresh() { 
    }
}
