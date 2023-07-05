using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Kada kocka dotakne sferu, neka se sfera ugasi

public class Zadatak_4 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.SetActive(false);
    }
}
