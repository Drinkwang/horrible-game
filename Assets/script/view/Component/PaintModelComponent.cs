using UnityEngine;
using UnityEngine.UI;
using System.Text;
using System.Text.RegularExpressions;

public class PaintModelComponent:MonoBehaviour
    {
    public static PaintModelComponent instance;
    public GameObject[] paint;
    public GameObject[] paintbase;


    public GameObject paintHave;
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
        if (isCompelete() && isCorrectConsequence()) {
            if (AppFactory.instances.eventTodo("画板排序")) {
                this.GetComponent<Onobjsession>().add();
                CabinetManagerComponent.instance.isLock[3] = false;
                CabinetManagerComponent.instance.cabinetLengthTable[CabinetManagerComponent.instance.cabinets[3]].isLock = false;
            
            }
        //画画事件完成
        }
    
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


    public bool isCorrectConsequence() {

        return (paintPoint[0] == 1 && paintPoint[1] == 3 && paintPoint[2] == 2);


    }

}

