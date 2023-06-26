using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//4.)Rotirajte kocku za 3 stupnja svaku sekundu:
//a) Po X osi
//b) po Y osi
//c) Po X i Y osi
//D) Kada se rotira po X i Y osi, rotira li se i po Z? - DA

public class Zadatak_2_4 : MonoBehaviour
{
    public bool activateX;
    public bool activateY;

    private void Update()
    {
        //a
        if(activateX)
        {
            transform.Rotate(new Vector3(3, 0, 0) * Time.deltaTime);
        }
        //b
        if(activateY)
        {
            transform.Rotate(new Vector3(0, 3, 0) * Time.deltaTime);
        }
    }
}
