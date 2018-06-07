using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Boundary destoryer: Destorys anything that collides with
//the object this script is attached to

public class DestroyByBound : MonoBehaviour {

    void OnTriggerExit(Collider other)
    {
        Destroy(other.gameObject); 
    }
}
