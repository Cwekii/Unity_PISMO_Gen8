using Mirror;
using UnityEngine;

public class Bullet : NetworkBehaviour
{
    public float speed = 50;
    public int dmg = 5;
    public PlayerHealth owner;
    PlayerHealth target;

    public void Start()
    {
        Invoke("Cmd_AutoDestroy", 3f);
    }
    void Update()
    {
        if (!isServer)
        {
            GetComponent<CapsuleCollider>().enabled = false;
        }
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isServer)
        {
            print("Returning...");
            return;
        }
        if (other.CompareTag("Player"))
        {
            target = other.gameObject.GetComponent<PlayerHealth>();

            target.Cmd_TakeDmg(dmg, other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            if (target.health <= 0)
            {
                target.Target_DestroyPlayer(other.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
                owner.Target_KillScore(owner.gameObject.GetComponent<NetworkIdentity>().connectionToClient);
            }
            CancelInvoke();
            Cmd_AutoDestroy();
        }
    }

    [Command(requiresAuthority = false)]
    private void Cmd_AutoDestroy()
    {
        NetworkServer.Destroy(gameObject);
    }
}
