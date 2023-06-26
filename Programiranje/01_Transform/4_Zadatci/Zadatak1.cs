using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ante_DZ : MonoBehaviour
{
    //1) Unesite dvije javne vrijednosti.
    //Neka se objekt na sceni uveća po svim osima u početku za zbroj te dvije javne vrijednosti.

    public int a;
    public int b;

    private void Start()
    {
        a = 55;
        b = 60;

        transform.localScale += new Vector3(a + b, a + b, a + b);
    }

}
