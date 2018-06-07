using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
private Rigidbody rb;
	// attach to asteroid prefab
    // moves asteroid in the "general direction" of the player:
    // finds vector of direction b/w asteroid and player, then adds 
    //uniform random noise
	public float speed;
	void Start () {
        GameObject player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
		rb.velocity  = Vector3.Normalize(player.transform.position - transform.position + Random.insideUnitSphere*4  )* speed;
	}
	

}
