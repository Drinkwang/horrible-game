//
// Auto Generated Code By excel2json
// https://neil3d.gitee.io/coding/excel2json.html
// 1. 每个 Sheet 形成一个 Struct 定义, Sheet 的名称作为 Struct 的名称
// 2. 表格约定：第一行是变量名称，第二行是变量类型

// Generate From C:\Users\15271\Documents\horror Game\Tool\xlsx\InventoryModel.xlsx.xlsx

public class InventoryProxy: Baseproxy<InventoryModel>
{
	private static Inventory instance;
	public static Inventory instances()
	{

		if (instance == null)

		{

			instance = new Inventory();

		}
		instance.ModelToDoView();
	return instance;
	}
}


// End of Auto Generated Code
