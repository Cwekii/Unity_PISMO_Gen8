using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Napravite skriptu koja svaki frame pali/gasi objekt.
 * Na tipku F skripta to prestaje raditi.
 * Kada se stisne opet tipka F skripta opet o počinje raditi (obavezno koristiti vlastitu metodu)
 */

public class Zadatak_8 : MonoBehaviour
{
    bool radi = true;

    public GameObject objekt;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            radi = !radi; //promjeiti ce se vrijednost radi ako je bio true biti ce false a ako je bio false onda true
        }
        if(radi)
        {
            PaliGasi();
        }
    }

    void PaliGasi()
    {
        if (objekt.activeSelf == true)
        {
            objekt.SetActive(false);
        }
        else if (objekt.activeSelf == false)
        {
            objekt.SetActive(true);
        }
    }
}
