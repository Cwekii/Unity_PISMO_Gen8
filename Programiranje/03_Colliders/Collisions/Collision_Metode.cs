using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision_Metode : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Dotakli su se");
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Diraju se");
    }
    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Više se ne diraju :(");
    }
}
