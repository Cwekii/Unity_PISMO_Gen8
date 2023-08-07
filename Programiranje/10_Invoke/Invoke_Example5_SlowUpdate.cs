using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke_Example5_SlowUpdate : MonoBehaviour
{
    [Header("Interval slowUpdatea")]
    public float slowUpdateInterval = 0.03f;
    float i;

    private void Start()
    {
        InvokeRepeating("SlowedUpdate", slowUpdateInterval, slowUpdateInterval);
    }

    void SlowedUpdate()
    {
        i += Time.deltaTime;
        Debug.Log(i);
    }
}
