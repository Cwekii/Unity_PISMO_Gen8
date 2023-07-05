using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// U startu isključite game object

public class Zadatak_1 : MonoBehaviour
{
    public GameObject predmet;

    private void Start()
    {
        //NE: predmet = GetComponent<GameObject>();
        //predmet = gameObject;
        predmet = this.gameObject;
        predmet.SetActive(true);
    }
}
