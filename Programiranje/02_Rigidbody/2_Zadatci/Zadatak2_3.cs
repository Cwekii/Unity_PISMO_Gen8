using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Rigidboyu na pritisak tipke "K" ukljucite ili iskljucite kinematiku,
// a na klik g uključite ili isključite gravitaciju

public class Zadatak2_3 : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            rb.isKinematic = !rb.isKinematic;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            rb.useGravity = !rb.useGravity;
        }
    }
}
