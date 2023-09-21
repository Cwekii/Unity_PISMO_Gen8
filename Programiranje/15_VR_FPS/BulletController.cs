using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{
    public GunController myGun;
    
    [SerializeField] private float bulletSpeed = 5f;
    private Rigidbody bulletRigidbody;
    private float bulletLifetimeTimer;
    private float bulletLifetimeTimerMax = 3f;

    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        bulletLifetimeTimer -= Time.deltaTime;
        if (bulletLifetimeTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnEnable()
    {
        bulletRigidbody.velocity = transform.forward * bulletSpeed;
        bulletLifetimeTimer = bulletLifetimeTimerMax;
    }

    private void OnDisable()
    {
        myGun.ReturnToPool(gameObject);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //damage enemy
        }
    }
}
