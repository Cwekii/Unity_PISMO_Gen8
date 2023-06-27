using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float brzinaKretanja;
    [Header("Samo prikazi")]
    public float horMove;
    public float verMove;

    public Vector3 smjer;
    Rigidbody rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        horMove = Input.GetAxis("Horizontal");
        verMove = Input.GetAxis("Vertical");

        smjer = new Vector3(horMove, 0f, verMove).normalized; //noramliziramo vektor da duljina bude 1 (smjer ostaje isti)
        smjer *= brzinaKretanja;
      //  transform.position += smjer;
    }

    private void FixedUpdate()
    {
       // rigid.velocity = smjer;
        rigid.AddForce(smjer);
        // rigid.AddTorque(horMove * brzinaKretanja * Vector3.up);
       // rigid.AddRelativeForce(smjer);
    }
}
