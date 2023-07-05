using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// U startu neka se stvori na sceni na poziciji 0,0,0
// objekt kocke koji je spremljen prije toga kao prefab

public class Zadatak7_1 : MonoBehaviour
{
    public GameObject prefabNas; //Iz projecta iz flodera prefabs

    private void Start()
    {
        Instantiate(prefabNas, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
