using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptmodel:Basemodel  {
    public string top;
    public string center;
    public string inscribe;

    public Color topColor=Color.black;
    public Color centerColor = Color.black;
    public Color inscribeColor= Color.black;
    public PaperValue paper;

    public scriptmodel() { }

    public scriptmodel(Color ct,Color cc,Color ci, string top = null, string center = null, string inscribe = null,PaperValue ppv=null)
    {

        topColor = ct;
        centerColor = cc;
        inscribeColor = ci;

        this.top = top;
        this.center = center;
        this.inscribe = inscribe;
        this.paper = ppv;


    }


    public scriptmodel(string top = null, string center = null, string inscribe = null,PaperValue ppv=null)
    {
        this.top = top;
        this.center = center;
        this.inscribe = inscribe;

        this.paper = ppv;

    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
