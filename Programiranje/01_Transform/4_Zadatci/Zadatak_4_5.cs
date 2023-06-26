using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//5) Unesite 4 javne vrijednosti (int, int, float, float)
//Neka se radi provjera svaki frame i dok god je jednadžba istinita neka se objekt povećava
//za 1 po sekundi (svim osima) i rotira za 2 po sekundi (sve osi).
//U slučaju kada jednadžba nije istinita neka se objekt smanjuje za 2 po sekundi
//i rotira za 1 po sekundi (sve osi).
//Jednadžba: int1* int2 +float1 - float2 * int1 >= int1 * int2 * float1 / float2

public class Zadatak_4_5 : MonoBehaviour
{
    public int int1;
    public int int2;
    public float float1;
    public float float2;

    private void Update()
    {
        if(int1 * int2 + float1 - float2 * int1 >= int1 * int2 * float1 / float2)
        {
            transform.localScale += Vector3.one * Time.deltaTime;
            transform.Rotate(new Vector3(2, 2, 2) * Time.deltaTime);
        }

        else
        {
            transform.localScale -= Vector3.one * 2 * Time.deltaTime;
            transform.Rotate(Vector3.one * Time.deltaTime);
        }
    }
}
