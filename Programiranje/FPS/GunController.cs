using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject bulletPrefab;// Prefab metka koji �emo ispaljivati
    public Transform muzzlePoint;//Pozicija na kojoj �e biti ispaljen metak
    public float fireRate = 0.1f; // brzina pucanja 
    public float damage = 10f;

    bool canShoot = true;

    private void Update()
    {
        //provjeri je li mogu�e pucati i je li igra� pritisnuo lijevi klik mi�a
        if(canShoot && Input.GetButtonDown("Fire1"))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        //stvaranje metka na poziciji "muzzlePoint"
        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position,muzzlePoint.rotation);

        //Postavljanje �tete metka u skripti metka (ako je potrebno)
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if(bulletScript != null)
        {
            bulletScript.damage = damage;
        }
    }

    //Metoda koja �e se pozvati kad metak pogodi neprijatelja
    public void BulletHitEnemy(EnemyAI enemy)
    {
        //provjeri postoji li takav neprijatelj i nanosi mu �tetu
        if(enemy != null)
        {
            enemy.ReceiveDamage(damage);
        }
    }
}
