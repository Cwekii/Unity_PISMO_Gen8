using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; // referenca za naš character controller 
    public float speed = 12f; // varijabla za brzinu kretanja igraèa
    public float gravity = -9.81f; //varijabla za gravitaciju
    public Transform groundCheck; // varijabla u koju spremamo groundcheck objekt
    public float groundDistance = 0.4f; // varijabla koja nam služi za udaljenost u kojoj ground check radi;
    public LayerMask groundMask; //varijabla pomoæu koje možemo izabrati u Unity-u šta da se desi kada smo na
                                 //odreðenome layeru
    bool isGrounded; //bool pomoæu kojega provjeravamo diramo li zemlju
    public float jumpHeight = 3f; // varijabla pomoæu koje odreðujemo koliko jako možemo skoèiti
    Vector3 velocity;
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);//koristi se za provjeru
        //ima li objekt na tlu ili dodiruje tlo u Unityu

        if(isGrounded && velocity.y <= 0)
        {
            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        velocity.y += gravity * Time.deltaTime;
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(velocity * Time.deltaTime);
    }
}
