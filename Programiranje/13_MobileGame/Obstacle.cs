using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] float obstacleSpeed;


    private void Update()
    {
        MoveObstacle();
    }

    private void MoveObstacle()
    {
        transform.position += Vector3.left * obstacleSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.instance.GameOver();
        }

        if (collision.gameObject.CompareTag("Finish"))
        {
            GameManager.instance.ResetPosition(gameObject);
        }
    }
}
