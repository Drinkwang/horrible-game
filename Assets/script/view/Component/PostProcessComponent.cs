using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
public class PostProcessComponent:MonoBehaviour{
    public List<PostProcessVolume> localVolume;
    public  PostProcessVolume globalVolume;
    private PostprocessModel model;

    private static PostProcessComponent _instance;
    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

    }

    public static PostProcessComponent getInstance() {
        return _instance;

    }

    public void AddAllProcessVolume() {
        localVolume = new List<PostProcessVolume>();
        localVolume.Add(globalVolume);
        localVolume.AddRange(this.transform.GetComponentsInChildren<PostProcessVolume>().ToList());
  
        List<PostprocessModel> addList = new List<PostprocessModel>();

        for (int i = 0; i < localVolume.Count; i++) {
            PostprocessModel model = new PostprocessModel();
            PostProcessVolume volume=localVolume[i];

            model.id = i + 1;
            model.intensity = 1;
            addList.Add(model);

        }
        AppFactory.instances.Todo(new Observer(Cmd.initPostEffectModel,addList));
    }

    /// <summary>
    /// Operate on shader files
    /// 操作shader文件相關，暫時留空
    /// </summary>
    /// <param name="body"></param>
    public void shaderPostEffctOperate(object body) {


    }


    public void ChangeProcessVolume(object body) {
        PostprocessModel tempModel = body as PostprocessModel;
        model = tempModel;
        for (int i = 0; i < localVolume.Count; i++) {
            if (tempModel.id == i) {
           
                MethodInfo method = localVolume[i].profile.GetType().GetMethod("GetSetting");
                //传入泛型参数
                Type beEffectType=Type.GetType(tempModel.postEffectSrc+ ",Unity.Postprocessing.Runtime");
                method = method.MakeGenericMethod(beEffectType);
                object setting=method.Invoke(localVolume[i].profile, null);
                float storeValue=(float)setting.GetType().GetField("intensity").GetValue(setting).GetType().GetField("value").GetValue(setting.GetType().GetField("intensity").GetValue(setting));
                // setting.GetType().GetField("intensity").GetValue(setting).GetType().GetField("value").SetValue(setting.GetType().GetField("intensity").GetValue(setting), tempModel.intensity);
                //   Debug.Log(setting.GetType().GetField("intensity"));

                iTween.ValueTo(gameObject, iTween.Hash("from", storeValue, "to",tempModel.intensity,// gameObject.transform.position为0.0.0
                "easetype", "easeInBack", "loopType", "none",  "time", 1f, "onupdate", "AnimationUpdata", "oncomplete", "Oncomplete"));
                // MethodInfo method2 = setting.GetType().GetField("intensity").GetValue(setting).GetType().GetMethod("Interp");
                //  method2.Invoke(setting.GetType().GetField("intensity").GetValue(setting), new object[]{ 0.0f,1.0f,2.0f});
                //("value"));
                //setting.GetType().GetField("intensity").SetValue(setting.GetType().GetField("intensity"), 1.0f);
                // CUtil.GetAppSetting<PostProcessEffectSettings>("sss");
                if (tempModel.postEffectSrc == "Vignette")
                {
                    
                    // Vignette setting = localVolume[i].profile.GetSetting<Vignette>();
                    //   setting.intensity.value = tempModel.intensity;
                    // iTween.ValueTo(gameObject, iTween.Hash("from", gameObject.transform.position, "to", new Vector3(20, 0, 0),// gameObject.transform.position为0.0.0
                    //"easetype", "easeInBack", "loopType", "pingPong", "onupdate", "onupdate", "time", 2f));
                }
            }
        }

    }
    public void Oncomplete() {
        if(model.T!=null)
            model.T();
    }


    public void AnimationUpdata(object obj)
    {

        MethodInfo method = localVolume[model.id].profile.GetType().GetMethod("GetSetting");
        //传入泛型参数
        Type beEffectType = Type.GetType(model.postEffectSrc + ",Unity.Postprocessing.Runtime");
        method = method.MakeGenericMethod(beEffectType);
        object setting = method.Invoke(localVolume[model.id].profile, null);
        float per = (float)obj;
        setting.GetType().GetField("intensity").GetValue(setting).GetType().GetField("value").SetValue(setting.GetType().GetField("intensity").GetValue(setting), per);

    }

    //动画开始时调用
    void AnimationStart(float f)
    {
        Debug.Log("start :" + f);
    }
    //动画结束时调用
    void AnimationEnd(string f)
    {
        Debug.Log("end : " + f);
    }


}

