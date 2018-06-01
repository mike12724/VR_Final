using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {

    // Use this for initialization
    private Rigidbody rb;
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        float rotate = Input.GetAxis("Horizontal");
        rb.AddRelativeTorque(Vector3.up * rotate * 4);
    }
}
