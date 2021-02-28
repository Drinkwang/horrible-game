using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardBase : MonoBehaviour
{
    public CardData data;
    private CardData[] datas;
    public void SetData(int a, bool isRender) {

        if (datas == null) {
            init(BloomModel.instance().deckhold);
        
        }

        for (int i = 0; i < datas.Length; i++)
        {
            if (datas[i].Point == a)
            {
                data = datas[i];
                break;
            }

        }
        if (isRender ==true)
            RenderCard();

    }
    public void SetData(CardData a,bool isRender)
    {
        data = a;
        if (isRender == true)
            RenderCard();
    }

    // Start is called before the first frame update
    public void init(CardData[] deckhold)
    {
        datas = deckhold;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void RenderCard()
    {
        //   this.GetComponent<MeshRenderer>().material = Resources.Load<Material>(data.material);
        //temp.material
        this.GetComponent<MeshRenderer>().material = data.material;//Resources.Load<Material>(CUtil.idToCardBackString(beUseItemId + 10));
    }
}
