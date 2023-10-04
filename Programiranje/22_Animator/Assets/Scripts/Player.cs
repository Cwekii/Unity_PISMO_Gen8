using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //osnovne stvari za 3rd person controller
    CharacterController controller;
    public float MoveSpeed;
    Vector2 movement;
    bool running;

    //stvari za skakanje, gravitacija itd
    public float jumpHeight;
    public float Gravity;
    bool isGrounded;
    Vector3 velocity;

    //Animator
    Animator anim;

    private void Start()
    {
        //ugasi cursor i samo assignaj CharacterController
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        anim = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
            //movement

        //pretvori input u movement vektore
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        //odredi smjer playera radi rotacije
        Vector3 direction = new Vector3(movement.x, 0, movement.y).normalized;

        if (direction.magnitude >= 0.1f)
        {
            controller.Move(direction * MoveSpeed * Time.deltaTime);
            anim.SetFloat("Speed", 1); //kolko god sam da je vise od 0.1 da pièi
        }
        else
        {
            anim.SetFloat("Speed", 0); //ako player ne pièi, vrati animaciju na idle
        }


            //gravitacija

        //generiramo sferu pod nogama da detektiramo jesmo na podu il ne
        isGrounded = Physics.CheckSphere(transform.position, 0.1f, 1);

        //drži velocity na odreðenoj vrijednosti
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -1;
        }

        //vuci playera dole stalno
        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
