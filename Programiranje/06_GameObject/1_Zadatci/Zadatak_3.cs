using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Na tipku "S" ugasite game object

public class Zadatak_3 : MonoBehaviour
{
    public GameObject buhtla;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            buhtla.SetActive(!buhtla.activeSelf);
        }
    }
}
