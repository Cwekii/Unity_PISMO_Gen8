using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* 
5.) Scejlajte kocku za:
a) 0.25 po Y osi svaki frame
b) 89 po Z osi pri pokretanju igre
c) Kada se odradio b) zadatak neka debug ispiše kolika je trenutna veličina Z osi
*/

public class Zadatak_2_5 : MonoBehaviour
{
    //a
    private void Update()
    {
        transform.localScale += new Vector3(0f, 0.25f, 0f);
    }

    //b
    private void Start()
    {
        transform.localScale += new Vector3(0, 0, 89);
        //c
        Debug.Log(transform.localScale.z);
    }
}
