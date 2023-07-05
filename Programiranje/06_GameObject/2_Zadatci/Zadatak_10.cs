using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Svakih 5 sekudni neka se u debug.logu ispiše "ja sam magarac"

public class Zadatak_10 : MonoBehaviour
{
    public float timer = 5;

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Debug.Log("Ja sam magarac");
            timer = 5;
        }
    }
}
