using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Napišite skriptu koja ispisuje u debugu kada je cube ušao u sferu, 
 * kada je unutra i kada je izašao.
 */

public class Zadatak_1 : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ušao je");
    }
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Unutra je");
    }
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Izašao je van");
    }
}
