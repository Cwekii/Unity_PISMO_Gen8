using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] Text scoreText;
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] Transform spawnPosition;


    float spawnRate;
    List<GameObject> obstacles = new List<GameObject>();

   public float score;

    bool isGameOver;

    private void Awake()
    {
        instance = this;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreText.text = "Score: " + score.ToString("F0");
        spawnRate = 2;

        InitializeObstaclePool();
        StartCoroutine(SpawnTimer());
    }

    // Update is called once per frame
    void Update()
    {
        score += Time.deltaTime;
        scoreText.text ="Score: " + score.ToString("F0");
    }

    private void InitializeObstaclePool()
    {
        for (int i = 0; i < 10; i++)
        {
            GameObject tempObj = Instantiate(prefab, spawnPosition);
            tempObj.SetActive(false);
            obstacles.Add(tempObj);
        }
    }

    IEnumerator SpawnTimer()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(Random.Range(spawnRate * 0.5f, spawnRate));
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        foreach (GameObject obstacle in obstacles)
        {
            if (!obstacle.activeInHierarchy)
            {
                obstacle.SetActive(true);
                break;
            }
        }
    }

    public void ResetPosition(GameObject obstacle)
    {
        obstacle.SetActive(false);
        obstacle.transform.position = spawnPosition.position;
    }

    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }

    public void RestartGame(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
        Time.timeScale = 1;
    }
}
