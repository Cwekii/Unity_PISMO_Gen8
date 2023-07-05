using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// U startu neka se stvori na sceni na poziciji 0,0,0
// objekt kocke koji je spremljen prije toga kao prefab

public class Zadatak7_2 : MonoBehaviour
{
    public GameObject nasPrefab;
    public Transform spawnPosition;

    private void Start()
    {
        Instantiate(nasPrefab, spawnPosition.position, spawnPosition.rotation);
    }
}
