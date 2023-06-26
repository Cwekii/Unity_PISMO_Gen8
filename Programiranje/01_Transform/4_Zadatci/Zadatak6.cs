using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROTIRANJE : MonoBehaviour
{
    //Učini da se kocka rotira po svim osima u isto vrijeme na najkraći način.
    private void Update()
    {
        transform.Rotate(Vector3.one);

    }
}
