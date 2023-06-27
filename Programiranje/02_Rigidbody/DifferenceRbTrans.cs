using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifferenceRbTrans : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    private void Start()
    {
        var ivo = "krivo" + new Vector3(46, 90, 39) + (3.4f + 0.1f * 11 )+ true;
        Debug.Log(ivo);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rb.AddForce(Vector3.left * speed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector3.right * speed);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1, 0, 0) * Time.deltaTime * speed;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(0.3f, 0, 0) * Time.deltaTime * speed;
        }
    }
}
