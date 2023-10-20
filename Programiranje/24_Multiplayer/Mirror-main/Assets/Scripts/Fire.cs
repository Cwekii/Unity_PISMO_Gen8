using Mirror;
using UnityEngine;

public class Fire : NetworkBehaviour
{
    public float fireRate = 0.1f; // Rate of fire in seconds
    public float range = 100f;    // Maximum raycast range
    private float nextFireTime = 0f;
    public int dmg = 5;

    public Transform bulletSpawnPoint;

    public GameObject bullet;
    public  Controls player;
    public  PlayerHealth ph;

    void Update()
    {
        if (!isLocalPlayer) return;

        // Check if the left mouse button is pressed and the fire rate allows us to shoot
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        nextFireTime = Time.time + fireRate;
        Cmd_Shoot();
    }

    [Command]
    public void Cmd_Shoot()
    {
        GameObject go = Instantiate(bullet, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        Bullet b = go.GetComponent<Bullet>();
        b.owner = ph;
        NetworkServer.Spawn(go, player.connectionToClient);
    }
}
