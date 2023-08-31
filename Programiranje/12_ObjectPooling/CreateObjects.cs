using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateObjects : MonoBehaviour
{
    /*
     Napraviti Prefab koji ce se spawnati i da se objekt destroya nakon 10 sekundi
    InvokeRepeating 0.2f
    For petlju

     
     */
    public GameObject prefab;
    private void Start()
    {
        InvokeRepeating("Spawn", 0, 0.2f);
    }

    void Spawn()
    {
        int rng;
        rng = Random.Range(12, 54);
        for(int i = 0; i< rng; i++)
        {
            Instantiate(prefab);
        }
    }
}
