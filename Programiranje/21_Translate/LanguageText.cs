using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LanguageText : MonoBehaviour
{
    public string textKey;

    private void Start()
    {
        TextMeshProUGUI textic = GetComponent<TextMeshProUGUI>();
        if(textic!=null)
        {
            if(textic.text == "ISOCode")
            {
                textic.text = LanguageTranslation.GetLanguage();
            }
            else
            {
                textic.text = LanguageTranslation.Fields[textKey];
            }
        }
    }
}
