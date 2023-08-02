using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f; // Vrijeme trajanja metka

    public float damage = 10f; // �teta koju metak nanosi

    private void Start()
    {
        Destroy(gameObject, lifetime);// uni�ti metak nako vremena lifetime
    }

    //private void Update()
    //{
    //    //kretanje metka prema naprijed
    //    transform.Translate(Vector3.forward * speed * Time.deltaTime);
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy")) //provjerava je li ono što je pogođeno Enemy
        {
            Debug.Log("Pogo�en");
            // kada metak dotakne Enemy-a, Enemy prima damage
            EnemyAI enemyAI = other.GetComponent<EnemyAI>();

            //Pozovi metodu za o�te�enje neprijatelja u skripti "GunController"
            GunController gunController = FindObjectOfType<GunController>();
            //GunController gunController = GetComponentInParent<GunController>();

            if(gunController != null) //ako GunController postoji, pozove se metoda BulletHitEnemy
            {
                gunController.BulletHitEnemy(enemyAI);
            }
            else if(gunController == null)//ako ne postoji, DebugLog nas upozorava na to
            {
                Debug.Log("Gun controller");
            }

            //uni�ti metak kada pogodi neprijatelja
            Destroy(gameObject);

        }

        else //ako ne pogodi Enemya, DebugLog nas na to upozorava
        {
            Debug.Log("Nije ");
        }
    }

    private void OnCollisionEnter(Collision collision) // provjera da li je išta drugo pogođeno što ne bi trebalo biti, gdje se metak uništava
    {
        Destroy(gameObject);
    }
}
