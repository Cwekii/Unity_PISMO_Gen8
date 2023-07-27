using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; // Maksimalno zdravlje igraèa
    public float currentHealth; // tretutaèno zdravlje igraèa

    private void Start()
    {
        currentHealth = maxHealth; // Postavljamo poèetno zdravlje igraèa na maksimalno zdravlje
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; //Oduzimamo štetu od trenutnog zdravlja igraèa

        if(currentHealth <= 0f)
        {
            Die();//Ako je zdravlje manje ili jednako 0 igraè umire
        }
    }

    void Die()
    {
        //Ovdje možete dodati logiku za smrt igraèa, npr. prikaze poruke o smrti, ponovo pokretanje levela, itd...
        Debug.Log("Umro si!");
    }

    private void Update()
    {
        Debug.Log(currentHealth);
    }
}
