using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak3 : MonoBehaviour
{
    /*
     Napisite skrtu koristeci Invoke gdje nakon 10 sekundi od pocetka igre se ispise "Bravo!" 
     */



    private void Start()
    {
        Invoke(nameof(TextUI), 10);
    }

    private void TextUI()
    {
        Debug.Log("Bravo!");
    }
}
