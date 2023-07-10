using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs = new GameObject[3];
    public Transform[] spawns = new Transform[3];

    public int brojPrefaba;
    public int brojTransforma;

    float timer;

    private void Start()
    {
        Instantiate(enemyPrefabs[brojPrefaba], spawns[brojTransforma].position, Quaternion.identity);
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            Instantiate(enemyPrefabs[Random.Range(0, enemyPrefabs.Length)],
                spawns[Random.Range(0, spawns.Length)].position, Quaternion.identity);
            timer = 2f;
        }
    }
}
