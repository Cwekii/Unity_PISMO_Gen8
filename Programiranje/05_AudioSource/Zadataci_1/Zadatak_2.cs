using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Napravite skriptu gdje jedan frame se pokreće zvuk,
// a drugi frame stopira zvuk i tako u beskonacnost

public class Zadatak_2 : MonoBehaviour
{
    AudioSource ass;

    private void Start()
    {
        ass = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(ass.isPlaying == true)
        {
            ass.Stop();
        }
        else if(ass.isPlaying == false)
        {
            ass.Play();
        }
    }
}
