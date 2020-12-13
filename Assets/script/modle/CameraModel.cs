using Newtonsoft.Json;

public class CameraModel:Basemodel  {
    [JsonIgnore]
    public float fieldValue;
    [JsonIgnore]
    public object follow;
    [JsonIgnore]
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
