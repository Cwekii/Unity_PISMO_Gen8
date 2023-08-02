using UnityEngine;
using UnityEngine.AI; // dodajemo novi using kako bi smo mogli korsitit navmesh

public class EnemyAI : MonoBehaviour
{
    [Header("Enemy target & navmesh agent")]
    public Transform player; // gameobjekt do kojega �e Enemy i�i
    NavMeshAgent agent;//referenca na "NavMeshAgent" komponentu neprijatelja
                       // Tj referenca na transformaciju igra�a, postavljamo ju u unity su�elju
    GameManager scoreCounter; // uzima se referenca na GameManagera da možemo manipulirati Scoreom

    [Header("Enemy stats")]
    public float closeCombatDistance = 2f; // udaljenost na kojoj se Enemy prebacuje na blisku borbu
    public float damageAmount = 10f; // �teta koju Enemy nanosi igra�u kad ga dotakne
    public float health = 100f; // po�etno zdravlje enemy-a
    public float attackRate = 2.0f; //koliko vremena treba enemyu da pnovno može napasti
    public float attackRateMax = 2.0f; //maksimalna vrijednost attackRatea, služi za resetiranje attackRatea
    public int killValue = 10 ; //koliko bodova vrijedi ubijanje enemya

    [Header("Attack checks")]
    bool isAttacking = false; //varijabla koja ozna�ava je li neprijatelj u fazi napada
    bool canAttack = false; //varijabla koja označava može li nas enemy napasti ili ne

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>(); // dohva�amo "NavMeshAgent" komponentu iz objekta na kojemu je ova skripta
        player = GameObject.FindGameObjectWithTag("Player").transform; //Pronalazimo igra�a prema tagu player i postavljamo
                                                                       //referencu na njegovu transformaciju
        scoreCounter = FindObjectOfType<GameManager>(); //pronalazimo GameManagera prema njegovom tipu da bismo mogli doći do njegovog scorea i promijeniti ga
    }

    private void Update()
    {

        isAttacking = false; //provjeru napada li enemy odmah stavljamo na false i konstantno resetiramo, osim ako enemy napada
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
                //Ako smo dovoljno blizu igra�u, prestani se kretati i zapo�ni napad, provjere za napad se postavljaju na true
                agent.ResetPath();
                isAttacking = true;
                canAttack = true;
            }
        }

        if (canAttack && attackRate <= 0.0f ) //ako možemo napadati i dovoljno vremena je prošlo od zadnjeg napada, enemy napada igrača
        {
            AttackPlayer();

        }
        attackRate -= Time.deltaTime; //konstantno oduzimanje vremena od attackRatea
    }

    private void AttackPlayer()
    {
        //Metoda koja izaziva napad igra�a
        //Poziva metodu TakeDamage() u komponenti PlayerHealth igra�a i nanosi �tetu
        player.GetComponent<PlayerHealth>().TakeDamage(damageAmount);
        //resetiranje attack ratea
        attackRate = attackRateMax;

        //ponovno izra�unavanje udaljenosti izme�u enemy i playera da zna da li nastavlja napadati
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer > closeCombatDistance)
        {
            agent.SetDestination(player.position);
            canAttack = false;
        }
    }

    //Metoda koja �e se pozivati kad Enemy primi damage
    public void ReceiveDamage(float damage)
    {
        //Smanji zdravlje za vrijednost "damage"
        health -= damage;

        if (health <= 0) // ako enemy umre, dobijamo score u vrijednosti killValuea i uništava se Enemy object
        {
            scoreCounter.AddScore(killValue);
            Destroy(gameObject);
        }

    }

}
