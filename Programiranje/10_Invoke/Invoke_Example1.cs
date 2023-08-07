using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke_Example1 : MonoBehaviour
{
    public string mojeIme;

    private void Start()
    {
        Debug.Log("Start");
        Invoke("IspisiMojeIme", 2f);
    }

    void IspisiMojeIme()
    {
        Debug.Log("Moje ime je " + mojeIme);
    }
}
