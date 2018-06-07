using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject playerExplosion;
    public int scoreValue;
    private GameController gameController;

    //Attach to asteroid prefab; collision handler
    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController"); //Find game controller
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
    void OnTriggerEnter(Collider other) //when something collides with this object
    {
        if (other.tag == "Boundary") //already handled by our destoryByBound script
        {
            return;
        }
        Instantiate(explosion, transform.position, transform.rotation); //Create explosion gfx
        if (other.tag == "Player") //player hits asteroid = game over
        {
            Instantiate(playerExplosion, transform.position, transform.rotation);
            gameController.GameOver();
            return;
        }
        Destroy(other.gameObject); //destory asteroid and other object
        Destroy(gameObject);
        if (other.gameObject.tag == "Bolt") //if destoryed by bullet (as opposed to 2 asteroids colliding)
        {
            gameController.AddScore(scoreValue);
        }
        }
}