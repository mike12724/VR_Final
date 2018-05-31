using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour {
private Rigidbody rb;
	// Use this for initialization
	public float speed;
	void Start () {
        GameObject player = GameObject.FindWithTag("Player");
        rb = GetComponent<Rigidbody>();
		rb.velocity  = (player.transform.position - transform.position )* speed;
	}
	

}
