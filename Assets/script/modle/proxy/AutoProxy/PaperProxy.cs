//
// Auto Generated Code By excel2json
// https://neil3d.gitee.io/coding/excel2json.html
// 1. 本文件为自动生成的Proxy文件，请放到合适的目录底下,此文件不能做任何修改，尽量通过Controller调用
// 2. by drinker

// Generate From PaperModel.xlsx

public class PaperProxy: Baseproxy<PaperModel>
{
	private static PaperProxy instance;
	public static PaperProxy instances()
	{
		if (instance == null)

		{

			instance = new PaperProxy();

		}
		instance.ModelToDoView();
	return instance;
	}

	public PaperProxy()	{

		modellist= ArchiveManager.Instance.GetSamplelist<PaperModel>();
	}
}


// End of Auto Generated Code
