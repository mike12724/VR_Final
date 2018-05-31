using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues;
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
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
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
                Vector3 spawnPosition = new Vector3(Random.Range(playerPosition.x - spawnValues.x, playerPosition.x + spawnValues.x),
                    Random.Range(playerPosition.y - spawnValues.y, playerPosition.y + spawnValues.y),
                    Random.Range(playerPosition.z, playerPosition.z + spawnValues.z));
                spawnPosition = spawnPosition.normalized;
                spawnPosition *= Random.Range(10f, 30f);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);
            if (gameOver)
            {
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
        GameObject[] asteroids = GameObject.FindGameObjectsWithTag("asteroid");
        for (int i = 0; i < asteroids.Length; i++)
        {
            Destroy(asteroids[i]);
        }
        gameOver = true;
    }
}
