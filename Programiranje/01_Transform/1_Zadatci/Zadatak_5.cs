using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Povećajte kocku za javne vrijednosti za sve tri osi i povećavajte ju za te vrijednosti po osima svaku sekundu

public class Zadatak_5 : MonoBehaviour
{
    public float xScale;
    public float yScale;
    public float zScale;

    private void Update()
    {
        transform.localScale += new Vector3(xScale, yScale, zScale) * Time.deltaTime;
    }
}
