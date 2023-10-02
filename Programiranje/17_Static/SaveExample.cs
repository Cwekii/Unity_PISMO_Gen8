using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveExample : MonoBehaviour
{
    float scoreFloat;
    int scoreInt;
    public Text scoreText;
    public string playerName;

    protected void Start()
    {
        scoreInt = GameSaveData.score;
        scoreFloat = GameSaveData.rezultat;
        scoreText.text = playerName + "\n" + " has score: " + scoreInt + "\n" + " and it resoult is: " + scoreFloat;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            scoreFloat += 0.5f;
            scoreInt++;
            scoreText.text = playerName + "\n" + " has score: " + scoreInt + "\n" + " and it resoult is: " + scoreFloat;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            scoreFloat -= 0.5f;
            scoreInt--;
            scoreText.text = playerName + "\n" + " has score: " + scoreInt + "\n" + " and it resoult is: " + scoreFloat;
        }
    }

    public void QuickSave()
    {
        GameSaveData.QuickSaveMe(scoreFloat, scoreInt, playerName);
    }
}
