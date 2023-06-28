using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Napravite skritpu koja ima javnu varijablu health
 * i javnu varijablu healthRegen. Kada kocka uđe u sferu neka primi dmg 10.
 * Kada je u sferi gubi health za "10 * Time.deltaTime",
 * a kada izađe krene sa regeneracijom.
 * Regeneracija je "healthRegen * Time.deltaTime"
 */

public class Zadatak_4 : MonoBehaviour
{
    //Ovjde je slučaj kada krećemo sa Full HP-om u igru
    public float Health = 100;
    public float healthRegen;
    float maxHealth;
    bool regeneration = true;

    private void Start()
    {
        maxHealth = Health;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Sfera")
        {
            Health -= 10;
            regeneration = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Sfera")
        {
            Health -= 10 * Time.deltaTime;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Sfera")
        {
            regeneration = true;
        }
    }

    private void Update()
    {
        if(regeneration && Health <= maxHealth)
        {
            Health += healthRegen * Time.deltaTime;
            if(Health > maxHealth)
            {
                Health = maxHealth;
                regeneration = false;
            }
        }
    }
}
