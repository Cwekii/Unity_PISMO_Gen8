using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] GameObject enemyPrefab;
    [SerializeField] Transform playerPosition;

    [SerializeField] float enemySpawnTimer;

    private Queue<GameObject> enemyPool = new Queue<GameObject>();
    public int enemyPoolSize;
    public bool isGameOver;


    private void Start()
    {
        InitializeEnemy();
        StartCoroutine(EnemySpawnActivation());
    }

    private void InitializeEnemy()
    {
        for (int i = 0; i < enemyPoolSize; i++)
        {
            GameObject tempObject = Instantiate(enemyPrefab);
            EnemyBehaviour behavior = tempObject.GetComponent<EnemyBehaviour>();
            behavior.spawnEnemy = this;
            behavior.playerPosition = playerPosition;
            tempObject.SetActive(false);
        }
    }

    public void ReturnToPool(GameObject enemy)
    {
        
        enemyPool.Enqueue(enemy);
    }

    IEnumerator EnemySpawnActivation()
    {
        while (!isGameOver)
        {
            int position = Random.Range(5, 15);
            yield return new WaitForSeconds(enemySpawnTimer);
            GameObject enemy = enemyPool.Dequeue();

            enemy.transform.position = new Vector3(playerPosition.position.x + position, 
                playerPosition.position.y, playerPosition.position.z + position);
            enemy.SetActive(true);
           
            if (enemyPool.Count == 0)
            {
                GameObject tempObject = Instantiate(enemyPrefab);
                EnemyBehaviour behavior = tempObject.GetComponent<EnemyBehaviour>();
                behavior.spawnEnemy = this;
                behavior.playerPosition = playerPosition;
                tempObject.SetActive(false);
            }

           
        }


    }

}
