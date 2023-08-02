using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunController : MonoBehaviour
{
    [Header("Bullet")]
    public GameObject bulletPrefab;// Prefab metka koji �emo ispaljivati
    [Header("Muzzle")]
    public Transform muzzlePoint;//Pozicija na kojoj �e biti ispaljen metak
    [Header("Gun Stats")]
    public float fireRate = 0.1f; // brzina pucanja 
    public float fireRateMax = 0.1f; // brzina pucanja 
    public float damage = 10f; 
    public float speed = 10f; //brzina metka
    public int ammoMax = 20; //maksimalni broj metaka koji oružje ima u sebi
    public int ammo = 20; //trenutačni broj metaka koji oružje ima u sebi
    public float reloadTime = 1.0f; //koliko dugo nam treba za reloadanje
    public float reloadTimeMax = 1.0f; //maksimalno trajanje reloada, služi za resetiranje brojača
    public TextMeshProUGUI ammoText; //text za prikaz broja metaka
    public float aimBloom; //varijabla koja nam smanjuje preciznost oružja što je veća

    [Header("Can shoot check")] //provjere potrebne da vidimo možemo li pucati ili moramo li reloadati, i reloadamo li trenutačno
    bool canShoot = true;
    bool hasToReload = false;
    bool isReloading = false;
    [Header("Cameras")] //kamere igrača i scopea na oružju
    public Camera mainCamera;
    public Camera aimCamera;

    private void Start()
    {
        ShowText(); //odmah se prikazuje tekst sa brojem metaka na ekranu
    }
    private void Update()
    {
        //provjeri je li mogu�e pucati i je li igra� pritisnuo lijevi klik mi�a, i je li igrač trenutačno reloada
        if(canShoot && Input.GetButtonDown("Fire1") && !hasToReload)
        {
            ShootBullet();
        }

        else if(hasToReload && Input.GetButtonDown("Fire1")) //ako igrač mora reloadati, umjesto pucanja mu se oružje prisilno reloada
        {
            isReloading = true;
        }

        if(Input.GetButton("Fire2")) //Ako igrač drži desni klik miša, aktivira se scope kamera
        {
            mainCamera.enabled = false;
            aimCamera.enabled = true;
        }

        if(Input.GetButtonUp("Fire2")) //kada ga pusti, aktivira se glavna kamera ponovno
        {
            mainCamera.enabled = true;
            aimCamera.enabled = false;
        }


        if(Input.GetButtonDown("Reload")) //kada igrač pritisne tipku r, reloada mu se oružje
        {
            isReloading = true;
        }

        if(isReloading) //dok igrač reloada, ne može pucati i odbrojava mu se vrijeme potrebno za reload. 
                        //Kada dođe do nule, pozove se ReloadGun metoda i resetira se timer
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

        if(fireRate <=0 && !isReloading) //ako je prošlo dovoljno vremena od zadnjeg ispaljenog metka i igrač ne reloada, može pucati
        {
            canShoot = true;
            Debug.Log("I can shoot");
        }

        else //u suprotnom, ne može
        {
            canShoot = false;
            Debug.Log("I cant shoot");

        }

        fireRate -= Time.deltaTime; //fire rate se stalno smanjuje dok se ne resetira

    }

    void ShootBullet() //kada se pozove ova metoda, odredi se gdje je sredina ekrana,
                        // rayu (zraci) koju koristimo se dodijeli nasumično usmjerenje unutar ograničenja koja smo dali
                        // i pokreće se ostatak metode za kreiranje i ispaljivanje metka
    {
        float x = Screen.width / 2;
        float y = Screen.height / 2;

        float xAcc = Random.Range(x - aimBloom, x + aimBloom);
        float yAcc = Random.Range(y - aimBloom, y + aimBloom);

        var ray = Camera.main.ScreenPointToRay(new Vector3(xAcc, yAcc, 0)); //iz jedne točke na ekranu se ispaljuje ray


        //stvaranje metka na poziciji "muzzlePoint", uzima se njegov rigidbody da mu se dodijeli velocity
        GameObject bullet = Instantiate(bulletPrefab, muzzlePoint.position,muzzlePoint.rotation );
        Rigidbody bulletRB = bullet.GetComponent<Rigidbody>();
        bulletRB.velocity = speed * ray.direction;

        Debug.Log(bulletRB.velocity);

        //Postavljanje �tete metka u skripti metka (ako je potrebno)
        Bullet bulletScript = bullet.GetComponent<Bullet>();

        if(bulletScript != null)
        {
            bulletScript.damage = damage;
        }

        ammo--; //oduzimanje metaka za svaki ispaljen

        if(ammo <= 0) //ako nemamo metaka, moramo reloadati i ne možemo pucati
        {
            Debug.Log("I am out of ammo");
            canShoot = false;
            hasToReload = true;
        }

        fireRate = fireRateMax; //fire rate se resetira
        ShowText(); //prikazuje se broj metaka na ekranu
    }

    void ReloadGun() //broj metaka se resetira na max, opet igrač može pucati, ne mora reloadati i trenutačno više ne reloada, broj metaka se prikaže
    {
        ammo = ammoMax;
        canShoot = true;
        isReloading = false;
        hasToReload = false;
        ShowText();
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

    public void ShowText() //na ekranu nam se pokazuje broj metaka kroz maksimalni broja metaka
    {
        ammoText.text = ammo + "/" + ammoMax;
    }
}
