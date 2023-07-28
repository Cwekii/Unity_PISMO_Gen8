using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // dodajemo novi using kako bi smo mogli korsitit navmesh

public class EnemyAI : MonoBehaviour
{
    public Transform player; // gameobjekt do kojega æe Enemy iæi
                             // Tj referenca na transformaciju igraèa, postavljamo ju u unity suèelju

    public float closeCombatDistance = 2f; // udaljenost na kojoj se Enemy prebacuje na blisku borbu
    public float damageAmount = 10f; // Šteta koju Enemy nanosi igraèu kad ga dotakne
    bool isAttacking = false; //varijabla koja oznaèava je li neprijatelj u fazi napada
    NavMeshAgent agent;//referenca na "NavMeshAgent" komponentu neprijatelja
    public float health = 100f; // poèetno zdravlje enemy-a

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // dohvaæamo "NavMeshAgent" komponentu iz objekta na kojemu je ova skripta
        player = GameObject.FindGameObjectWithTag("Player").transform; //Pronalazimo igraèa prema tagu player i postavljamo
                                                                       //referencu na njegovu transformaciju
    }

    private void Update()
    {
        if (!isAttacking)
        {
            //Raèunamo udaljenost izmeðu neprijatelja i igraèa
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            //Ako je udaljenost veæa od udaljenosti za blisku borbu, kretaj se prema igraèu
            if (distanceToPlayer > closeCombatDistance)
            {
                agent.SetDestination(player.position);
            }
            else
            {
                //Ako smo dovoljno blizu igraèu, prestani se kretati i zapoèni napad
                agent.ResetPath();
                isAttacking = true;
                AttackPlayer();
            }
        }
    }

    private void AttackPlayer()
    {
        //Metoda koja izaziva napad igraèa
        //Poziva metodu TakeDamage() u komponenti PlayerHealth igraèa i nanosi štetu
        player.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    }

    //Metoda koja æe se pozivati kad Enemy primi damage
    public void ReceiveDamage(float damage)
    {
        //Smanji zdravlje za vrijednost "damage"
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }

    }

}
