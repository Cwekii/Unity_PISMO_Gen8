using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Na klik space upaliti ili ugasiti gravitaciju na objektu

public class Zadatak2 : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(rb.useGravity) //isto kao da sam napisao (rb.useGravity == true)
            {
                rb.useGravity = false;
            }
            else if(!rb.useGravity)//isto kao da sam napisao (rb.useGravity == false)
            {
                rb.useGravity = true;
            }
        }
    }
}
