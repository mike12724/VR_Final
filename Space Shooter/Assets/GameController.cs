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
        if (Input.GetKeyDown(KeyCode.Escape)) //hit escape at any time to exit app
        {
            Application.Quit(); 
        }
        if (restart) //if in "gameover" state
        {
            if (Input.GetKeyDown(KeyCode.R)) //and player hits "R" key
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //restart the game
            }
        }
    }
    IEnumerator SpawnWaves() //Basically a parallel runtime routine
    {
        yield return new WaitForSeconds(startWait); //at game start, waits for startWait amount of time
        while (true) //before starting to spawn asteroids
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 playerPosition = player.transform.position;
                Vector3 spawnPosition = Random.insideUnitSphere;
                spawnPosition = spawnPosition.normalized; //spawn position is somewhere on unit shell
                spawnPosition *= Random.Range(spawnValues.x, spawnValues.y); //Scale it to be further away
                spawnPosition += playerPosition; //offset it by player position
                Quaternion spawnRotation = Quaternion.identity;
                //overall: spawn asteroid randomly in a sphere centered on the player
                //at least spawnValues.x away from player (at most spawnValues.y away from player)
                Instantiate(hazard, spawnPosition, spawnRotation); //Create asteroid 
                yield return new WaitForSeconds(spawnWait); //wait time b/w asteroids
            }
            yield return new WaitForSeconds(waveWait); //wait time b/w waves of asteroids
            if (gameOver)
            {
                GameObject[] asteroids = GameObject.FindGameObjectsWithTag("asteroid");
                for (int i = 0; i < asteroids.Length; i++)
                {
                    Destroy(asteroids[i]); //destory all remaining asteroids
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
        //disable player controls when gameover occurs
        GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
        gameOver = true;
    }
}
