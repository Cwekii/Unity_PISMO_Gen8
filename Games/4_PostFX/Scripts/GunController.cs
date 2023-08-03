using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunController : MonoBehaviour
{
    [Header("Bullet")]
    public GameObject bulletPrefab;// Prefab metka koji æemo ispaljivati
    [Header("Muzzle")]
    public Transform muzzlePoint;//Pozicija na kojoj æe biti ispaljen metak
    public GameObject flash;
    [Header("Gun Stats")]
    public float fireRate = 0.1f; // brzina pucanja 
    public float fireRateMax = 0.1f; // brzina pucanja 
    public float damage = 10f;
    public float speed = 10f;
    public int ammoMax = 20;
    public int ammo = 20;
    public float reloadTime = 1.0f;
    public float reloadTimeMax = 1.0f;
    public TextMeshProUGUI ammoText;
    public float aimBloom;
    //public TextMeshProUGUI maxAmmoText;
    [Header("Can shoot check")]
    bool canShoot = true;
    bool hasToReload = false;
    bool isReloading = false;
    [Header("Cameras")]
    public Camera mainCamera;
    public Camera aimCamera;

    private void Start()
    {
        ShowText();
    }
    private void Update()
    {
        //provjeri je li moguæe pucati i je li igraè pritisnuo lijevi klik miša
        if(canShoot && Input.GetButtonDown("Fire1") && !hasToReload)
        {
            StartCoroutine(MuzzleFlash(flash));
            ShootBullet();
        }

        else if(hasToReload && Input.GetButtonDown("Fire1"))
        {
            isReloading = true;
        }

        if(Input.GetButton("Fire2"))
        {
            mainCamera.enabled = false;
            aimCamera.enabled = true;
        }

        if(Input.GetButtonUp("Fire2"))
        {
            mainCamera.enabled = true;
            aimCamera.enabled = false;
        }


        if(Input.GetButtonDown("Reload"))
        {
            isReloading = true;
        }

        if(isReloading)
        {
            canShoot = false;
            reloadTime -= Time.deltaTime;

            ammoText.text = "Reloading...";
            if (reloadTime <= 0f)
            {
                ReloadGun();
                reloadTime = reloadTimeMax;
            }
        }

        if(fireRate <=0 && !isReloading)
        {
            canShoot = true;
            Debug.Log("I can shoot");
        }

        else
        {
            canShoot = false;
            Debug.Log("I cant shoot");

        }

        fireRate -= Time.deltaTime;

    }

    void ShootBullet()
    {
        float x = Screen.width / 2;
        float y = Screen.height / 2;

        float xAcc = Random.Range(x - aimBloom, x + aimBloom);
        float yAcc = Random.Range(y - aimBloom, y + aimBloom);

        var ray = Camera.main.ScreenPointToRay(new Vector3(xAcc, yAcc, 0));


        //stvaranje metka na poziciji "muzzlePoint"
        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position,muzzlePoint.rotation );
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();

        bulletRB.velocity = speed * ray.direction;

        Debug.Log(bulletRB.velocity);

        //Postavljanje štete metka u skripti metka (ako je potrebno)
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if(bulletScript != null)
        {
            bulletScript.damage = damage;
        }

        ammo--;

        if(ammo <= 0)
        {
            Debug.Log("I am out of ammo");
            canShoot = false;
            hasToReload = true;
        }

        fireRate = fireRateMax;
        ShowText();
    }

    void ReloadGun()
    {
        ammo = ammoMax;
        canShoot = true;
        isReloading = false;
        hasToReload = false;
        ShowText();
    }

    //Metoda koja æe se pozvati kad metak pogodi neprijatelja
    public void BulletHitEnemy(EnemyAI enemy)
    {
        //provjeri postoji li takav neprijatelj i nanosi mu štetu
        if(enemy != null)
        {
            enemy.ReceiveDamage(damage);
        }
    }

    public void ShowText()
    {
        ammoText.text = ammo + "/" + ammoMax;
    }

    private IEnumerator MuzzleFlash(GameObject flash)
    {
        flash.SetActive(true);

        yield return new WaitForSeconds(0.05f);

        flash.SetActive(false);
    }
}
