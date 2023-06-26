using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
6.) Napravite skriptu da se kocka i sfera povećavaju i smanjuju za 3 do maksimalno 25
i minimalno 1 po sve 3 osi. Neka se kocka stalno rotira po javnim vrijednostima po sekundi,
kada se kocka smanjuje smjer rotacije se promjeni.
*/

public class Zadatak_2_6 : MonoBehaviour
{
    public float changeXYZ = 3;
    public float rot_X;
    public float rot_Y;
    public float rot_Z;

    bool expand = true;

    private void Update()
    {
        if (transform.localScale.x <= 1 || transform.localScale.y <= 1 || transform.localScale.z <= 1)
        {
            expand = true;
        }
        else if (transform.localScale.x >= 25 || transform.localScale.y >= 25 || transform.localScale.z >= 25)
        {
            expand = false;
        }

        if (expand == true)
        {
            transform.localScale += new Vector3(changeXYZ, changeXYZ, changeXYZ) * Time.deltaTime;
            transform.Rotate(new Vector3(rot_X, rot_Y, rot_Z) * Time.deltaTime);
        }

        else if (expand == false)
        {
            transform.localScale -= new Vector3(changeXYZ, changeXYZ, changeXYZ) * Time.deltaTime;
            transform.Rotate(new Vector3(-rot_X, -rot_Y, -rot_Z) * Time.deltaTime);
        }
    }

}
