using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class testSystem : MonoBehaviour
{
    public Button getItem;
    public InputField getItemField;
    public Button changeCamera;
    public InputField changeCameraField;

    // Start is called before the first frame update
    void Start()
    {
        getItem.onClick.AddListener(getItemF);
        changeCamera.onClick.AddListener(changeCameraF);
    }

    void changeCameraF() {
        int i = int.Parse(changeCameraField.text);
        AppFactory.instances.Todo(new Observer(Cmd.moveCamera, i));


    }

    void getItemF() {
        int i = int.Parse(getItemField.text);
        AppFactory.instances.Todo(new Observer("AddGoodscommand", i));

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
