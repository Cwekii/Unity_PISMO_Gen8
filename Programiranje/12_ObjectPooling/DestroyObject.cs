using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyObj", 10f); 
    }

    // Update is called once per frame
    void DestroyObj()
    {
        Destroy(gameObject);
    }
}
