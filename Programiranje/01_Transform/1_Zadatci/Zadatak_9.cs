using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napravite skriptu koja može pomicati kocku po svim osima (javne varijable), 
// rotirati (javne varijable) i povećavati (javne varijable) svake sekunde

public class Zadatak_9 : MonoBehaviour
{
    public float xPos;
    public float yPos;
    public float zPos;

    public float xRot;
    public float yRot;
    public float zRot;

    public float xScale;
    public float yScale;
    public float zScale;

    private void Update()
    {
        transform.position += new Vector3(xPos, yPos, zPos) * Time.deltaTime; //Micanje
        transform.Rotate(new Vector3(xRot, yRot, zRot) * Time.deltaTime);
        transform.localScale += new Vector3(xScale, yScale, zScale) * Time.deltaTime;
    }
}
