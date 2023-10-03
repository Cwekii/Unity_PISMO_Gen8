using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

class LanguageTranslation
{
    public static Dictionary<String, String> Fields
    {
        get;
        private set;
    }

    static LanguageTranslation()
    {
        LoadLangugae();
    }

    public static void LoadLangugae()
    {
        //Nemamo dictionary
        if(Fields == null)
        {
            Fields = new Dictionary<string, string>();
        }

        //Očisti da nema sukoba istih keyeva
        Fields.Clear();

        //U slučaju da imate playerPrefs sa jezikom da se pamti ovako možete učitati zadnji korišteni jezik
        string lang = PlayerPrefs.GetString("Language");

        //Učitavanje traženog jezika
        var textAsset = Resources.Load("Languages/" + lang);

        //Jezik koji smo htjeli učitati ne postoji pa cemo staviti defoultini
        if(textAsset == null)
        {
            textAsset = Resources.Load("Languages/en.txt");
            Debug.Log("File not found in folder, there is no: " + lang + ".txt file");
        }

        string allTexts = (textAsset as TextAsset).text;

        string key, value;
        //Array ce biti onoliko koliko mi imamo redova u našem tekst dokumentu
        string[] lines = allTexts.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
        //Formatiranje
        for (int i = 0; i < lines.Length; i++)
        {
            key = lines[i].Substring(0, lines[i].IndexOf("="));
            value = lines[i].Substring(lines[i].IndexOf("=") + 1);
            Fields.Add(key, value);
        }
    }

    public static string GetLanguage()
    {
        //Vraća nam vrijednost jezika, ali sa malim slovima npr. (HR u hr)
        return Get2LetterISOCodeFromSystemLanguage().ToLower();
    }

    public static string Get2LetterISOCodeFromSystemLanguage()
    {
        //vrijednost lang vučemo iz sistema - provjera koji jezik uređaj koristi
        SystemLanguage lang = Application.systemLanguage;
        //string u koji se pohranjuje skraceni naziv jezika (ISO code 2 letters)
        string ISOshorcut = "HR";

        switch(lang)
        {
            case SystemLanguage.Afrikaans: ISOshorcut = "AF"; break;
            case SystemLanguage.Arabic: ISOshorcut = "AR"; break;
            case SystemLanguage.Basque: ISOshorcut = "EU"; break;
            case SystemLanguage.Belarusian: ISOshorcut = "BE"; break;
            case SystemLanguage.Bulgarian: ISOshorcut = "BG"; break;
            case SystemLanguage.Catalan: ISOshorcut = "CA"; break;
            case SystemLanguage.Chinese: ISOshorcut = "ZH"; break;
            case SystemLanguage.ChineseSimplified: ISOshorcut = "ZH"; break;
            case SystemLanguage.ChineseTraditional: ISOshorcut = "ZH"; break;
            case SystemLanguage.Czech: ISOshorcut = "CS"; break;
            case SystemLanguage.Danish: ISOshorcut = "DA"; break;
            case SystemLanguage.Dutch: ISOshorcut = "NL"; break;
            case SystemLanguage.English: ISOshorcut = "EN"; break;
            case SystemLanguage.Estonian: ISOshorcut = "ET"; break;
            case SystemLanguage.Faroese: ISOshorcut = "FO"; break;
            case SystemLanguage.Finnish: ISOshorcut = "FI"; break;
            case SystemLanguage.French: ISOshorcut = "FR"; break;
            case SystemLanguage.German: ISOshorcut = "DE"; break;
            case SystemLanguage.Greek: ISOshorcut = "EL"; break;
            case SystemLanguage.Hebrew: ISOshorcut = "IW"; break;
            case SystemLanguage.Hungarian: ISOshorcut = "HU"; break;
            case SystemLanguage.Icelandic: ISOshorcut = "IS"; break;
            case SystemLanguage.Indonesian: ISOshorcut = "IN"; break;
            case SystemLanguage.Italian: ISOshorcut = "IT"; break;
            case SystemLanguage.Japanese: ISOshorcut = "JA"; break;
            case SystemLanguage.Korean: ISOshorcut = "KO"; break;
            case SystemLanguage.Latvian: ISOshorcut = "LV"; break;
            case SystemLanguage.Lithuanian: ISOshorcut = "LT"; break;
            case SystemLanguage.Norwegian: ISOshorcut = "NO"; break;
            case SystemLanguage.Polish: ISOshorcut = "PL"; break;
            case SystemLanguage.Portuguese: ISOshorcut = "PT"; break;
            case SystemLanguage.Romanian: ISOshorcut = "RO"; break;
            case SystemLanguage.Russian: ISOshorcut = "RU"; break;
            case SystemLanguage.SerboCroatian: ISOshorcut = "SH"; break;
            case SystemLanguage.Slovak: ISOshorcut = "SK"; break;
            case SystemLanguage.Slovenian: ISOshorcut = "SL"; break;
            case SystemLanguage.Spanish: ISOshorcut = "ES"; break;
            case SystemLanguage.Swedish: ISOshorcut = "SV"; break;
            case SystemLanguage.Thai: ISOshorcut = "TH"; break;
            case SystemLanguage.Turkish: ISOshorcut = "TR"; break;
            case SystemLanguage.Ukrainian: ISOshorcut = "UK"; break;
            case SystemLanguage.Vietnamese: ISOshorcut = "VI"; break;
            case SystemLanguage.Unknown: ISOshorcut = "EN"; break; //Nepoznat ili ne definiran ovdje je automatski Engleski
        }
        return ISOshorcut;
    }
}
