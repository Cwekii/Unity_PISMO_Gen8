using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLanguage : MonoBehaviour
{
    public string jezik = "en";

    public void OnClickChangeLanguage()
    {
        PlayerPrefs.SetString("Language", jezik);
        Debug.Log("savean je novi jezik");

        LanguageTranslation.LoadLanguage();
        Debug.Log("Usije�no u�itan jezik");

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
