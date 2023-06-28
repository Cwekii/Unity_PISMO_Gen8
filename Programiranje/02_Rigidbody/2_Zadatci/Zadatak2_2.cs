using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// U skripti definirajte janvu varijablu "mass". 
// Rigidbodyu povećajte težinu NA vrijednost javne varijable

public class Zadatak2_2 : MonoBehaviour
{
    public float masa = 3;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.mass = masa;
    }
}
