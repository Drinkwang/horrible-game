//
// Auto Generated Code By excel2json
// https://neil3d.gitee.io/coding/excel2json.html
// 1. 每个 Sheet 形成一个 Struct 定义, Sheet 的名称作为 Struct 的名称
// 2. 表格约定：第一行是变量名称，第二行是变量类型

// Generate From InventoryModel.xlsx

public class InventoryModel: Basemodel
{
	public int GoodId; // 编号
	public string GoodType; // 商品类型(大概率不用)
	public string InvName; // 物品栏png路径名字
	public bool IsShop; // 是否商人出售
	public int[] ShopLevel; // 商人售卖层级
	public string cabinet; // 锁住商品的柜子(tag)
	public string[] Language; // 不同语言的名字
	public bool is3DModel; // 是否是3d模型，自动生成物品栏图片
	public string FunctionObj; // 物品作用的对象
}


// End of Auto Generated Code
