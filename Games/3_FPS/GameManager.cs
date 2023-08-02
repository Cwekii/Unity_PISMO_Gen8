using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; //text koji prikazuje naš score tokom igre
    public TextMeshProUGUI endScoreText; //text koji prikazuje naš score na kraju igre
    GunController gunCont; //referenca na GunControllera,potrebna nam je kada mijenjamo oružja 
    public int score; //brojač scorea

    public Transform[] SpawnPoints; // array za spawnPoints te spawnPoints �emo postavljati po levelu
    public GameObject[] Enemies; // tu �emo stavljati na�e prefabs od neprijatelja 
    public GameObject[] weapons;//tu stavljamo sva na�a oru�ja

    private void Start()
    {
        InvokeRepeating("spawnEnemy", 0, 3);
        //petlja koja prolazi kroz sve elemente niza oru�ja
        //varijabla "i" �e se koristiti kao indeks za pristup svakom elementu
        for (int i = 0; i < weapons.Length; i++)
        {
            //svako oru�je na poziciji "i" u nizu se postavlja na neaktivno stanje
            //ovo se posti�e pozivom metode SetActive(false) nad trenutnim oru�jem
            weapons[i].SetActive(false);
        }
        //nakon petlje postavlja se prvo oru�je niza (element s indeksom 0) na aktivno stanje
        //to zna�i da �e prvo oru�je biti uklju�eno dok �e ostala biti isklju�ena
        weapons[0].SetActive(true);
    }
        
    void spawnEnemy() // nasumično se odabere spawnPoint, nasumično se odabire enemy i onda se stvaraju na tom pointu
    {
        int randomSpawnPoint = Random.Range(0, SpawnPoints.Length);
        int randomEnemy = Random.Range(0, Enemies.Length);
        Instantiate(Enemies[randomEnemy], SpawnPoints[randomSpawnPoint].position, Quaternion.identity);
        
    }

    void SwitchWeapon(int indexActive)
    {
        // Petlja koja prolazi kroz sve elemente niza oru�ja
        //varijabla "i" �e se koristiti kao indeks za pristup svakom elementu
        for (int i = 0; i < weapons.Length; i++)
        {
            //svako oru�je na poziciji "i" u nizu postavlja se na false
            
            weapons[i].SetActive(false);
        }
        //nakon petlje, postavlja se oru�je s indeksom indexActive na aktivno stanje, poziva se metoda za prikazivanje broja metaka sa GunControllera
        weapons[indexActive].SetActive(true);
        gunCont = weapons[indexActive].gameObject.GetComponent<GunController>();
        gunCont.ShowText();

    }

    public void AddScore(int killValue) //kada se pozove, metoda uzima killValue i score uvećava za toliko i prikaže to na oba teksta vezana za score
    {
        score += killValue;
        scoreText.text = "Score: " + score;
        endScoreText.text = "Score: " + score;
    }

    private void Update() //provjere koje služe za mijenjanje oružja
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
