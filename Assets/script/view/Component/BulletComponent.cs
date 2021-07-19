using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
public class BulletComponent:MonoBehaviour{



    public void launch(Vector3 CanvasPoint) {
        Ray tw =Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        float halfValue = 0.05f;
        Vector3 ScreenP = Camera.main.ScreenToWorldPoint(new Vector3(CanvasPoint.x, CanvasPoint.y, CanvasPoint.z)) + new Vector3(this.transform.forward.x * halfValue, this.transform.forward.y * halfValue, this.transform.forward.z * halfValue);
        //GameObject bullet= GameObject.Instantiate(shootObj, ScreenP, Quaternion.identity, bulletManager.transform);

       //GameObject bullet = GamePool.Instance.GetObject(PoolName.bulletPool);
        this.transform.position = ScreenP;
        //     bullet.GetComponent<Rigidbody>().AddForce(hitpoint.transform * 500);
        this.GetComponent<Rigidbody>().AddForce(tw.direction * 500);

    }


    public void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
      //  Destroy(this);
    }
}

