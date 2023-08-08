using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak4 : MonoBehaviour
{
    /*
     Napisite skriptu koja ce na on trigger enter metodi pozvati
    invoke i nakon 5 sekundi ispisati "nisi uspio pobjeci" ( scenu poslozite po svojoj zelji)
     */

    private void OnTriggerEnter(Collider other)
    {
        Invoke(nameof(LooseCondition), 5);
    }

    void LooseCondition()
    {
        Debug.Log("nisi uspio pobjeci");
    }
}
