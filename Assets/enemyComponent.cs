using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyComponent : MonoBehaviour
{

    public int health;
    public bool canTakeD;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool takeDamage(int dmg) {
        if (canTakeD) {
            this.health -= dmg;
            Debug.Log(this.health);
            return true;

        }

        return false;
    }

}
