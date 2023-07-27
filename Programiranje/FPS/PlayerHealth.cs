using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maksimalno zdravlje igra�a
    public float currentHealth; // tretuta�no zdravlje igra�a

    private void Start()
    {
        currentHealth = maxHealth; // Postavljamo po�etno zdravlje igra�a na maksimalno zdravlje
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; //Oduzimamo �tetu od trenutnog zdravlja igra�a

        if(currentHealth <= 0f)
        {
            Die();//Ako je zdravlje manje ili jednako 0 igra� umire
        }
    }

    void Die()
    {
        //Ovdje mo�ete dodati logiku za smrt igra�a, npr. prikaze poruke o smrti, ponovo pokretanje levela, itd...
        Debug.Log("Umro si!");
    }

    private void Update()
    {
        Debug.Log(currentHealth);
    }
}
