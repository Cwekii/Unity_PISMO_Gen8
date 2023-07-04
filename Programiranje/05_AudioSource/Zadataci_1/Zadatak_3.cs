using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Na tipku M neka se zvuk mutea, a na tipku K neka se unmutea.

public class Zadatak_3 : MonoBehaviour
{
    AudioSource audioS;

    private void Start()
    {
        audioS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(audioS.mute == true && Input.GetKeyDown(KeyCode.K))
        {
            audioS.mute = false;
        }
        if (audioS.mute == false && Input.GetKeyDown(KeyCode.M))
        {
            audioS.mute = true;
        }
    }
}
