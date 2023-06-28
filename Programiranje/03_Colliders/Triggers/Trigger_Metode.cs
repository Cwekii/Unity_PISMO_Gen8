using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//KAKO BI RADIO ON TRIGGER BAREM JEDAN OD OBJEKATA MORA IMATI RIGIDBODY
// MORA BITI UKLJUČEN ISTRIGGER NA OBJEKTU

public class Trigger_Metode : MonoBehaviour
{
    public float Health = 100;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Ušao je");
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Vrata")
        {
            Health += 10 * Time.deltaTime;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Vrata")
        {
            Debug.Log("Izašao je");
        }
    }
}
