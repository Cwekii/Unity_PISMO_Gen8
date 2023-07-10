using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab; //predemt koji se stvara
    public float timer = 3f; //vremenski period za stvaranje objekta
    float timerReset; //Vraćanje timera na početnu vrijednost

    private void Start()
    {
        timerReset = timer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            float randomPozicijaX = Random.Range(-8.5f, 8.5f);
            Instantiate(prefab, new Vector3(randomPozicijaX, 9, 0), Quaternion.identity);
            timer = timerReset;
        }
    }
}
