using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kada kocka padne na sferu neka se uništi sfera

public class Zadatak_3 : MonoBehaviour
{
    private void OnTriggerEnter(Collider coll)
    {
        Destroy(coll.gameObject);
    }
}
