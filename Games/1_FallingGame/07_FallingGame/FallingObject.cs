using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    //kada nam je bool pozitivan onda nam je i objekt koji skupljamo 
    //ako nam je negativan bool onda nam je to predmet koji izbjegavamo
    [Header("True = Good prefab | False = Bad prefab")]
    public bool isPositive = true;
    GameManager gm;

    private void Start()
    {
        //Dodijeliti game manager skriptu da se povezuje sa skriptom falling object tako što
        //Unity pretraži hijerahiju i naðe koji objekt na sebi ima GameManager skriptu
        gm = FindObjectOfType<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // radimo prvo za predmet koji player skuplja, znaèi bool isPositive nam mora biti true
        if(isPositive == true)
        {
            if(other.gameObject.tag == "Player")
            {
                gm.score++;
                Destroy(this.gameObject);
            }
            if(other.gameObject.tag == "Floor")
            {
                if(gm.score > 0)
                {
                    gm.score--;
                }

                Destroy(this.gameObject);
            }
        }
        //predmet koji player izbjegava
        else if(isPositive == false)
        {
            if(other.gameObject.tag == "Player")
            {
                gm.life--;
                Destroy(this.gameObject);
            }
            if(other.gameObject.tag == "Floor")
            {
                Destroy(this.gameObject);
            }
        }
    }

}
