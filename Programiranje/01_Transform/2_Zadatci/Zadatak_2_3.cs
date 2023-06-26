using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 3.) Napišite skriptu koja će imati Debug.Log() na:
a) Awake
b) Start
c) Update
*/

public class Zadatak_2_3 : MonoBehaviour
{
    //a
    private void Awake()
    {
        Debug.Log("Awake");
    }
    //b
    private void Start()
    {
        Debug.Log("Start");
    }
    //c
    private void Update()
    {
        Debug.Log("Update");
    }
}
