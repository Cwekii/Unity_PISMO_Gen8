using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class PlayerHealth : MonoBehaviour
{
    public Slider healthBar;

    public float maxHealth = 100f; // Maksimalno zdravlje igra�a
    public float currentHealth; // trenuta�no zdravlje igra�a

    public GameObject mainMenuCamera;
    public GameObject deathScreen;
    public GameObject fpsController;

    [Header("Volumes")]
    public PostProcessVolume LowHealthFX;

    private void Start()
    {
        currentHealth = maxHealth; // Postavljamo po�etno zdravlje igra�a na maksimalno zdravlje
        fpsController = gameObject;
        healthBar.value = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
        currentHealth -= damageAmount; //Oduzimamo �tetu od trenutnog zdravlja igra�a
        healthBar.value = currentHealth;

        if(currentHealth <= 0f)
        {
            Die();//Ako je zdravlje manje ili jednako 0 igra� umire
        }


    }

    public void Die()
    {
        fpsController.SetActive(false);
        mainMenuCamera.SetActive(true);
        //Ovdje mo�ete dodati logiku za smrt igra�a, npr. prikaze poruke o smrti, ponovo pokretanje levela, itd...
        Debug.Log("Umro si!");
        deathScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        
    }

    private void Update()
    {
        Debug.Log(currentHealth);

        //kod za postfx

        float hpPercent = Mathf.Clamp01(currentHealth / maxHealth);
        float weight = Mathf.Lerp(1, 0, hpPercent);

        LowHealthFX.weight = weight;
    }
}
