using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Dodjeliti rigidbody na skriptu

public class Zadatak1 : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
