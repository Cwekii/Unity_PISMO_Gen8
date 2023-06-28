using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Učitajte rigidbody bez povlačenja

public class Zadatak2_1 : MonoBehaviour
{
    Rigidbody rb;    
    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }
}
