//
// Auto Generated Code By excel2json
// https://neil3d.gitee.io/coding/excel2json.html
// 1. 每个 Sheet 形成一个 Struct 定义, Sheet 的名称作为 Struct 的名称
// 2. 表格约定：第一行是变量名称，第二行是变量类型

// Generate From PaperModel.xlsx

public class PaperModel: Basemodel
{
	public int PaperId; // 编号
	public string PaperType; // 纸的类型(大概率不用)
	public string PaperName; // 卷轴的名字
	public string[] china; // 中文（上、中、下）
	public string[] english; // 英语（上、中、下）
	public string[] japanense; // 日本语（上、中、下）
	public int[] Color; // 颜色（上、中、下）
	public bool IsExit; // 是否能退出
	public bool IsDestory; // 是否看过销毁
}


// End of Auto Generated Code
