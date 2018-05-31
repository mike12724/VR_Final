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
    public float fireRate;
    private float nextFire;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
      
        }

    }
    void FixedUpdate()
    {
        float moveVertical = Input.GetAxis("Vertical");
        float rotate = Input.GetAxis("Horizontal");
        float updown = Input.GetAxis("Jump");
        rb.AddRelativeForce(Vector3.forward * moveVertical* thrust);
        rb.AddRelativeTorque(Vector3.up * torque * rotate);
        rb.AddRelativeForce(Vector3.up * updown * thrust);
        if (moveVertical == 0)
        {
            Vector3 slower = new Vector3(slow, 1, slow);
            rb.velocity = Vector3.Scale(rb.velocity, slower);
        }
        if (updown == 0)
        {
            Vector3 slower = new Vector3(1, slow, 1);
            rb.velocity = Vector3.Scale(rb.velocity, slower);
        }
        if (rotate == 0)
        {
            Vector3 slower = new Vector3(slow, slow, slow);
            rb.angularVelocity = Vector3.Scale(rb.angularVelocity, slower);
        }
        SphereCollider s = boundary.GetComponent<SphereCollider>();
        rb.position = Vector3.ClampMagnitude(rb.position, s.radius-2);
    }
}
