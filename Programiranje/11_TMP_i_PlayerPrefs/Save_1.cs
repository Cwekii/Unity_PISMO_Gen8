using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save_1 : MonoBehaviour
{
    [SerializeField] Text scoreText;
    int score = 0;



    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Rezultat");
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            score++;
            scoreText.text = score.ToString();
            PlayerPrefs.SetInt("Rezultat", score);
        }
    }
}
