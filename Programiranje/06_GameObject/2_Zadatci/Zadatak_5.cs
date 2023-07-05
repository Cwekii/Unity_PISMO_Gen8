using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kada kocka prođe kroz sferu (izlaz) neka se deaktivira skripta

public class Zadatak_5 : MonoBehaviour
{
    private void Update()
    {
        Debug.Log("Skripta je aktivna!");
    }

    private void OnTriggerExit(Collider other)
    {
        this.enabled = false;
    }
}
