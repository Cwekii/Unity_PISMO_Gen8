using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Neka na tipku S se zvuk pokreće,
 * na tipku P se pauzira,
 * na tipku U se unpauzira,
 * a na tipku M mutea ili unmutea,
 * a na tipku T se stopira zvuk
 */

public class Zadatak_5 : MonoBehaviour
{
    AudioSource ass;

    private void Start()
    {
        ass = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            ass.Play();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            ass.Pause();
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            ass.UnPause();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            if(ass.mute)
            {
                ass.mute = false;
            }
            else if(ass.mute == false)
            {
                ass.mute = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            ass.Play();
        }
        if (Input.GetKeyDown(KeyCode.T))
        {
            ass.Stop();
        }
    }
}
