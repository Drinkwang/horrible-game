using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[CreateAssetMenu(fileName = "NewCard", menuName = "CardSystem/CardData")]
public class CardData : ScriptableObject
{
    [Header("Card graphics")]
   // public Sprite cardImage;
    public Material material;
    public int Point;
    public Object res1;
    public Object res2;
    public Object res3;
 //   public Sprite sprite;
 //   [Header("List of Placeables")]
 //   public PlaceableData[] placeablesData;
}