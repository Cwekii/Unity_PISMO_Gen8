using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Rotirajte kocku za javnu vrijednost po sve tri osi svake sekunde

public class Zadatak_3 : MonoBehaviour
{
    public float sveRotation;

    private void Update()
    {
        transform.Rotate(new Vector3(sveRotation, sveRotation, sveRotation) * Time.deltaTime);
    }
}
