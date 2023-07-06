using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 10f; // vrijednost za brzinu

    //u startu dodjeljujemo rb u skriptu
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //kretanje desno
        if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right * speed);
        }
        // kretanje lijevo
        if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left * speed);
        }
    }
}
