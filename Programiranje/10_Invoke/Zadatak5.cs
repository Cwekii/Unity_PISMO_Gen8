using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zadatak5 : MonoBehaviour
{
    /*
     Napisite skriptu koristeci Invoke/Invoke repeating gdje na UI text-u se prikazuje health,
    a imate 2 invoke/invoke repeatinga. Prvi koji vam svakih 5 sekundi povecava health za 5
    i drugi koji vam svakih 10 sekundi skihe health za 5%. Na sceni imate i on trigger stay metodu 
    gdje vam se svaki frame health povecava za 5 * time.deltaTime
    Scenu poslozite po svojem izboru
     */

    [SerializeField] Text healthText;
    [SerializeField] float currentHealth;


    private void Start()
    {
        InvokeRepeating(nameof(AddHealth), 5, 5);
        InvokeRepeating(nameof(Damage), 10, 10);
        healthText.text = currentHealth.ToString();
    }

    void AddHealth()
    {
        currentHealth += 5;
        healthText.text = currentHealth.ToString();
    }
    void Damage()
    {
        currentHealth -= currentHealth * 0.05f;
        healthText.text = currentHealth.ToString();
    }

    private void OnTriggerStay(Collider other)
    {
        currentHealth += 5 * Time.deltaTime;
        healthText.text = currentHealth.ToString();
    }
}
