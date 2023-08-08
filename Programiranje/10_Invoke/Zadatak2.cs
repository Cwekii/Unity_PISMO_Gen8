using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zadatak2 : MonoBehaviour
{
    /**
     * Napisite skritu koja stvara prefab (nasumicno bire iz arraya od barem 3 prefaba)
     * na random poziciji na sceni (x = -10 do 10, y = -11.3 do 20, z = -15.1 do 15.2)
     * svakih 5 sekundi koristeci invokeRepeating
     */


    [SerializeField] GameObject[] prefabs;

    private void Start()
    {
        InvokeRepeating(nameof(InstanciatePrefab), 5, 5);
    }

    private void InstanciatePrefab()
    {
        Vector3 position = 
            new Vector3(Random.Range(-10,10), Random.Range(-11.3f, 20), Random.Range(-15.1f, 15.2f));

        GameObject prefab;
        int i = Random.Range(0, prefabs.Length);

        prefab = prefabs[i];

        Instantiate(prefab, position, Quaternion.identity);
    }
}
