using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformPosition : MonoBehaviour
{
    private void Update()
    {
        transform.localPosition += new Vector3(0.1f, 0.1f, 0.1f);
    }
}
