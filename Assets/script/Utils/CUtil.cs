

using System;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Collections;
using UnityEngine;

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
    public static Hashtable Hash(params object[] args)
    {
        Hashtable hashTable = new Hashtable(args.Length / 2);
        if (args.Length % 2 != 0)
        {
            Debug.LogError("Tween Error: Hash requires an even number of arguments!");
            return null;
        }
        else
        {
            int i = 0;
            while (i < args.Length - 1)
            {
                hashTable.Add(args[i], args[i + 1]);
                i += 2;
            }
            return hashTable;
        }
    }
    public static String idToMaterialString(int id) {
        string t ="";
       if (id==11)
            t= "Materials/扑克j";//剪刀
       else if(id==12)
            t = "Materials/扑克q";//步
        else if (id == 13)
            t = "Materials/扑克k";//石头
        return t;
    }

    public static String idToCardBackString(int id) {
        string t = "";
        if (id == 11)
            t = "Materials/cardback1";//剪刀
        else if (id == 12)
            t = "Materials/cardback0";//步
        else if (id == 13)
            t = "Materials/cardback2";//石头
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
        //switch (result)
        //{
        //    case 0:
        //        return 1;
        //    case 1:
        //        return 3;
        //    case 2:
        //        return 2;
        //    default:
        //        break;
        //}
        return result;

    }
    public static int getBeWinCard(int id,bool isbeWin) {
        if (id == 11)
        {
            if (isbeWin == true)
                return 13;
            else
                return 12;

        }
        else if (id == 12)
        {
            if (isbeWin == true)
                return 11;
            else
                return 13;
        }
        else if (id == 13)
        {
            if (isbeWin == true)
                return 12;
            else
                return 11;

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

