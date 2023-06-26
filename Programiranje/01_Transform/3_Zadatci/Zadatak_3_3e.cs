using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Napišite skriptu koja povećava ili smanjuje objekte ovisno o unesenim javnim vrijednostima po sekundi

public class Zadatak_3_3e : MonoBehaviour
{
    public float scaleX;
    public float scaleY;
    public float scaleZ;

    public float posX;
    public float posY;
    public float posZ;

    float startPosX;
    float startPosY;
    float startPosZ;

    bool big;

    private void Start()
    {
        startPosX = transform.localScale.x;
        startPosY = transform.localScale.y;
        startPosZ = transform.localScale.z;
    }

    private void Update()
    {
        if(scaleX > 0 || scaleY > 0 || scaleZ > 0)
        {
            transform.position += new Vector3(posX, posY, posZ);
        }
        else if(scaleX < 0 || scaleY < 0 || scaleZ < 0)
        {
            transform.position -= new Vector3(posX, posY, posZ);
        }
        if(transform.localScale.x <= startPosX / 2 ||transform.localScale.y <= startPosY / 2 || transform.localScale.z <= startPosZ / 2)
        {
            transform.position += new Vector3(posX, posY, posZ);
        }
        else if (transform.localScale.x >= startPosX * 2 || transform.localScale.y >= startPosY * 2 || transform.localScale.z >= startPosZ * 2)
        {
            transform.position += new Vector3(posX, posY, posZ);
        }
        transform.localScale += new Vector3(scaleX, scaleY, scaleZ) * Time.deltaTime;
    }
}
