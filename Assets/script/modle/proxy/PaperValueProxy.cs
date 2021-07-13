using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public enum PaperType
{


    相机1 = 1,



}

public class PaperValue 
{
    public int id;
    public bool isExit;
    public bool isDestory;
    public int hashId;

}


public class PaperValueProxy : Baseproxy<scriptmodel>
{

    //[JsonIgnore]
    private List<paperComponent> paperComponentList;
    private static PaperValueProxy instance;
    public static PaperValueProxy instances()
    {
        if (instance == null)
        {
            instance = new PaperValueProxy();

        }
        instance.ModelToDoView();
        return instance;

    }

    internal void SetPaperValue(PaperValueProxy paperValueProxy)
    {
        modellist = paperValueProxy.getmodellist();
        this.modellist.ForEach(e =>
        {
            if (e.paper.hashId != 0)
            {

                paperComponentList.ForEach(paper =>
                {
                    if (paper.GetHashCode() == e.paper.hashId)
                    {
                        if (e.paper.isDestory == true)
                        {
                            paper.gameObject.SetActive(false);
                            //paper.Refresh();
                            return;
                        }

                    }
                });

            }

        });
    }


    public void addPaperComponentToList(paperComponent paper)
    {
        if (paperComponentList == null)
            paperComponentList = new List<paperComponent>();
        this.paperComponentList.Add(paper);


    }

    public void removePaperComponentToList(paperComponent temp)
    {
        paperComponentList.Remove(temp);


    }
}