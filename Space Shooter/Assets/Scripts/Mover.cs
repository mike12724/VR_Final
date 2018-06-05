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
		rb.velocity  = Vector3.Normalize(player.transform.position+ Random.insideUnitSphere*4 - transform.position )* speed;
	}
	

}
