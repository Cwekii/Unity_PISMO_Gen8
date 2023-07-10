using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour
{
    public float scoreValue; //koliko vrijedi ovaj objekt ako ga se pickupa

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameManager gm = FindObjectOfType<GameManager>();
            gm.score += scoreValue;
            Destroy(this.gameObject);
        }
    }
}
