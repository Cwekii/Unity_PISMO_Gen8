using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// U start metodu napravite var vrstu varijable gdje pristupate 
// isključivo gravitaciji rigidbodya te ju isključite

public class Zadatak2_4 : MonoBehaviour
{
     void Start()
    {
        var gravity = GetComponent<Rigidbody>().useGravity;
        gravity = false;
    }
}
