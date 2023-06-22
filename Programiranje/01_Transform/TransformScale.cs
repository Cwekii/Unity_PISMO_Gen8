using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//poveæajte kocku za 0.1 svaki frame

public class TransformScale : MonoBehaviour
{
    private void Update()
    {
        transform.localScale += new Vector3(0.1f, 0.1f, 0.1f);
    }
}
