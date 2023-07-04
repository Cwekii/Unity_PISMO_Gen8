using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // varijabla za brzinu kretanja miša
    public Transform playerBody; // referenca na transform našeg lika
    public float xRotation = 0f; // varijabla koja je odgovorna za rotaciju gore dolje

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // dio koda pomoæu kojega maknemo miš sa ekrana
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY; // kod odgovoran za rotaciju kamere gore dolje, znaèi oduzimamo vrijednos koju dobijemo
                            // od miša kako ga pomièemo od stvarne x kordinate na transformu
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ogranièavamo da možemo iæi samo 90 stupnjeva gore i 90
                                                      //stupnjeva dolje
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // linija koda koja nam služi za postavljanje
        // lokalne rotacije objekta (najèešæe kamere što je i u našem sluèaju)
    }
}
