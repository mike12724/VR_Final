﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float thrust;
    public float turnRate;
    public GameObject shot; //bullet
    public GameObject boundary;
    public Transform shotSpawn; //Bullet spawn point/direction
    public Transform shotSpawn2;
    public float fireRate;
    private float nextFire;
    private AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        rb.centerOfMass = Vector3.zero; //Not strictly necessary?
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation); //Shoot bullets from each gun
            Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
            audioSource.Play(); //play pew-pew sound
        }

    }
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Jump"); //Get player inputs
        float rotate = Input.GetAxis("Horizontal");
        float updown = Input.GetAxis("Vertical");
        rb.AddRelativeForce(Vector3.forward * moveVertical* thrust); //Force-based position transform

        transform.Rotate(Vector3.up*rotate*turnRate); //Direct rotation transforms
        transform.Rotate(Vector3.right * updown*turnRate);


        SphereCollider s = boundary.GetComponent<SphereCollider>(); //Find boundary sphere
        rb.position = Vector3.ClampMagnitude(rb.position, s.radius-2); //Clamp player position to be inside the boundary
    }
}
