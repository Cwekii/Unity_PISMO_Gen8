using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Napravite skriptu koja ce u sebe dodjeliti 3 prefaba i 3 transforma.
 * Također imajte i 2 javna inta.
 * U metodi start neka se stvori prefab vrijednosti prvog javnog inta 
 * na poziciji transforma vrijednosti drugog javnog inta.
 */

public class Zadatak_1 : MonoBehaviour
{
    public GameObject[] prefabs = new GameObject[3];
    public Transform[] spawns = new Transform[3];

    public int brojPrefaba;
    public int brojTransforma;

    private void Start()
    {
        Instantiate(prefabs[brojPrefaba], spawns[brojTransforma].position, Quaternion.identity);
    }
}
