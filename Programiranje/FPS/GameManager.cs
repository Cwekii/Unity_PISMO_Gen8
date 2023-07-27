using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] SpawnPoints; // array za spawnPoints te spawnPoints �emo postavljati po levelu
    public GameObject[] Enemies; // tu �emo stavljati na�e prefabs od neprijatelja 

    private void Start()
    {
        InvokeRepeating("spawnEnemy", 0, 3);
    }
    void spawnEnemy()
    {
        int randomSpawnPoint = Random.Range(0, SpawnPoints.Length);
        int randomEnemy = Random.Range(0, Enemies.Length);
        Instantiate(Enemies[randomEnemy], SpawnPoints[randomSpawnPoint].position, Quaternion.identity);

    }
}
