using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scribeChange : Befunction
{
    public string top;
    public string center;
    public string inscribe;
    public Color topC;
    public Color centerC;
    public Color inscribeC;

    public scribeChange(string temp) : base(temp)
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
        string[] temp = new string[] { top, center, inscribe };
        AppFactory.instances.Todo(new Observer("changeM",temp));
    }

}
