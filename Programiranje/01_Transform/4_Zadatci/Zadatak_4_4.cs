using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//4) Neka skripta učita sve vrijednosti objekta (sve osi scale, sve osi position,
//sve osi rotation) i potom radi provjeru, ako je zbroj x y i z
//(scale posebno, rotation posebno, position posebno) veći od 20 neka se objekt
//postavi na 0,0,0 sa rotacijama na 0,0,0 i veličinom 1, 1 ,1.
//U suprotnom neka se pomakne po svim osima za zbroj (početnih osi pozicije),
//poveća po svim osima za zbroj (za zbroj svih scale osi) i rotira po svim osima na 69, 420, 911.

public class Zadatak_4_4 : MonoBehaviour
{
    float scaleX, scaleY, scaleZ, scaleSum;
    float posX, posY, posZ, posSum;
    float rotX, rotY, rotZ, rotSum;

    private void Start()
    {
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        scaleZ = transform.localScale.z;
        scaleSum = scaleX + scaleY + scaleZ;

        posX = transform.position.x;
        posY = transform.position.y;
        posZ = transform.position.z;
        posSum = posX + posZ + posY;

        rotX = transform.eulerAngles.x;
        rotY = transform.eulerAngles.y;
        rotZ = transform.eulerAngles.z;
        rotSum = rotX + rotY + rotZ;

        if(scaleSum > 20 || posSum > 20 || rotSum > 20)
        {
            transform.position = Vector3.zero;

            transform.localScale = Vector3.one;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            //transform.eulerAngles = new Vector3(0, 0, 0);
            //transform.eulerAngles = Vector3.zero;

            Debug.Log("Reset");

        }

        else
        {
            transform.position += Vector3.one * posSum;
            //transform.position += new Vector3(1, 1, 1) * posSum;
            //transform.position += new Vector3(posSum, posSum, posSum);
            transform.localScale += Vector3.one * scaleSum;

            transform.eulerAngles = new Vector3(69, 420, 911);


            Debug.Log("New");
        }
    }
}
