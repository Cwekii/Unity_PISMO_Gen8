using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak_4 : MonoBehaviour
{
    AudioSource aSource;

    private void Start()
    {
        aSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(aSource.mute)
        {
            aSource.mute = false;
        }
        else
        {
            aSource.mute = true;
        }
    }
}
