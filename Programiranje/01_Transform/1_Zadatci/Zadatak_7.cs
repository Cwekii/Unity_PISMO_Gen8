using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Neka se sfera miče za 0.1 po sve tri osi svaki frame

public class Zadatak_7 : MonoBehaviour
{
    private void Update()
    {
        transform.position += new Vector3(0.1f, 0.1f, 0.1f);
    }
}
