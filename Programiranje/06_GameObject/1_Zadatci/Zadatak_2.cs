using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//U updatu palite ili gasite game object ovisno o njegovom stanju konstantno u suprotno

public class Zadatak_2 : MonoBehaviour
{
    public GameObject predmet;

    private void Update()
    {
        if(predmet.activeSelf == true)
        {
            predmet.SetActive(false);
        }
        else if (predmet.activeSelf == false)
        {
            predmet.SetActive(true);
        }
    }
}
