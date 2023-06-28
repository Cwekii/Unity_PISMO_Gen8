using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Skripta za zaključavanje rotacije po x osi, 
te kretanja po x i y osi, te na klik tipke u otključajte po svim osima, 
a na klik tipke f zaključajte po svim osima (kretanje)
*/

public class Zadatak5 : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationX |
                         RigidbodyConstraints.FreezePositionX |
                         RigidbodyConstraints.FreezePositionY;
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.U))
        {
            rb.constraints = RigidbodyConstraints.None;
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            rb.constraints = RigidbodyConstraints.FreezePosition;
        }
    }
}
