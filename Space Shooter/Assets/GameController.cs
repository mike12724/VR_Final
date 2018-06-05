using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Vector2 spawnValues;
    public GameObject hazard;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    //public GUIText scoreText;
    private int score;
    public Text scoreText;
    public Text restartText;
    public Text gameOverText;

    private bool gameOver;
    private bool restart;
    public GameObject player;
    private Rigidbody rb;

    void Start()
    {
        rb = player.GetComponent<Rigidbody>();
        gameOver = false;
        restart = false;
        restartText.text = "";
        gameOverText.text = "";
        score = 0;
        UpdateScore();
        StartCoroutine(SpawnWaves());
        UpdateScore();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 playerPosition = player.transform.position;
                Vector3 spawnPosition = Random.insideUnitSphere;
                spawnPosition = spawnPosition.normalized;
                spawnPosition *= Random.Range(spawnValues.x, spawnValues.y);
                spawnPosition += playerPosition;
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
                GameObject[] asteroids = GameObject.FindGameObjectsWithTag("asteroid");
                for (int i = 0; i < asteroids.Length; i++)
                {
                    Destroy(asteroids[i]);
                }
                restartText.text = "Press 'R' for Restart";
                restart = true;
                break;
            }
        }

    }
    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }
    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();

    }
    public void GameOver()
    {
        gameOverText.text = "Game Over";
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        gameOver = true;
    }
}
