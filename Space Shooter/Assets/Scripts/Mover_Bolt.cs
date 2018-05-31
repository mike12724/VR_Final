using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Bolt : MonoBehaviour {
    private Rigidbody rb;
    // Use this for initialization
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
       
    }


}
