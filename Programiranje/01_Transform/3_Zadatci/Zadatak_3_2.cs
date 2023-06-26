using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napišite skriptu koja kocku povećava ili smanjuje za javne vrijednosti u beskonaćnost

public class Zadatak_3_2 : MonoBehaviour
{
    public float xScale;
    public float yScale;
    public float zScale;

    public bool increase = true;
    public bool decsrease = false;

    private void Update()
    {
        if(increase == true && decsrease == false)
        {
            transform.localScale += new Vector3(xScale, yScale, zScale);
        }
        else if(decsrease == true && increase == false)
        {
            transform.localScale -= new Vector3(xScale, yScale, zScale);
        }
        else
        {
            Debug.Log("Nisi odabrao hoćeš li da se objekt smanjuje ili povećava");
        }
    }
}
