using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Unesite dvije javne vrijednosti (float i int) ako je njihov zbroj veći od 20 neka se sve osi povećaju za 20, a ako je njihov
//zbroj manji ili jednak od 20 neka se objekt po svim osima smanji za zbrojenu vrijednost.

public class Zadatak_2 : MonoBehaviour
{
    public float x;
    public int y;
    public float zbroj;

    private void Start()
    {
        zbroj = x + y;
        if (zbroj > 20)
        {
            transform.localScale += new Vector3(20, 20, 20);
        }
        else if (zbroj <= 20)
        {
            transform.localScale -= new Vector3(zbroj, zbroj, zbroj);
        }
    }
}
