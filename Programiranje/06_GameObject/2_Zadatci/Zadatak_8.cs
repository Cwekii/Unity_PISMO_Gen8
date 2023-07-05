using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Neka se svakih 10 sekundi stvori kocka(prefab) na poziciji 0,0,0

public class Zadatak_8 : MonoBehaviour
{
    public GameObject prefab;
    public float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 10)
        {
            Instantiate(prefab, new Vector3(0, 0, 0), Quaternion.identity);
            timer = 0;
        }
    }
}
