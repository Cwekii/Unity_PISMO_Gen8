using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke_Example2 : MonoBehaviour
{
    private void Start()
    {
        Invoke("StvoriKocku", 5f);
    }

    void StvoriKocku()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, 0, 0);
    }
}
