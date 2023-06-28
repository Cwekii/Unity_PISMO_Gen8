using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napravite skriptu koja ima javnu varijablu "Health".
// Kada cube stoji u sferi neka gubi health za "5 * Time.deltaTime"

public class Zadatak_3 : MonoBehaviour
{
    public float Health;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Sfera")
        {
            Health -= 5 * Time.deltaTime;
        }
    }
}
