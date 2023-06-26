using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Neka se sfera pozicionira na poziciju 0, 12, 3.75 u početku igre

public class Zadatak_8 : MonoBehaviour
{
    private void Start()
    {
        transform.position = new Vector3(0, 12, 3.75f);
    }
}
