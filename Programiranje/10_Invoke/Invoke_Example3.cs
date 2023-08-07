using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke_Example3 : MonoBehaviour
{
    public float timer = 0;
    int counter = 0;

    private void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 2)
        {
            Invoke("SpawnObject", 1f);
            timer = 0;
            counter++;
        }
    }

    void SpawnObject()
    {
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = new Vector3(0, counter, counter);
    }
}
