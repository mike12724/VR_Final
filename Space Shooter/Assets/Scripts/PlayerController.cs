using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public float thrust;
    public float torque;
    public float slow;
    public GameObject shot;
    public GameObject boundary;
    public Transform shotSpawn;
    public Transform shotSpawn2;
    public float fireRate;
    private float nextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
        }

    }
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Jump");
        float rotate = Input.GetAxis("Horizontal");
        float updown = Input.GetAxis("Vertical");
        rb.AddRelativeForce(Vector3.forward * moveVertical* thrust);

        transform.Rotate(Vector3.up*rotate*torque);
        transform.Rotate(Vector3.right * updown*torque);

        SphereCollider s = boundary.GetComponent<SphereCollider>();
        rb.position = Vector3.ClampMagnitude(rb.position, s.radius-2);
    }
}
