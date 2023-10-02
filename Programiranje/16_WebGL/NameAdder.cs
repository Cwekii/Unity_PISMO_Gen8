using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class NameAdder : MonoBehaviour
{
   // public InputField poljeZaIme;
    [SerializeField] TMP_InputField poljeZaIme;
    private void Start()
    {
        string datum = DateTime.Now.Day.ToString() + "." + DateTime.Now.Month.ToString() + "." + DateTime.Now.Year.ToString() + ".";
        PlayerPrefs.SetString("Datum", datum);
    }

    public void DajMiCestitku()
    {
        PlayerPrefs.SetString("Ime", poljeZaIme.text);
        SceneManager.LoadScene("CestitkaScene");
    }
}
