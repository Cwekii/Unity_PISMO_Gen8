using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuestionCollection : MonoBehaviour
{
    //Sva pitanja
    QuizQuestion[] allQuestions;

    private void Awake()
    {
        LoadAllQuestions();
    }

    void LoadAllQuestions()
    {
        allQuestions = Resources.LoadAll<QuizQuestion>("Questions");
    }

    //Povuci ne postavljeno pitanje
    public QuizQuestion GetUnaskedQuestion()
    {
        //AKO SMO SVE ISPUCALI ONDA RESETIRAMO PITANJA DA MOŽEMO NEKO PRIJAŠNJE IZVUÆI
        ResetAllQuestionsIfAllQuestionsHaveBeenAsked();

        //Uèitavanje pitanja koje se postavlja
        var trenutnoPitanje = allQuestions.Where(pitanjeScriptabelObjecta =>
        pitanjeScriptabelObjecta.Asked == false).OrderBy(pitanjeScriptaleObjecta =>
        Random.Range(0, int.MaxValue)).FirstOrDefault();

        trenutnoPitanje.Asked = true;

        return trenutnoPitanje;
    }

    //Provjera jesu li sva pitanja postavljena i ako jesu restartaj pitanja
    void ResetAllQuestionsIfAllQuestionsHaveBeenAsked()
    {
        if(allQuestions.Any(svakoPitanjeZasebno => svakoPitanjeZasebno.Asked == false) == false)
        {
            //foreach
            foreach(QuizQuestion pitanje in allQuestions)
            {
                pitanje.Asked = false;
            }
            //for
            //for (int i = 0; i < allQuestions.Length; i++)
            //    {
            //        allQuestions[i].Asked = false;
            //    }
        }
    }
}
