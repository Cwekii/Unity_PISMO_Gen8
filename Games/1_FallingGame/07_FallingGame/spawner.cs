using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject prefab ; // predmet koji se stvara
    public float timer = 3f; // vremenski period za spawnanje objekata
    float timerReset; //vra�anje timera na po�etak
    int spawnCount; //broj koliko smo prefaba stvorili

    private void Start()
    {
        timerReset = timer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            //varijabla u koju �e se spremati nasumi�ni broj
            float randomPozicijaX = Random.Range(-4f, 4f);// naredba koja uzmia nasumi�ni broj od -4 do 4
                                                          // jer smo tako odredili
           
            //stvaramo na� prefab na x poziciji na broju koji dobijemo od random range
            //na y poziciji na� prefab stvaramo na 15 jer treba biti visoko
            //i z pozicija 0, stavljamo quaternion.identity jer rotacija ostaje ista
            Instantiate(prefab, new Vector3(randomPozicijaX, 15, 0), Quaternion.identity);
            spawnCount++;
            timer = timerReset;

            // svakih 13 stvorenih mi ubrzavamo vrijeme za 10%
            if(spawnCount == 13 && timerReset > 0.7f)
            {
                timerReset *= 0.9f;
                spawnCount = 0;
            }
        }
    }
}
