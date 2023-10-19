using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : MonoBehaviour
{
    [Header("Position")]
    /// <summary>
    /// koristiti vector 3 za ovakve situacije
    /// </summary>
    public Vector3 position;

    public float positionX;
    public float positionY;
    public float positionZ;

    [Header("Rotation")]
    public Vector3 rotation;///isto

    public float rotationX;
    public float rotationY;
    public float rotationZ;

    [Header("Scale")]
    public Vector3 scale;///isto

    public float scaleX;
    public float scaleY;
    public float scaleZ;
    
    private void Start()
    {
        StartCoroutine(TransformObject());

        InvokeRepeating("TransformObjectEverySecond", 0, 1);

    }

    IEnumerator TransformObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(1f);
            transform.localPosition = new Vector3(positionX, positionY, positionZ);
            transform.localEulerAngles = new Vector3(rotationX, rotationY, rotationZ);
            transform.localScale = new Vector3(scaleX, scaleY, scaleZ);
        }
    }

    public void TransformObjectEverySecond()
    {
        transform.localPosition = position;
        transform.localEulerAngles = rotation;
        transform.localScale = scale;
    }
}
