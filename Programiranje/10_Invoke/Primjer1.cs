using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Primjer1 : MonoBehaviour
{
    /*
     Napisite skriptu timera koristeci InvokeRepeating.
    Vrijeme se mora zapisivati i prikazivati na UI textu
    npr: 01:33, 00:28, 10:45 itd. (vrijeme raste od 00:00 do 59:59
     */


    public float secondTimer;
    public float minuteTimer;

    [SerializeField] Text timerText;

    private void Start()
    {
        timerText.text = string.Format("{00:00}:{01:00}", minuteTimer, secondTimer);
        InvokeRepeating(nameof(Timer), 1,1);
    }

    private void Timer()
    {
        secondTimer++;

        if (minuteTimer >= 59 && secondTimer > 59)
        {
            minuteTimer = 0;
            secondTimer = 0;
        }

        if (secondTimer >= 60)
        {
            minuteTimer++;
            secondTimer = 0;
        }

        timerText.text = string.Format("{00:00}:{01:00}", minuteTimer, secondTimer);
    }
}
