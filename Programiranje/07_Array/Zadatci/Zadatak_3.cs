using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Napravite skriptu koja ima javni array stringova.
 * U metodi start neka se uz pomoću for petlje ispiše vrijednost svakoga stringa iz arraya u debugu.
 */

public class Zadatak_3 : MonoBehaviour
{
    public string[] strings;

    private void Start()
    {
        for(int i = 0; i < strings.Length; i++)
        {
            Debug.Log(strings[i]);
        }
    }
}
