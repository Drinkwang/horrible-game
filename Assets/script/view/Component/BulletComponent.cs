using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class BulletComponent:MonoBehaviour{



    public void launch() { 
    
    
    
    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
      //  Destroy(this);
    }
}

