using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Skripta za zaključavanje rotacije po z osi, te kretanja po Y osi

public class Zadatak4 : MonoBehaviour
{
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezePositionY;
    }
}
