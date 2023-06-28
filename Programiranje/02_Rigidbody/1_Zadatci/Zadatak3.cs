using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Skripta koja objekt kreće po x osi uz pomoć sile

public class Zadatak3 : MonoBehaviour
{
    public float brzina;
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //Kada radimo sa silama koristimo FixedUdate, a ne obicni update zbog optimizacije
    private void FixedUpdate()
    {
        rb.AddForce(transform.right * brzina);
    }
}
