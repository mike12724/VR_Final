using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerControllerAstronaut : MonoBehaviour {
private Rigidbody rb; 
//public float speed;
//public float tilt;
//public Boundary boundary;
//public GameObject shot;
//public Transform shotSpawn; 
//private AudioSource audioSource;
public float thrust;

private float nextFire;
void Start()
{
	rb = GetComponent<Rigidbody>();
	
}
void FixedUpdate()
    {
        rb.AddRelativeForce(Vector3.forward * thrust);
    }


}
