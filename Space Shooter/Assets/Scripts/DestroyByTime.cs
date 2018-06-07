using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour {
public float lifetime;

    //Destroy object after certain time
    //useful for explosion graphics, for example
void Start()
{
Destroy(gameObject,lifetime);
}

}
