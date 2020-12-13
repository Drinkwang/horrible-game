
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
                playerPosition = hiui.instance.GetPlayerPosition()
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

                hiui.instance.setPlayerPosition(save.playerPosition);
                allsave.instance.every = save.all;

            }
            sr.Close();

 
              
              
                
        }

    }
}
