using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "NewBloom", menuName = "CardSystem/BloomData")]

public class BloomData : ScriptableObject
{
  


    public CardData[] MyTablecards;
    public CardData[] enemyTablecards;
    public CardData[] deckHold;
    public int currenceUseCardNum = 0;
    //敌人的卡牌
    //public GameObject[] cardback;

    //public GameObject[] myback;
    ////myCard board
    //public GameObject[] cardBorad;
    //public GameObject bloomBeacon;

    private bool myInit=false;
    private bool eneInit=false;

    private int myCardNum;
    private int enemyCardNum;


    public int MyScore=0;
    public int EnemyScore=0;
    private void Awake()
    {

    }
    public void initCards(int turn) {
        switch (turn) {
            case 0:
                if(MyTablecards.Length==0)
                    MyTablecards=new CardData[3];
                myInit = true;
                myCardNum = 0;
                currenceUseCardNum = 0;
                break;
            case 1:
                if (enemyTablecards.Length == 0)
                    enemyTablecards = new CardData[3];
                eneInit = true;
                enemyCardNum = 0;
                break;
        }

    }

    public void pushCard(int turn,CardData tempData)
    {
        if (turn == 0)
        {
            if (myInit == true)
            {
                if (myCardNum < 3)
                {

                    MyTablecards[myCardNum++] = tempData;
                }
                else
                {
                    Debug.Log("我方卡牌溢出，无法添加");
                }
            }
            else
            {
                Debug.Log("请初始化你自己的卡牌");
            }

        }
        else if (turn == 1)
        {
            if (eneInit == true)
                if (enemyCardNum < 3)
                {
                    enemyTablecards[enemyCardNum++] = tempData;

                }

                else
                {
                    Debug.Log("我方卡牌溢出，无法添加");
                }
        
            else {
                Debug.Log("请初始化敌人自己的卡牌");
            }
        }

    }

    public CardData popCard(int turn) {

        if (turn == 1)
        {
            if (enemyCardNum > 0)
                return enemyTablecards[--enemyCardNum];
        }
        else if (turn == 0)
        {
            if (myCardNum > 0)
                return MyTablecards[--myCardNum];
        }
        
        return null;
    }

    public void CardsRetrieved(List<CardData> cardDataDownloaded,int turn)
    {
        int totalCards = cardDataDownloaded.Count;
        //load the actual cards data into an array, ready to use
        if (turn == 0)
        {
            
            MyTablecards = new CardData[totalCards];
            for (int c = 0; c < totalCards; c++)
            {
                MyTablecards[c] = cardDataDownloaded[c];
            }
        }
        else if (turn == 1) {
            enemyTablecards = new CardData[totalCards];
            for (int c = 0; c < totalCards; c++)
            {
                enemyTablecards[c] = cardDataDownloaded[c];
            }

        }
    }

}