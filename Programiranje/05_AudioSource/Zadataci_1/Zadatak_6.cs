using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napravite skriptu koja ima javnu vrijednost.Neka jačina zvuka bude jednaka javnoj vrijednosti.

public class Zadatak_6 : MonoBehaviour
{
    [Range(0, 1)]public float sound;
    AudioSource audio;

    private void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        audio.volume = sound;
    }
}
