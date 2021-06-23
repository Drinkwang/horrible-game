using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


  public class OpnionProxy
    {
    public bool isOpenCheckTip = true;


    private Globelstate.state globelstate;
    public Globelstate.state myglobelstate
    {
        get { return globelstate; }
        private set { globelstate = value; }
    }
    private Globelstate.language elanguage;
    public Globelstate.language mylanguage
    {
        get { return elanguage; }
        private set { elanguage = value; }
    }

    private static OpnionProxy instance;
    public static OpnionProxy instances()
    {
        if (instance == null)
        {
            instance = new OpnionProxy();

        }
      //  instance.ModelToDoView();
        return instance;

    }

    internal void SetLanguage(Globelstate.language lan)
    {
        mylanguage = lan;
    }


    internal void setState(Globelstate.state lan)
    {
        myglobelstate = lan;
    }

    internal void setOpnion(OpnionProxy opnion)
    {
        this.mylanguage = opnion.mylanguage;
        this.myglobelstate = opnion.myglobelstate;
    }
}

