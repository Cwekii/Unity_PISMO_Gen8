using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrayExample : MonoBehaviour
{
    public GameObject[] prefabs;
    public int brojStvaranja;

    private void Start()
    {
        Instantiate(prefabs[brojStvaranja], new Vector3(0, 5, 0), Quaternion.identity);
    }
}
