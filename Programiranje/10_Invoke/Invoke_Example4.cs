using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke_Example4 : MonoBehaviour
{
    int counter = 0;

    private void Start()
    {
        InvokeRepeating("SpawnObject", 5f, 1f);
    }

    void SpawnObject()
    {
        GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        sphere.transform.position = new Vector3(counter, counter, 0);
        counter++;
    }
}
