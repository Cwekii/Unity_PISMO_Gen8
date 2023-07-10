using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    [Header("True = Good prefab | False = Bad prefab")]
    public bool isPositive = true;
    public GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(isPositive)
        {
            if(other.gameObject.tag == "Player")
            {
                gm.DodajScore();
                Destroy(this.gameObject);
            }
            if(other.gameObject.tag == "Floor")
            {
                Destroy(this.gameObject);
            }
        }
        else if(!isPositive)
        {
            if(other.gameObject.tag == "Player")
            {
                gm.MakniZivot();
                Destroy(this.gameObject);
            }
            if (other.gameObject.tag == "Floor")
            {
                Destroy(this.gameObject);
            }
        }
    }
}
