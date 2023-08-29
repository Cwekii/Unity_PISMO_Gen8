using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Save_2 : MonoBehaviour
{

    float score = 0;

    [SerializeField] Text scoreText;

    [SerializeField] string playerName;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetFloat("rez" + playerName);
        scoreText.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            score += 0.5f;
            scoreText.text = score.ToString();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            score -= 0.3f;
            scoreText.text = score.ToString();
        }
    }


    public void SaveScore()
    {
        PlayerPrefs.SetFloat("rez" + playerName, score);
    }
}
