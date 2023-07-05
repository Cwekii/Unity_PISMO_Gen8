using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Neka se svakih 5 sekundi stvori kocka (prefab) na poziciji 0,(redni broj stvorene kocke), 0

public class Zadatak_9 : MonoBehaviour
{
    public GameObject prefab;
    int stvorenaKocka;
    float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            Instantiate(prefab, new Vector3(0, stvorenaKocka, 0), Quaternion.identity);
            stvorenaKocka++;
            timer = 0;
        }
    }
}
