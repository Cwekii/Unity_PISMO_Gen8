using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnemyBehaviour : MonoBehaviour
{
    public SpawnEnemy spawnEnemy;

    public Transform playerPosition;

    [SerializeField] private float enemyMoveSpeed;

    private void Update()
    {
        if (transform.position != playerPosition.position)
        {
            MoveToPlayer();
        }
    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position,
            playerPosition.position,
            enemyMoveSpeed * Time.deltaTime);
    }
    private void OnDisable()
    {
        spawnEnemy.ReturnToPool(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameObject.SetActive(false);
        }
    }



}