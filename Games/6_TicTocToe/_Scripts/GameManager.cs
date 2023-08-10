using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Text[] textFieldArray; //text polja

    public InputField playerOneInputField;
    public InputField playerTwoInputField;

    [SerializeField] GameObject gameOverPanel;

    [SerializeField] Text scorePlayerOne; //iznos bodova playera 1 na game panel-u
    [SerializeField] Text scorePlayerTwo; //iznos bodova playera 2 na game panel-u


    [SerializeField] Text movesText; //ispis broja poteza

    public string playerSide; // Moze imati vrijednos X ili O

    string playerOneName;
    string playerTwoName;

    public int moves; // Brojac poteza

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        gameOverPanel.SetActive(false);


        playerSide = "X";
        moves = 1;

        for (int i = 0; i < textFieldArray.Length; i++)
        {
            textFieldArray[i].text = null;
            textFieldArray[i].GetComponentInParent<Button>().interactable = true;
        }

        movesText.text = $"Move {moves}.";

        scorePlayerOne.text = $"{playerOneName}: {PlayerPrefs.GetInt("ScoreP1")}";
        scorePlayerTwo.text = $"{playerTwoName}: {PlayerPrefs.GetInt("ScoreP2")}";
    }

    void ChangeSide()
    {
        if (playerSide == "X")
        {
            playerSide = "O";
        }

        else
        {
            playerSide = "X";
        }

        movesText.text = $"Move {moves}.";
    }

    public void EndGame()
    {
        if (textFieldArray[0].text == playerSide && textFieldArray[1].text == playerSide && textFieldArray[2].text == playerSide)
        {
            CheckWin(playerSide);
        }
        else if (textFieldArray[3].text == playerSide && textFieldArray[4].text == playerSide && textFieldArray[5].text == playerSide)
        {
            CheckWin(playerSide);
        }
        else if (textFieldArray[6].text == playerSide && textFieldArray[7].text == playerSide && textFieldArray[8].text == playerSide)
        {
            CheckWin(playerSide);
        }
        else if (textFieldArray[0].text == playerSide && textFieldArray[3].text == playerSide && textFieldArray[6].text == playerSide)
        {
            CheckWin(playerSide);
        } 
        else if (textFieldArray[1].text == playerSide && textFieldArray[4].text == playerSide && textFieldArray[7].text == playerSide)
        {
            CheckWin(playerSide);
        }
        else if (textFieldArray[2].text == playerSide && textFieldArray[5].text == playerSide && textFieldArray[8].text == playerSide)
        {
            CheckWin(playerSide);
        }
        else if (textFieldArray[0].text == playerSide && textFieldArray[4].text == playerSide && textFieldArray[8].text == playerSide)
        {
            CheckWin(playerSide);
        }
        else if (textFieldArray[2].text == playerSide && textFieldArray[4].text == playerSide && textFieldArray[6].text == playerSide)
        {
            CheckWin(playerSide);
        }

        else if (moves > 9)
        {
            CheckWin("bilosta");
        }

        ChangeSide();
    }

    void CheckWin(string whoWins)
    {
        //O je pobjedio
        gameOverPanel.SetActive(true);
        if (whoWins == "O")
        {
            // player two wins
            gameOverPanel.GetComponentInChildren<Text>().text = $"{playerTwoName} Wins";
            PlayerPrefs.SetInt("ScoreP2", PlayerPrefs.GetInt("ScoreP2") + 1);
        }

        //X je pobjedio
        else if (whoWins == "X")
        {
            // player one Wins
            gameOverPanel.GetComponentInChildren<Text>().text = $"{playerOneName} Wins";
            PlayerPrefs.SetInt("ScoreP1", PlayerPrefs.GetInt("ScoreP1") + 1);
        }
        
        else
        {
            //napraviti panel za TIE
            gameOverPanel.GetComponentInChildren<Text>().text = "TIE!!";
        }
    }

    public void ResetGame()
    {
        Start();
    }

    public void SetUpName()
    {
        if (playerOneInputField.text != "" && playerTwoInputField.text != "")
        {
            PlayerPrefs.SetString("PlayerOne", playerOneInputField.text);
            PlayerPrefs.SetString("PlayerTwo", playerTwoInputField.text);
            playerOneName = PlayerPrefs.GetString("PlayerOne");
            playerTwoName = PlayerPrefs.GetString("PlayerTwo");
        }
    }
}
