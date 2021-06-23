using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class item : MonoBehaviour,IPointerDownHandler, IBeginDragHandler, IDragHandler, IEndDragHandler,IDropHandler
{
	private Image image;
	private Text text;
    private  GameObject selectitemMenu,DragObj,tempBeUseObj;
    private Canvas canvas;
    private static RectTransform dragObjRect;
   
    void Awake()
	{
        if (dragObjRect == null)
        { dragObjRect = this.GetComponentInParent<RectTransform>(); }
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();


		text = transform.GetComponentInChildren<Text> ();
        selectitemMenu = GameObject.FindGameObjectWithTag("itemchosen").transform.GetChild(0).gameObject;
           
	}
 
	// Use this for initialization
	void Start () {
		
	}
    
    // Update is called once per frame
    void Update () {
		
	}

    public void OnPointerDown(PointerEventData eventData)
    {
        Invoke("OnPointerDownAfter", 0.15f);
    }
    public void OnPointerDownAfter()
    {

        if (OpnionProxy.instances().myglobelstate == Globelstate.state.start)
        {
            if (this.model.goodid!=0 && this.model.good != null && this.model.good.src != null && DragObj == null)
            {
 
                selectitemMenu.SetActive(true);
                Itemselect.instance.mychild.transform.position = new Vector3(this.transform.position.x + 2 * this.transform.GetComponent<RectTransform>().sizeDelta.y, this.transform.position.y - this.transform.GetComponent<RectTransform>().sizeDelta.y / 3, this.transform.position.z);
                Befunction T = new Befunction("检查物品" + " " + model.good.src + " " + model.good.id);
                T.A += T.checkitem;
                AppFactory.instances.Todo(new Observer("add", T));
                Befunction w = new Befunction("使用物品" + " " + model.good.src + " " + model.good.id);
                w.A += w.useritem;
                AppFactory.instances.Todo(new Observer("add", w));
                AppFactory.instances.Todo(new Observer("render"));
            }
        }
    }
    public void OnEndDrag(PointerEventData eventData)
    {

        if (eventData != null)
        {
            AppFactory.instances.changestate(Globelstate.state.start,false);
            LimitUtil.value = 300;
            if (DragObj != null && packageComponent.instante.T.Model != null && packageComponent.instante.T.Model.good != null &&AppFactory.instances.IsHitItem())
            {
                
                Befunction w = new Befunction("使用物品" + " " + DragObj.GetComponent<DragObj>().tempModel.good.src + " " + DragObj.GetComponent<DragObj>().tempModel.good.id);
                w.A += w.useritem;
                w.runa();
                Destroy(DragObj);//拖拽结束后销毁生成的物体
            }
            else
            {
                Destroy(DragObj);
                AppFactory.instances.ChangeIsHitChangeObj(false);
                if (tempBeUseObj != null)
                    AppFactory.instances.SetbeUseObj(tempBeUseObj);
            }
        }


    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
    
           if(this.model.goodid != 0 && this.model.good != null && this.model.good.src != null && DragObj == null&&collision.gameObject.tag=="uicard"&& packageComponent.instante.T.Model!=null)
        {
            AppFactory.instances.Todo(new Observer("exchange", new Packagemodel[] { packageComponent.instante.T.Model, Model }));
            refresh();
            packageComponent.instante.T.refresh();


        }

        
    }
    public void OnDrop(PointerEventData eventData)
    {
        /*if (eventData.pointerDrag != null)
        {
            Image img = eventData.pointerDrag.GetComponent<Image>();
            if (img != null)
            {
                GetComponent<Image>().sprite = img.sprite;
                GetComponent<Image>().color = new Color(1, 1, 1, 1);//我刚开始把图片设为了透明
            }
        }*/
    }


    public void OnBeginDrag(PointerEventData eventData)
    {
        tempBeUseObj = AppFactory.instances.GetbeUseObj();
        AppFactory.instances.ChangeIsHitChangeObj(true);

        if (OpnionProxy.instances().myglobelstate == Globelstate.state.start&& eventData!=null)
        {
            if (this.model.goodid != 0 && this.model.good != null && this.model.good.src != null && DragObj == null)
            {
                packageComponent.instante.T = this;
                selectitemMenu.SetActive(false);
                DragObj = new GameObject("ICON");
                DragObj.tag = "uicard";
                DragObj.AddComponent<Rigidbody2D>();
                DragObj.AddComponent<DragObj>();
                DragObj.GetComponent<Rigidbody2D>().gravityScale = 0;
                DragObj.transform.SetParent(canvas.transform, false);
                DragObj.transform.SetAsLastSibling();

       
                Image img = DragObj.AddComponent<Image>();//给生成的拖拽物体添加一个Image组件并获得Image组件的控制权
                BoxCollider2D t = DragObj.AddComponent<BoxCollider2D>();
                t.size = new Vector2(25, 25);
                t.isTrigger = true;
                img.raycastTarget = false;//让该物体不接受鼠标的照射，目的是底下的物品也能操作
                img.sprite = GetComponent<Image>().sprite;//让生成物体的图片为按钮的图片
                DragObj.GetComponent<RectTransform>().sizeDelta =
                new Vector2(Screen.height * 0.1f, Screen.height * 0.1f);//设置新生成物品的尺寸
                ObjFollowMouse(eventData);//让生成的物体跟随鼠标
                AppFactory.instances.changestate(Globelstate.state.load,false);
                packageComponent.instante.T.model = model;
                DragObj.GetComponent<DragObj>().tempModel = new Packagemodel(model.id, model.count, model.goodid);
                DragObj.GetComponent<DragObj>().tempModel.good = model.good;
                }
           

                // item.Instance.model = this.model;//
            
   

        }
    }
    private void ObjFollowMouse(PointerEventData eventData)
    {
        if (DragObj != null&& dragObjRect!=null)//检测生成的物体是否为空，保险起见
        {
            RectTransform rc = DragObj.GetComponent<RectTransform>();//得到生成物品的控制权
            Vector3 globalMousePos;
            if (rc != null)
            {
                if (RectTransformUtility.ScreenPointToWorldPointInRectangle
               (dragObjRect, eventData.position, eventData.pressEventCamera, out globalMousePos))
                {
                    rc.position = globalMousePos;
                    rc.rotation = dragObjRect.rotation;
                }
            }
        }
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (packageComponent.instante.T==null && DragObj!=null)
        { Destroy(DragObj);
        }
        ObjFollowMouse(eventData);
    }

    private Packagemodel model;
	public Packagemodel Model
	{

		get{return this.model; }
		set{ model = value;
            refresh();

            }
		
	}


    void refresh() {


        image = transform.GetComponentInChildren<Image>();
        Sprite useSprite = null;
        if (model.goodid != 0)
        {
            if (this.model.is3DModel == false)
            {
                useSprite = Resources.Load<Sprite>(model.good.src);
            }
            else if (this.model.is3DModel == true)
            {

                RenderTexture texture = Resources.Load<RenderTexture>(model.good.src);
                useSprite = Sprite.Create(CUtil.getTexture2d(texture), new Rect(new Vector2(0, 0), new Vector2(texture.width, texture.height)), new Vector2(0.5f, 0.5f));


            }
            if (AppFactory.instances.GetbeUseObj()) { 
            
            
            }


            this.image.sprite = useSprite;
            Color q = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 255);
            this.image.color = q;
            this.text.text = model.good.name + "";



        }
        else
        {


            //Image tempImage = this.image as Image;
            Color qa = new Color(this.image.color.r, this.image.color.g, this.image.color.b, 0);
            this.image.color = qa;



            this.text.text = "";

        }
    }
}
