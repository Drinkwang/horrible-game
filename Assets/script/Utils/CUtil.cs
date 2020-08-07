

using System;
using System.Text.RegularExpressions;
using System.ComponentModel;
public static class CUtil 
{

    // Start is called before the first frame update
    public static int GetResidueNum(string temp) {
        string numString = "";
        foreach (char a in temp) {
            if (a >= 48 && a <= 58)
            {

                numString += a;
            }
            else
                continue;

        }
        if (numString.Length >= 0)
            return int.Parse(numString);
        else
            return 0;


    }

    public static String idToMaterialString(int id) {
        string t ="";
       if (id==1)
            t= "Materials/扑克j";//剪刀
       else if(id==2)
            t = "Materials/扑克q";//步
        else if (id == 3)
            t = "Materials/扑克k";//石头
        return t;
    }

    public static String idToCardBackString(int id) {
        string t = "";
        if (id == 1)
            t = "Materials/cardback0";//剪刀
        else if (id == 2)
            t = "Materials/cardback2";//步
        else if (id == 3)
            t = "Materials/cardback1";//石头
        return t;

    }

    public static int cardBacktoID(string str) {
        //T.Substring()
        int result = 0;
        if (str != null && str != string.Empty)
        {
            // 正则表达式剔除非数字字符（不包含小数点.）
            str = Regex.Replace(str, @"[^\d.\d]", "");
            // 如果是数字，则转换为decimal类型
            if (Regex.IsMatch(str, @"^[+-]?\d*[.]?\d*$"))
            {
                result = int.Parse(str);
            }
        }
        switch (result)
        {
            case 0:
                return 1;
            case 1:
                return 3;
            case 2:
                return 2;
            default:
                break;
        }
        return result;

    }
    public static int getBeWinCard(int id,bool isbeWin) {
        if (id == 1)
        {
            if (isbeWin == true)
                return 3;
            else
                return 2;

        }
        else if (id == 2)
        {
            if (isbeWin == true)
                return 1;
            else
                return 3;
        }
        else if (id == 3)
        {
            if (isbeWin == true)
                return 2;
            else
                return 1;

        }
        return id;
    }

    public static T GetAppSetting<T>(this string key) {
        try
        {

            var converter = TypeDescriptor.GetConverter(typeof(T));
            if (converter != null)
            {
                return (T)converter.ConvertFromString(key);

            }
            return default(T);
        }
        catch (NotSupportedException)
        {
            return default(T);
        }
         

    }



}

