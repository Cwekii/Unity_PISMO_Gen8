using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Imajte na sceni 2 audiosourcea, a tipku space palite prvi i gasite drugi ili obrtnuto.

public class Zadatak_8 : MonoBehaviour
{
    public AudioSource prvi;
    public AudioSource drugi;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(prvi.enabled == true)
            {
                prvi.enabled = false;
                drugi.enabled = true;
            }
            else if (drugi.enabled == true)
            {
                prvi.enabled = true;
                drugi.enabled = false;
            }
        }
    }
}
