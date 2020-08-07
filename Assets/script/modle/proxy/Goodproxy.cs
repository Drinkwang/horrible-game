using System.Collections;
using System.Collections.Generic;

public class Goodproxy : Baseproxy<Goodsmodel> {

	private static Goodproxy  instance;
	public static Goodproxy instances()
	{
		if (instance == null) {
			instance = new Goodproxy ();

		} 
			return instance;

	}
	// Use this for initialization
	public Goodproxy():base()
	{
		this.addmodeltolist (new Goodsmodel ("♠J", this.getMaxid () + 1));
		this.addmodeltolist (new Goodsmodel ("♠Q", this.getMaxid () + 1));
		this.addmodeltolist (new Goodsmodel ("♠K", this.getMaxid () + 1));
		this.addmodeltolist (new Goodsmodel ("一些扑克", this.getMaxid () + 1));
        this.addmodeltolist(new Goodsmodel("扑克-小鬼", this.getMaxid() + 1));
        this.addmodeltolist(new Goodsmodel("扑克-大鬼", this.getMaxid() + 1));
        this.addmodeltolist(new Goodsmodel("cd-1", this.getMaxid() + 1));
        this.addmodeltolist(new Goodsmodel("cd-2", this.getMaxid() + 1));
        this.addmodeltolist(new Goodsmodel("cd-3", this.getMaxid() + 1));
        this.addmodeltolist(new Goodsmodel("世界名画1", this.getMaxid() + 1));
        this.addmodeltolist(new Goodsmodel("世界名画2", this.getMaxid() + 1));
        this.addmodeltolist(new Goodsmodel("刚画好的油画", this.getMaxid() + 1));
    }
}
