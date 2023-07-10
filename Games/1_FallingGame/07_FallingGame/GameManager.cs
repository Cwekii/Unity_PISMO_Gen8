using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int score = 0; //broj bodova
    public int life = 3;  //broj života

    private void Update()
    {
        Debug.Log("Score je: " + score + ", a life je: " + life);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
            Debug.Log("Izašlo je");

        }

        if (life <= 0)
        {
            Debug.Log("Izgubio si!");
            Application.Quit();
        }
    }

    
}
