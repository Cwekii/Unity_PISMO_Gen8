using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rotirajte kocku za 1 stupanj svaki frame po x, y i z osima

public class Zadatak_1 : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1));
    }
}
