using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;

    public float maxHealth = 100f; // Maksimalno zdravlje igra�a
    public float currentHealth; // trenuta�no zdravlje igra�a

    public GameObject mainMenuCamera; //kamera za main menu, aktivira se pri smrti igrača
    public GameObject deathScreen; //image na kojem se nalaze opcije za restartiranje igre, loadanje main menua i izlazak iz igre uz end score
    public GameObject fpsController; //referenca na našeg lika da ga možemo ugasiti (nije najbolje riješenje, istražite za domaći bolje načine)

    private void Start()
    {
        currentHealth = maxHealth; // Postavljamo po�etno zdravlje igra�a na maksimalno zdravlje
        fpsController = gameObject; //fpsController je ovaj objekt
        healthBar.value = maxHealth; //postavljanje healtha na maksimum
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; //Oduzimamo �tetu od trenutnog zdravlja igra�a
        healthBar.value = currentHealth; //prikaz trenutačnog healtha

        if(currentHealth <= 0f)
        {
            Die();//Ako je zdravlje manje ili jednako 0 igra� umire
        }


    }

    public void Die() //metoda za umiranje, mainMenu kamera se pali, gasi se objekt
    {
        fpsController.SetActive(false);
        mainMenuCamera.SetActive(true);
        //Ovdje mo�ete dodati logiku za smrt igra�a, npr. prikaze poruke o smrti, ponovo pokretanje levela, itd...
        Debug.Log("Umro si!");
        deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined; //oslobađamo miš da možemo bez brige s njim klikati po ekranu i vidjeti gdje je
        Cursor.visible = true;
        
    }

    private void Update()
    {
        Debug.Log(currentHealth);
    }
}
