using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int life = 100;
    public float score = 0;

    public void LoseLife(int damage)
    {
        life -= damage;
        if(life <= 0)
        {
            Debug.LogError("LOSE GAME, your score is: " + (int)(score * 1.69333f));
        }
    }
}
