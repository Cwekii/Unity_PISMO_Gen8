using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f; // varijabla za brzinu kretanja mi�a
    public Transform playerBody; // referenca na transform na�eg lika
    public float xRotation = 0f; // varijabla koja je odgovorna za rotaciju gore dolje

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // dio koda pomo�u kojega maknemo mi� sa ekrana
    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        playerBody.Rotate(Vector3.up * mouseX);
        xRotation -= mouseY; // kod odgovoran za rotaciju kamere gore dolje, zna�i oduzimamo vrijednos koju dobijemo
                            // od mi�a kako ga pomi�emo od stvarne x kordinate na transformu
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ograni�avamo da mo�emo i�i samo 90 stupnjeva gore i 90
                                                      //stupnjeva dolje
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0); // linija koda koja nam slu�i za postavljanje
        // lokalne rotacije objekta (naj�e��e kamere �to je i u na�em slu�aju)
    }
}
