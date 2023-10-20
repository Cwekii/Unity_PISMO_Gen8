using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zadatak_17 : MonoBehaviour
{
    //Napišite skriptu za health koja će utjecati na slider koji pokazuje
    //health.Max iznos je 100, a min je 0. Svakih 5 sekundi health se
    //regenerira za 2.5, a svaki put kada se stisne tipka "a" neka se skine 10 
    //bodova sa heltha.Sve to naravno utječe na slider.
    //(3 points)


    public float currentHealth;
    private float maxHealth = 100f;
    private float minHealth = 0f;
    private float regenTime = 5f;
    private float regenAmount = 2.5f;
    private float damageOnKeyPressed = 10;

    [SerializeField] Slider healthSlider;

    private void Start()
    {
        currentHealth = maxHealth;

        //Paziti da nam je range od slidera jednak zadanim varijablama po defaultu slider range je od 0-1!!!
        //healthSlider.maxValue = maxHealth;
        healthSlider.value = map(currentHealth, minHealth, maxHealth, healthSlider.minValue, healthSlider.maxValue);
        StartCoroutine(HealthRegen());
    }

    /// <summary>
    /// pretvara prvi broj iz jednog rangea u drugi npr. (50, 0,100,0,10) ce nam returnat 5 jer je 50 u rangeu od 0-100 jednak kaoi 5 u rangeu 0-10
    /// </summary>
    /// <param name="x"></param> broj koji pretvaramo
    /// <param name="in_min"></param> minimum range od prvog broja
    /// <param name="in_max"></param> maximum range od prvog broja
    /// <param name="out_min"></param> minimum range od drugog broja
    /// <param name="out_max"></param> maximum range od drugog broja
    /// <returns></returns>
    float map(float x, float in_min, float in_max, float out_min, float out_max)
    {
        return (x - in_min) * (out_max - out_min) / (in_max - in_min) + out_min;
    }

    IEnumerator HealthRegen()
    {
        while (true)
        {
            yield return new WaitForSeconds(regenTime);
            currentHealth += regenAmount;

            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
            healthSlider.value = map(currentHealth, minHealth, maxHealth, healthSlider.minValue, healthSlider.maxValue);
        }
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            currentHealth -= damageOnKeyPressed;
            healthSlider.value = map(currentHealth, minHealth, maxHealth, healthSlider.minValue, healthSlider.maxValue);
        }
    }
}
