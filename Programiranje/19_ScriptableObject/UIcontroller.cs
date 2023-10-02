using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIcontroller : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI questionText;
    [SerializeField]
    private Button[] answerButtons;
    [SerializeField]
    private TextMeshProUGUI timerText;
    [SerializeField]
    private float timer;
    [SerializeField]
    private GameObject correctPanel, wrongPanel, gameOverPanel;


    public void SetUpUIForQuestion(QuizQuestion question)
    {
        //ugasi sve gumbe
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(false);
        }
        correctPanel.SetActive(false);
        wrongPanel.SetActive(false);
        questionText.text = question.Question;

        //Poslože ponuðeni odgovori
        for (int i = 0; i < question.Answers.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = question.Answers[i];
            //upali samo ona sa odgovorom
            answerButtons[i].gameObject.SetActive(true);
        }

        //pokreni timer
        StartTimer();
    }

    void StartTimer()
    {
        CancelInvoke();
        timer = 0;
        timerText.text = timer.ToString();
        InvokeRepeating("TimerLogic", 1f, 1f);
    }

    void TimerLogic()
    {
        timer++;
        timerText.text = timer.ToString();
    }

    public void CheckUpPressedButton(bool isCorrect)
    {
        //ako je toèno
        if(isCorrect)
        {
            correctPanel.SetActive(true);
        }
        //Ako nije toèno
        else
        {
            wrongPanel.SetActive(true);
        }
    }
}
