using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizController : MonoBehaviour
{
    [SerializeField]
    private UIcontroller uIcontroller;
    [SerializeField]
    private QuestionCollection questionCollection;
    private QuizQuestion currentQuestion;
    [SerializeField]
    private float delayTime = 3f; //vrijeme nakon što se odgovori, koliko se èeka za novo pitanje

    private void Start()
    {
        ShowQuestion();
    }

    void ShowQuestion()
    {
        //Dohvati ne postavljeno pitanje
        currentQuestion = questionCollection.GetUnaskedQuestion();
        //Ne postavljeno pitanje prikaži na UI-u
        uIcontroller.SetUpUIForQuestion(currentQuestion);
    }

    public void SubmitAnswer(int answerNumber)
    {
        //if(answerNumber == currentQuestion.CorrectAnswer)
        //{
        //    uIcontroller.CheckUpPressedButton(true);
        //}
        //UI da odradi svoje kada se odgovori
        uIcontroller.CheckUpPressedButton(answerNumber == currentQuestion.CorrectAnswer);

        //Uèitaj novo pitanje
        StartCoroutine(ShowNextQuestionAfterDelay());
    }

    IEnumerator ShowNextQuestionAfterDelay()
    {
        yield return new WaitForSeconds(delayTime);
        ShowQuestion();
    }
}
