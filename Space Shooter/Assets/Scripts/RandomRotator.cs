using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotator : MonoBehaviour {
private Rigidbody rb;
public float tumble;
	// Simple script for making asteroids tumble about their center of mass
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.angularVelocity =  Random.insideUnitSphere * tumble; 
	}
	

}
