//
// Auto Generated Code By excel2json
// https://neil3d.gitee.io/coding/excel2json.html
// 1. 每个 Sheet 形成一个 Struct 定义, Sheet 的名称作为 Struct 的名称
// 2. by drinker

// Generate From InventoryModel.xlsx

public class InventoryProxy: Baseproxy<InventoryModel>
{
	private static InventoryProxy instance;
	public static InventoryProxy instances()
	{
		if (instance == null)

		{

			instance = new InventoryProxy();

		}
		instance.ModelToDoView();
	return instance;
	}
}


// End of Auto Generated Code
