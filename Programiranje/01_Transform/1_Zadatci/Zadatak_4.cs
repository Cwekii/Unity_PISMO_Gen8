using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Povećajte kocku za 0.1 svaki frame

public class Zadatak_4 : MonoBehaviour
{
    private void Update()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }
}
