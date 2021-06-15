using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class bloomTableEvent : Befunction
{
    public GameObject stoneScissorCloth;
    private Canvas canvas;
    private packageComponent packageC;
    private BloomProxy bloomModel;
    public Camera tempCamera;
    //public BloomData tempBloomData;
    private List<GameObject> hintObj;

    
    public enum bloomType
    {
        bloom_changeCamera = 0,
        bloom_TimeLine = 1,
        bloom_bloomPlayDetail = 2,
        bloom_bloomEnd = 3,
        bloom_discardCard = 4,
        bloom_showEnemyCard=5
        //IGG_MobileRoyale,
    }
    public bloomType type = 0;

 
    public bloomTableEvent(string temp) : base(temp)
    {
    }

    public void Awake()
    {
        packageC = packageComponent.instante;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
        bloomModel = BloomProxy.instance();
        Reset();
    }

    public void Reset()
    {
        base._A = Myfunction;
        base.A = function;
    }
    public void event1(int changeId) {
        Debug.Log("game start");
        AppFactory.instances.Todo(new Observer(Cmd.playTv));
        AppFactory.instances.Todo(new Observer(Cmd.moveCamera, changeId));
        if (type == bloomType.bloom_bloomPlayDetail) {
            StartCoroutine("showPack");
        }
    }

    public void event2() {
        stoneScissorCloth.SetActive(true);
        stoneScissorCloth.GetComponent<PlayableDirector>().Play();
    }


    public void event3() {
        bloomModel = BloomProxy.instance();
      
        //tempBloomData.initCards(0);
        //tempBloomData.initCards(1);

        AppFactory.instances.changestate(Globelstate.state.start,true);

        for (int i = 0; i < 3; i++)
        {
            bloomModel.myback[i].SetActive(false);
            string cardBackMatrial = "Materials/cardback" + i;
            bloomModel.cardback[i].GetComponent<MeshRenderer>().material = Resources.Load<Material>(cardBackMatrial);
            //int index = CUtil.cardPointToId(CUtil.cardBacktoID(cardBackMatrial));// cResources.Load<Material>("Materials/cardback" + i)

            bloomModel.cardback[i].GetComponent<CardBase>().SetData(CUtil.cardBacktoID(cardBackMatrial), false);
            //CardData tempCardData = bloomModel.bloomData.deckHold[index];
            //Resources.Load<Material>(CUtil.idToCardBackString(beUseItemId));
            //tempCardData.Point = i + 10;
            //tempBloomData.pushCard(1, tempCardData);

            //  Debug.Log("isrun mouse");
        }
    }
    public void event4()
    {
        PostprocessModel tempModel = new PostprocessModel();
        tempModel.id = 0;
        tempModel.postEffectSrc = "UnityEngine.Rendering.PostProcessing.Vignette";
        tempModel.intensity = 1;
        tempModel.T += event4_2;
        AppFactory.instances.Todo(new Observer(Cmd.postEffectOperate, tempModel));


    }

    /// <summary>
    /// 分段后处理效果2
    /// </summary>
    public void event4_2() {
        PostprocessModel tempModel = new PostprocessModel();
        tempModel.id = 0;
        tempModel.postEffectSrc = "UnityEngine.Rendering.PostProcessing.Vignette";
        tempModel.intensity = 0;
        AppFactory.instances.Todo(new Observer(Cmd.postEffectOperate, tempModel));



    }

    /// <summary>
    /// 事件5-将Boss扑克牌进行翻面
    /// </summary>
    /// <param name="changeID">翻开的扑克牌编号，其中第一张为0</param>
    public void event5(int changeID) {

        if (bloomModel.cardback[changeID] != null)
        {
            CardBase tempCard = bloomModel.cardback[changeID].GetComponent<CardBase>();
            if (tempCard != null)
            {
                tempCard.RenderCard();
                Audomanage.instance.OnPlay("cardDraw");
            }

        }
        else {
            Debug.LogError("非正常情况将Boss的卡牌翻出，请检查源代码");
        }
    
    }
    public void function() {
        Myfunction();
    }
  
    // Start is called before the first frame update
    public void  Myfunction(int a=0,List<int> b=null)
    {
        type = (bloomType)a;
        int changeId;

        if (b!=null&&b.Count>0)
            changeId = b[0];
        else
            changeId = 0;
        if (type == bloomType.bloom_changeCamera || type == bloomType.bloom_bloomPlayDetail)
            event1(changeId);
        else if (type == bloomType.bloom_TimeLine)
            event2();
        else if (type == bloomType.bloom_bloomEnd)
        {
            event3();
        }
        else if (type == bloomType.bloom_discardCard)
        {

            event4();
        }
        else if (type == bloomType.bloom_showEnemyCard) {
            event5(changeId);
        }
        Reset();

    }
    public IEnumerator showPack() {
        bloomModel = BloomProxy.instance();
        hintObj = new List<GameObject>();
        yield return new WaitForSeconds(0.5f);
        AppFactory.instances.showpack();
        for (int i = 1; i <= 3; ++i)
            StartCoroutine("moveToP", i);

    }

    public IEnumerator moveToP(int i) {
   
        yield return new WaitForSeconds(1f);
       
        var moveObj = new GameObject("bloomTableEvent");
        moveObj.AddComponent<Rigidbody2D>();
        GameObject tObject = packageC.findItem(i);
        moveObj.transform.SetParent(canvas.transform, false);
        moveObj.GetComponent<Rigidbody2D>().gravityScale = 0;
        moveObj.transform.position =  tObject.transform.position ;

        moveObj.transform.SetAsLastSibling();
   
        Image img = moveObj.AddComponent<Image>();//给生成的拖拽物体添加一个Image组件并获得Image组件的控制权

        img.raycastTarget = false;//让该物体不接受鼠标的照射，目的是底下的物品也能操作
        if (tObject != null)
        {
            img.sprite = Resources.Load<Sprite>(tObject.GetComponent<item>().Model.good.src);
            moveObj.GetComponent<RectTransform>().localScale = new Vector3(0.5f, 0.5f, 0.5f);
            hintObj.Add(moveObj);
            Vector3 screenPoint = tempCamera.WorldToScreenPoint(bloomModel.cardBorad[i - 1].transform.position);
            Vector3 betweenP = screenPoint - moveObj.transform.position + new Vector3(0, 50);

            iTween.MoveBy(moveObj, iTween.Hash("x", betweenP.x, "y", betweenP.y, "easeType", "easeInOutExpo", "delay", .1, "oncomplete", "functionComplete", "oncompleteparams", i, "onCompleteTarget", this.gameObject));
        }
    }
    //// Update is called once per frame
    private void functionComplete(int i)
    {

        bloomModel.myback[i-1].SetActive(true);
        hintObj[i - 1].SetActive(false);
        StartCoroutine("onPoke",i);
    }

    public IEnumerator onPoke(int i)
    {
        yield return new WaitForSeconds(0.2f);
        AppFactory.instances.showpack();
        yield return new WaitForSeconds(3f);
        bloomModel.myback[i-1].GetComponent<MeshRenderer>().material = Resources.Load<Material>(CUtil.idToMaterialString(i+10));

        bloomModel.cardback[i-1].GetComponent<MeshRenderer>().material = Resources.Load<Material>(CUtil.idToMaterialString(CUtil.getBeWinCard(i+10,true)));

        yield return new WaitForSeconds(5f);
        bloomModel.bloomBeacon.SetActive(true);
        bloomModel.bloomBeacon.GetComponent<Animation>().Play();
        AnimationClip t= bloomModel.bloomBeacon.GetComponent<Animation>().GetClip("beaconChange");
        AnimationEvent animationEvent = new AnimationEvent();
        bloomModel.bloomBeacon.GetComponent<NewAnimationEvent>().A += OnPlayEnd;
        animationEvent.functionName = "OnPlayEnd";
        animationEvent.time = t.length;
        t.AddEvent(animationEvent);
    }

    private void OnPlayEnd() {
        bloomModel.bloomBeacon.SetActive(false);

    }
}
