using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveExampleByPlayerUpgraded : MonoBehaviour
{
    float scoreFloat;
    int scoreInt;
    public Text scoreText;
    public string playerName;

    private void Start()
    {
        scoreFloat = GameSaveData.FloatLoadData(playerName); /*PlayerPrefs.GetFloat("rezultatek");*/
        scoreInt = GameSaveData.IntLoadData(playerName); /*PlayerPrefs.GetInt("score")*/;
        scoreText.text = playerName + "\n"
            + "Has score: " + scoreInt + "\n"
            + "resoult is: " + scoreFloat;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            scoreFloat += 0.5f;
            scoreInt++;
            scoreText.text = playerName + "\n" + "Has score: " + scoreInt + "\n" + "resoult is: " + scoreFloat;
        }

        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            scoreFloat -= 0.5f;
            scoreInt--;
            scoreText.text = playerName + "\n" + "Has score: " + scoreInt + "\n" + "resoult is: " + scoreFloat;
        }
    }

    public void QuickSave()
    {
        GameSaveData.QuickSaveMe(scoreFloat, scoreInt, playerName);
    }
}
