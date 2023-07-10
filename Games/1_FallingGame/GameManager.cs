using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    public int life = 3;
    public Text scoreText;
    public Text lifeText;
    public Text hihgscoreText;
    public GameObject endGameScreen;
    public Spawner[] spw;
    public Movement mvm;
    bool isPaused = false;

    private void Start()
    {
        scoreText.text = "Score " + score;
        lifeText.text = "Life " + life;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ExitGame();
        }
    }

    public void StartGame()
    {
        for (int i = 0; i < spw.Length; i++)
        {
            spw[i].enabled = true;
        }
        mvm.enabled = true;
    }

    public void DodajScore()
    {
        score++;
        Debug.Log("<color=green>Score is " + score + "</color> and <color=red> life is: " + life + "</color>");
        scoreText.text = "Score " + score;
    }

    public void MakniZivot()
    {
        life--;
        Debug.Log("<color=green>Score is " + score + "</color> and <color=red> life is: " + life + "</color>");
        if(life <= 0)
        {
            ShowHighscore();
        }
        lifeText.text = "Life " + life;

    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void PauseGame()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            Time.timeScale = 0;
        }
        else if (!isPaused)
        {
            Time.timeScale = 1;
        }
    }

    public void ShowHighscore()
    {
        hihgscoreText.text = "END GAME YOUR HIGHSCORE IS: " + score;
        for (int i = 0; i < spw.Length; i++)
        {
            spw[i].enabled = false;
        }
        mvm.enabled = false;
        endGameScreen.SetActive(true);
    }
}
