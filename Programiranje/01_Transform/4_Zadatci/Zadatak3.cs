using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DomacaZadaca : MonoBehaviour
{

    public int x;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (x<=100)
        {            
            transform.localScale += Vector3.right * x;
            x++;
        }
    }
}
