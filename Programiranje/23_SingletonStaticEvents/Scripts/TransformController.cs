using UnityEngine;

public class TransformController : MonoBehaviour
{
    public ScoreManager scoreManager;


    private void Start()
    {
        scoreManager = ScoreManager.Instance;
        transform.ActivateChildren();
        transform.GetChild(0).ResetTransform();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            scoreManager.AddScore(5);
        }
    }

    private void OnApplicationFocus(bool focus)
    {
        
    }
}
