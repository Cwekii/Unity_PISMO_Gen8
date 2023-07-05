using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napravite skriptu sa 5 public objekata, na tipku "S" ih sve gasite ili palite,
// na tipku "K" palite ili gasite samo jednog (po vasem izboru)

public class Zadatak_5 : MonoBehaviour
{
    public GameObject objekatEin;
    public GameObject objekatZwei;
    public GameObject objekatDrei;
    public GameObject objekatVier;
    public GameObject objekatFunf;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            objekatEin.SetActive(!objekatEin.activeSelf);
            objekatZwei.SetActive(!objekatZwei.activeSelf);
            objekatDrei.SetActive(!objekatDrei.activeSelf);
            objekatVier.SetActive(!objekatVier.activeSelf);
            objekatFunf.SetActive(!objekatFunf.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            objekatDrei.SetActive(!objekatDrei.activeSelf);
        }
    }
}
