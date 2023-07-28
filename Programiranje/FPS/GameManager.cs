using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Transform[] SpawnPoints; // array za spawnPoints te spawnPoints æemo postavljati po levelu
    public GameObject[] Enemies; // tu æemo stavljati naše prefabs od neprijatelja 
    public GameObject[] weapons;//tu stavljamo sva naša oružja

    private void Start()
    {
        InvokeRepeating("spawnEnemy", 0, 3);
        //petlja koja prolazi kroz sve elemente niza oružja
        //varijabla "i" æe se koristiti kao indeks za pristup svakom elementu
        for (int i = 0; i < weapons.Length; i++)
        {
            //svako oružje na poziciji "i" u nizu se postavlja na neaktivno stanje
            //ovo se postiže pozivom metode SetActive(false) nad trenutnim oružjem
            weapons[i].SetActive(false);
        }
        //nakon petlje postavlja se prvo oružje niza (element s indeksom 0) na aktivno stanje
        //to znaèi da æe prvo oružje biti ukljuèeno dok æe ostala biti iskljuèena
        weapons[0].SetActive(true);
    }
        
    void spawnEnemy()
    {
        int randomSpawnPoint = Random.Range(0, SpawnPoints.Length);
        int randomEnemy = Random.Range(0, Enemies.Length);
        Instantiate(Enemies[randomEnemy], SpawnPoints[randomSpawnPoint].position, Quaternion.identity);
        
    }

    void SwitchWeapon(int indexActive)
    {
        // Petlja koja prolazi kroz sve elemente niza oružja
        //varijabla "i" æe se koristiti kao indeks za pristup svakom elementu
        for (int i = 0; i < weapons.Length; i++)
        {
            //svako oružje na poziciji "i" u nizu postavlja se na false
            
            weapons[i].SetActive(false);
        }
        //nakon petlje, postavlja se oružje s indeksom indexActive na aktivno stanje
        weapons[indexActive].SetActive(true);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
        {
            SwitchWeapon(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Keypad2))
        {
            SwitchWeapon(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Keypad3))
        {
            SwitchWeapon(2);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Keypad4))
        {
            SwitchWeapon(3);
        }


    }
}
