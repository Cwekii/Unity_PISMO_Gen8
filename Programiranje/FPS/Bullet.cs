using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f; // Brzina kretenja metka
    public float lifetime = 2f; // Vrijeme trajanja metka

    public float damage = 10f; // šteta koju metak nanosi

    private void Start()
    {
        Destroy(gameObject, lifetime);// uništi metak nako vremena lifetime
    }

    private void Update()
    {
        //kretanje metka prema naprijed
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // kada metak dotakne Enemy-a, Enemy prima damage
            EnemyAI enemyAI = other.GetComponent<EnemyAI>();

            //Pozovi metodu za ošteæenje neprijatelja u skripti "GunController"
            GunController gunController = GetComponentInParent<GunController>();

            if(gunController != null)
            {
                gunController.BulletHitEnemy(enemyAI);
            }

            //uništi metak kada pogodi neprijatelja
            Destroy(gameObject);

        }
    }
}
