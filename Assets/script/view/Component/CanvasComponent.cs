using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasComponent : MonoBehaviour
{
    // Start is called before the first frame update

    private static CanvasComponent instance;

    private void Awake()
    {
        if(instance==null)
        instance = this;
    }


    public static CanvasComponent instances() {
        if (instance != null)
        {
            return instance;
        }
        else
            return null;
    
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Vector3 ReturnCanvasPosition(Transform worldPos)
    {

        CanvasScaler canvasScaler = this.GetComponent<CanvasScaler>();
        float resolutionX = canvasScaler.referenceResolution.x;
        float resolutionY = canvasScaler.referenceResolution.y;
        float offect = (Screen.width / canvasScaler.referenceResolution.x) * (1 - canvasScaler.matchWidthOrHeight) + (Screen.height / canvasScaler.referenceResolution.y) * canvasScaler.matchWidthOrHeight;
        Vector2 a = RectTransformUtility.WorldToScreenPoint(Camera.main, worldPos.position);
        return new Vector3(a.x / offect, a.y / offect, 0);

    }
}
