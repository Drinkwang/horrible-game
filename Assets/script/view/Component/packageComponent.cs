using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;
public class packageComponent : MonoBehaviour {
	public static packageComponent instante;
    Color oringin;
    public  item T;
    public GameObject entrytab;
    public void Awake()
	{instante = this;
        oringin = this.GetComponent<Image>().color;
        closePackage();
       // T = new item();
    }

	// Use this for initialization
	void Start () {
		//showPackage (new List<Packagemodel> ());
		
	}
    public void closePackage()
    {
        foreach (Transform t in this.transform)
        {//print (t.name);
            Destroy(t.gameObject);
        }
        entrytab.SetActive(false);
        this.GetComponent<Image>().color= new Color(oringin.r,oringin.g,oringin.b,0);
       
    }

    public int findItemIndex(int goodId)
    {
        if (this.isActiveAndEnabled)
        {
            foreach (Transform t in this.transform)
            {//print (t.name);
                item temp = t.GetComponent<item>();
                if (temp.Model.goodid == goodId)
                {

                    return t.GetSiblingIndex();
                }
            }
        }
        return 0;
    }

    public GameObject findItem(int goodId)
    {
        if (this.isActiveAndEnabled)
        {
            foreach (Transform t in this.transform)
            {//print (t.name);
                item temp = t.GetComponent<item>();
                if (temp.Model.goodid == goodId)
                {

                    return t.gameObject;
                }
            }
        }
        return null;
    }

    public void showPackage(List<Packagemodel> model,string tempLanguage)
    {
   //     GameObject beObj = AppFactory.instances.GetbeUseObj();
        if (tempLanguage.Length > 0)
        {

            //   entrytab.GetComponentInChildren<Text>().text = tempLanguage;
            //   entrytab.SetActive(true);



            if (tempLanguage == TagCmd.clickUseItem)
            {
         
                tagComponent.instance.changeTagWithType(TagCmd.clickUseItem);
            }
            else if (tempLanguage == TagCmd.pressTabInterrupt)
            {
                //beObj = null;
                tagComponent.instance.changeTagWithType(TagCmd.pressTabInterrupt);

            }
            else {

                tagComponent.instance.changeTagWithType(tempLanguage);

            }


        }
        else {
            tagComponent.instance.changeTagWithType("", false);
        }




        this.GetComponent<Image>().color = oringin;
        foreach (Transform t in this.transform)
		{//print (t.name);
			Destroy (t.gameObject);
		}


        foreach (var i in model)
        {
            GameObject obj = null;

            obj = GameObject.Instantiate(Resources.Load<GameObject>("item"));

            obj.transform.SetParent(this.gameObject.transform);
            obj.GetComponent<item>().Model = i;


        }
       
    }

    


    //public void AnimationUpdata(object obj, OutlineEx t)
    //{


    //    int per = (int)obj;
    //    t.OutlineWidth = per;

    //}
    // Update is called once per frame

}
