using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zad_transform_4_5 : MonoBehaviour
{
    public int a;
    public int b;
    public float c;
    public float d;
    public float formula_prva;
    public float formula_druga;

    void Update()
    {
        formula_prva = a * b + c - d * a;
        formula_druga = a * b * c / d;
        if (formula_prva >= formula_druga)
        {
            transform.localScale += new Vector3(1, 1, 1) * 1 * Time.deltaTime;
            transform.Rotate(Vector3.right * 2 * Time.deltaTime);
            transform.Rotate(Vector3.up * 2 * Time.deltaTime);
            transform.Rotate(Vector3.forward * 2 * Time.deltaTime);
        }
        else
        {
            transform.localScale -= new Vector3(1, 1, 1) * 2 * Time.deltaTime;
            transform.Rotate(Vector3.right * 1 * Time.deltaTime);
            transform.Rotate(Vector3.up * 1 * Time.deltaTime);
            transform.Rotate(Vector3.forward * 1 * Time.deltaTime);
        }
    }
}