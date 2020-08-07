using System.Collections;
using System.Collections.Generic;


public class CameraModel:Basemodel  {
    public float fieldValue;
    public object follow;
    public int priority;

	public CameraModel()
	{
	}
	public CameraModel(int i,float fieldValue,int priority,object follow){
        this.id = i;
        this.fieldValue = fieldValue;
        this.follow = follow;
        this.priority = priority;
	}

}
