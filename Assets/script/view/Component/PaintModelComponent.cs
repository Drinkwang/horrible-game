using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;

public class PaintModelComponent:MonoBehaviour
    {
    public static PaintModelComponent instance;
    public GameObject[] paint;
    public GameObject[] paintbase;
    public int[] paintPoint;

    private void Awake()
    {
        if (instance == null) {

            instance = this;
        }
        paintPoint = new int[3] { 1,2,3};
       
    }

    public void generalPaintBase()
    {
        for (int i = 0; i < this.paint.Length; i++)
        {

            if (this.paint[i].activeSelf == false) { 
                this.paintbase[i].SetActive(true);
                }
            else if (paint[i].activeSelf == true)
            {
                this.paintbase[i].SetActive(false);

            }
        }


    }


    public bool isCompelete() {
        for (int i = 0; i < this.paint.Length; i++)
        {

            if (this.paint[i].activeSelf == false)
            {
                return false;
            }
            else if (paint[i].activeSelf == true)
            {
                continue;

            }
        }
        return true;



    }


    public void settlement() { 
    
    
    }
    public void setPaintPoint(int[] temp) {

        if(temp!=null)
            paintPoint = temp;

        GameObject[] tempPaints = (GameObject[])paint.Clone();
        for (int i = 0; i <= 2; i++) {


            if (paint[i] != tempPaints[paintPoint[i] - 1])
            {
                Vector3 tempPaint = paint[i].transform.position;
        


         
                paint[i].transform.position = paint[paintPoint[i] - 1].transform.position;


                paint[paintPoint[i] - 1].transform.position = tempPaint;

                Vector3 tempPaintBase = paintbase[i].transform.position;
                paintbase[i].transform.position = paintbase[paintPoint[i] - 1].transform.position;
                paintbase[paintPoint[i] - 1].transform.position = tempPaintBase;
                tempPaints[paintPoint[i] - 1] = paint[i];
                tempPaints[i] = paint[paintPoint[i] - 1];
            }
        }

        PaintModelComponent.instance.generalPaintBase();
    }

}

