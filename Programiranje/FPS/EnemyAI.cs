using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; // dodajemo novi using kako bi smo mogli korsitit navmesh

public class EnemyAI : MonoBehaviour
{
    public Transform player; // gameobjekt do kojega �e Enemy i�i
                             // Tj referenca na transformaciju igra�a, postavljamo ju u unity su�elju

    public float closeCombatDistance = 2f; // udaljenost na kojoj se Enemy prebacuje na blisku borbu
    public float damageAmount = 10f; // �teta koju Enemy nanosi igra�u kad ga dotakne
    bool isAttacking = false; //varijabla koja ozna�ava je li neprijatelj u fazi napada
    NavMeshAgent agent;//referenca na "NavMeshAgent" komponentu neprijatelja
    public float health = 100f; // po�etno zdravlje enemy-a

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // dohva�amo "NavMeshAgent" komponentu iz objekta na kojemu je ova skripta
        player = GameObject.FindGameObjectWithTag("Player").transform; //Pronalazimo igra�a prema tagu player i postavljamo
                                                                       //referencu na njegovu transformaciju
    }

    private void Update()
    {
        if (!isAttacking)
        {
            //Ra�unamo udaljenost izme�u neprijatelja i igra�a
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            //Ako je udaljenost ve�a od udaljenosti za blisku borbu, kretaj se prema igra�u
            if (distanceToPlayer > closeCombatDistance)
            {
                agent.SetDestination(player.position);
            }
            else
            {
                //Ako smo dovoljno blizu igra�u, prestani se kretati i zapo�ni napad
                agent.ResetPath();
                isAttacking = true;
                AttackPlayer();
            }
        }
    }

    private void AttackPlayer()
    {
        //Metoda koja izaziva napad igra�a
        //Poziva metodu TakeDamage() u komponenti PlayerHealth igra�a i nanosi �tetu
        player.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
    }

    //Metoda koja �e se pozivati kad Enemy primi damage
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
