using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Napravite skriptu Koja ima array intova.
 * U inspektoru upišite neku dužinu tog arraya.
 * U metodi start ispišite u debugu koliko je dugačak array.
 */

public class Zadatak_2 : MonoBehaviour
{
    public int[] intici;

    private void Start()
    {
        Debug.Log(intici.Length);
    }
}
