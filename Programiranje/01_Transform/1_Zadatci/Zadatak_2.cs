using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rotirajte kocku za 1 stupanj svake sekunde po x, y i z osima

public class Zadatak_2 : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(new Vector3(1, 1, 1) * Time.deltaTime);
    }
}
