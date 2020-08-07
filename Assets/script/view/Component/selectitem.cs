using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class selectitem : MonoBehaviour,IPointerDownHandler
{
   


    
    
   /* private void OnMouseDown()
    {
        Debug.Log("aaa");
       
    }*/
    // Use this for initialization
    void Start()
    {

    }
   


    public void OnPointerDown(PointerEventData eventData)
    {
        model.thisb.runa();
    }

    [SerializeField]
    private itemchosenmodel model;
    public itemchosenmodel Model
    {
        get { return this.model; }
        set
        {
            model = value;
            if (model.id!= null)
            {
                
             

            }
        }

    }
}
