using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Napravite skriptu gdje u startu pokrećete AudioSource

public class Zadatak_1 : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play();
    }
}
