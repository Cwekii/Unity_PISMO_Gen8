using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSaveData
{
    public static int score = PlayerPrefs.GetInt("score");
    public static float rezultat = PlayerPrefs.GetFloat("rezultatek");
    public static GameObject playerObject;

    public static void QuickSaveMe(float rez, int scorerere, string player)
    {
        PlayerPrefs.SetFloat("rezultatek" + player, rez);
        PlayerPrefs.SetInt("score" + player, scorerere);
    }
}
