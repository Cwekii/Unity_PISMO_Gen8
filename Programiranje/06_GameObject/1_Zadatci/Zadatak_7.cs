using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Napravite objekt koji se krece iskljucivo lijevo ili desno (Z os)
 * na tipke strelice left arrow i right arrow.
 * Kada dotakne sferu neka se ugasi sfera i aktiviraju sve kapsule,
 * a kada dotakne jednu kapsulu neka ugasi sve kapsule koje jesu aktivne.
 * Cilj je ugasiti sve objekte na sceni.
 * Imajte 4 kapsule i 2 sfere (sve su naravno na jednakoj Y i X osi)
 */

public class Zadatak_7 : MonoBehaviour
{
    public GameObject sphere1;
    public GameObject sphere2;

    public GameObject kaps1;
    public GameObject kaps2;
    public GameObject kaps3;
    public GameObject kaps4;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        kaps1.SetActive(false);
        kaps2.SetActive(false);
        kaps3.SetActive(false);
        kaps4.SetActive(false);
    }

    private void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector3.right);
        }
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector3.left);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Sphere")
        {
            other.gameObject.SetActive(false);
            kaps1.SetActive(true);
            kaps2.SetActive(true);
            kaps3.SetActive(true);
            kaps4.SetActive(true);
        }
        else if(other.gameObject.name == "Capsule")
        {
            kaps1.SetActive(false);
            kaps2.SetActive(false);
            kaps3.SetActive(false);
            kaps4.SetActive(false);
        }
    }
}
