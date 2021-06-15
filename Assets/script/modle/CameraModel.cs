using Newtonsoft.Json;

public class Cameramodel:Basemodel  {
    [JsonIgnore]
    public float fieldValue;
    [JsonIgnore]
    public object follow;
    [JsonIgnore]
    public int priority;

	public Cameramodel()
	{
	}
	public Cameramodel(int i,float fieldValue,int priority,object follow){
        this.id = i;
        this.fieldValue = fieldValue;
        this.follow = follow;
        this.priority = priority;
	}

}
