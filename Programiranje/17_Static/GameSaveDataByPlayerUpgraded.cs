using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameSaveDataByPlayerUpgraded
{
    public static int score = PlayerPrefs.GetInt("score");
    public static float rezultat = PlayerPrefs.GetFloat("rezultatek");
    public static GameObject playerObject;

    public static int IntLoadData(string player)
    {
        score = PlayerPrefs.GetInt("score" + player);
        return score;
    }

    public static float FloatLoadData(string player)
    {
        return PlayerPrefs.GetFloat("rezultatek" + player);
    }

    public static void QuickSaveMe(float rez, int scorere, string player)
    {
        PlayerPrefs.SetInt("score" + player, scorere);
        PlayerPrefs.SetFloat("rezultatek" + player, rez);
    }
}
