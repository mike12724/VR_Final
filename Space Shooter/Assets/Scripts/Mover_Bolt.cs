using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover_Bolt : MonoBehaviour {
    private Rigidbody rb;
    
    //Attached to bullet object; moves object 
    //in the direction the player is looking
    public float speed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.up * speed;
       
    }


}
