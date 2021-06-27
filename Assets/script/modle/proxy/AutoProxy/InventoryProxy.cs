//
// Auto Generated Code By excel2json
// https://neil3d.gitee.io/coding/excel2json.html
// 1. 本文件为自动生成的Proxy文件，请放到合适的目录底下,此文件不能做任何修改，尽量通过Controller调用
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

	public InventoryProxy()	{

		modellist= ArchiveManager.Instance.GetSamplelist<InventoryModel>();
	}
}


// End of Auto Generated Code
