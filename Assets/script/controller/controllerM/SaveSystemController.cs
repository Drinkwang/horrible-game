﻿
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;
using Assets.script.modle.SaveSystem;
using Newtonsoft.Json;
using UnityStandardAssets.Characters.FirstPerson;
class SaveSystemController : IC
{
    public void Todo(Observer o)
    {
        int index = (int)o.body;

        string saveFile = Application.streamingAssetsPath + "/saveFile" +  +index + ".hb";

        if ((string)o.msg == Cmd.saveGame)
        {

            SaveModel inputDate = new SaveModel
            {
                cameraProxy = CameraProxy.instances(),
                all = allsave.instance.every,
                packProxy = PackProxy.instances(),
                playerPosition = hiui.instance.GetPlayerPosition(),
                sayingProxy = Sayingproxy.instances(),
                paintPoint = PaintModelComponent.instance.paintPoint,
                IsLock = CabinetManagerComponent.instance.isLock,
                opnion = OpnionProxy.instances(),
                paperValueProxy=PaperValueProxy.instances()
                //     playerPosition = hiui.instance.GetPlayerPosition(),

            };

            string json = JsonConvert.SerializeObject(inputDate);
                File.WriteAllText(saveFile, json, Encoding.UTF8);
            }
        else if ((string)o.msg == Cmd.loadGame) {


            if (!File.Exists(saveFile))
                return;
            StreamReader sr = new StreamReader(saveFile);
            if (sr == null)
                return;
            string json = sr.ReadToEnd();
            if (json.Length > 0) {
                SaveModel save = JsonConvert.DeserializeObject<SaveModel>(json);
                CameraProxy.instances().SetCamera(save.cameraProxy);
                PackProxy.instances().setPackProxy(save.packProxy);
                OpnionProxy.instances().setOpnion(save.opnion);

                PaintModelComponent.instance.setPaintPoint(save.paintPoint);
                CabinetManagerComponent.instance.setIsLock(save.IsLock);
                hiui.instance.setPlayerPosition(save.playerPosition);
                allsave.instance.every = save.all;



                Sayingproxy.instances().SetSaveContent(save.sayingProxy.hashIdAndIndex);
                PaperValueProxy.instances().SetPaperValue(save.paperValueProxy);
            }


            //GameData saveData = AppFactory.instances.saveData.saveData1[(int)SaveGbName.dialogObj];
            //SaveGbName.dialogObj.ToString()

            sr.Close();

 
              
              
                
        }

    }
}
