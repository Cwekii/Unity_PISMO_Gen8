using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//5. Napravite skriptu koja na tipku W udara silom na objekt u smjeru X osi,
//na tipku S u negativnom smjeru X osi, na tipku A u pozitivnom smjeru Z osi,
//a na tipku D u negativnom smjeru Z osi

public class Zadatak2_5 : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 3.5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.W))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.AddForce(transform.right * speed);
        }
        if(Input.GetKeyUp(KeyCode.W))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
        }
        if(Input.GetKey(KeyCode.S))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.AddForce(transform.right * -speed);
        }
        if(Input.GetKeyUp(KeyCode.S))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.AddForce(transform.forward * speed);
        }
        if(Input.GetKeyUp(KeyCode.A))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.AddForce(transform.forward * -speed);
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            rb.AddForce(transform.up * speed * 100);
        }
    }
}
