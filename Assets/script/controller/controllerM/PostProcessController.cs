using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostProcessController : IC
{
    private PostprocessProxy proxy=PostprocessProxy.instances();
  
    public void Todo(Observer o) {

        switch (o.msg) {
            case Cmd.initPostEffectOperate:
                AppFactory.instances.viewTodo(new Observer(Cmd.initPostEffectOperate));
                break;
            case Cmd.initPostEffectModel:
                List<PostprocessModel> tempModelList = o.body as List<PostprocessModel>;
                initPostEffectModel(tempModelList);
                break;
            case Cmd.shaderPostEffectOperate:
                ;
                break;
            case Cmd.postEffectOperate:
                AppFactory.instances.viewTodo(new Observer(Cmd.postEffectOperate,(PostprocessModel)o.body));;
                break;

        }
    }

    private void initPostEffectModel(List<PostprocessModel> tempList) {
        List<PostprocessModel> modelList=proxy.getmodellist();
        modelList= tempList;
        this.ChnageModel(modelList);
    }

    private void ChnageModel(List<PostprocessModel> tempModel) {


    }
}
