using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globelstate {

    // Use this for initialization
    public enum state
    { save,
        unstart,
        start,
        load

    }
    public enum language
    {
        china,
        english,
        japanense

    }
    public enum Lookstate {
        mainCamera,
        eitherCamera
    }

    public static int LanguageLength(){
        return Enum.GetValues(typeof(language)).Length;
    }
    public static Array getLanguage() {
        return Enum.GetValues(typeof(language));
    }
}
