using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napišite skriptu (ne ista skripta kao u zadatku e)
//koja rotira objekt ovisno o unesenim javnim vrijednostima po sekundi

public class Zadatak_3_3f : MonoBehaviour
{
    public float rotX;
    public float rotY;
    public float rotZ;

    public float posX;
    public float posY;
    public float posZ;

    private void Update()
    {
        if (rotX > 0 || rotY > 0 || rotZ > 0)
        {
            transform.position += new Vector3(posX, posY, posZ);
        }
        else if (rotX < 0 || rotY < 0 || rotZ < 0)
        {
            transform.position -= new Vector3(posX, posY, posZ);
        }

        transform.Rotate(new Vector3(rotX, rotY, rotZ) * Time.deltaTime);
    }
}
