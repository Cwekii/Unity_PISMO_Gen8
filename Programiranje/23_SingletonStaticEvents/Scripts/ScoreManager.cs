using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [SerializeField, Range(0, 100)] private int score;

    public int Score => score;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(this);
        } 
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    public void AddScore(int amount)
    {
        score += amount;
    }


}
