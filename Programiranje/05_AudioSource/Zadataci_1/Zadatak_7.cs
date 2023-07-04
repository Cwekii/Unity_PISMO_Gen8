using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Postavite dvije javne varijable za 2 klipa,
 * jedan neka bude glasan a drugi tiši. Kad se klikne tipka "5" neka se pokrene glasni klip,
 * a kada se klikne tipka "P" neka se pokrene tiši. Kada se pokrene jedan, drugi se automatski gasi.
 * Oba klipa su na isti audiosource.
 */

public class Zadatak_7 : MonoBehaviour
{
    public AudioClip glasan;
    public AudioClip tisi;

    public AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha5) || Input.GetKeyDown(KeyCode.Keypad5))
        {
            audioSource.clip = glasan;
            audioSource.volume = 1;
            audioSource.Play();
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            audioSource.clip = tisi;
            audioSource.volume = 0.5f;
            audioSource.Play();
        }
    }
}
