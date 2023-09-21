using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GunController : MonoBehaviour
{
    public InputAction trigger;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private List<GameObject> bulletsList = new();
    public int initialPoolSize;
    [SerializeField] private Transform muzzle;
    [SerializeField] private float timeBetweenShoots;

    private Queue<GameObject> bulletPool = new Queue<GameObject>();
    private bool canShoot;


    private void Start()
    {
        canShoot = true;
        InitializeBulletPoolQueue();
    }

    void InitializeBulletPool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject tempBullet = Instantiate(bulletPrefab);
            tempBullet.SetActive(false);
            bulletsList.Add(tempBullet);
        }
    }
    
    void InitializeBulletPoolQueue()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject tempBullet = Instantiate(bulletPrefab);
            tempBullet.GetComponent<BulletController>().myGun = this;
            tempBullet.SetActive(false);

        }
    }
    
    
    
    private void OnEnable()
    {
        trigger.Enable();
    }

    private void OnDisable()
    {
        trigger.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (trigger.IsPressed() && canShoot)
        {
            StartCoroutine(CanShoot());
            ShootBulletQueue();
        }
    }

    void ShootBullet()
    {
        foreach (GameObject bullet in bulletsList)
        {
            if (!bullet.activeInHierarchy && canShoot)
            {
                bullet.transform.position = muzzle.transform.position;
                bullet.transform.rotation = muzzle.transform.rotation;
                bullet.SetActive(true);
                StartCoroutine(CanShoot());
                return;
            }
            // add reload?
        }
    }

    void ShootBulletQueue()
    {
        GameObject bullet = bulletPool.Dequeue();
        
        bullet.transform.position = muzzle.transform.position;
        bullet.transform.rotation = muzzle.transform.rotation;
        bullet.SetActive(true);
    }

    public void ReturnToPool(GameObject bullet)
    {

        bulletPool.Enqueue(bullet);
    }

    IEnumerator CanShoot()
    {
        canShoot = false;
        yield return new WaitForSeconds(timeBetweenShoots);
        canShoot = true;
    }
}
