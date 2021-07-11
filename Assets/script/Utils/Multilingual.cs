using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.script.Utils
{
    public class Multilingual
    {


        public static int LanguageLength()
        {
            return Enum.GetValues(typeof(languageType)).Length;
        }
        public static Array getLanguage()
        {
            return Enum.GetValues(typeof(languageType));
        }
    }


    [Serializable]
    public class languageString{
        public string china;
        public string english;
        public string japanense;



    }


    public enum languageType
    {
        china,
        english,
        japanense

    }
}
