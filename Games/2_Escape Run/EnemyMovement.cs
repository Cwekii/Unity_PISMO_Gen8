using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public GameObject target; //To je player ondnosno mi
    public float speed; //brzina kretanja neprijatelja
    public int damage; //štetu koju nam neprijatelj radi
    GameManager gm;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        transform.LookAt(target.transform); //gledaj prema playeru
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime); //idi prema playeru
    }

    private void OnTriggerEnter(Collider other)
    {
        //ako je player uništi se
        if(other.gameObject.tag == "Player")
        {
            gm.LoseLife(damage);
            Destroy(this.gameObject);
        }
    }
}
