using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCone : MonoBehaviour
{
    public bool Grab = false;
    public bool Full = false;
    public bool Checkother = false;
    public GrabCube CubeCheck;

    void Start()
    {
    }

    void Pickup()
    {
        if (Input.GetKeyDown("space") && Grab == false)
        {
            Grab = true;
        }
        
        else if (Input.GetKeyDown("space") && Grab == true)
        {
            Grab = false;
            Full = false;
        }
    }

    void Update()
    {
        Pickup();
    }

    void OnTriggerStay(Collider other)
    {   
        Checkother = CubeCheck.Full;
        if (other.gameObject.CompareTag("ConeCollect") && Full == false && Checkother == false && Grab == true)
        {
            other.tag = "ConeCollected";
            Full = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.transform.parent = gameObject.transform;
        }

        if (other.gameObject.CompareTag("ConeCollected") && Grab == true && Checkother == false)
        {               
            other.gameObject.transform.position = gameObject.transform.position;
            other.gameObject.transform.rotation = transform.rotation;
        }
        if (other.gameObject.CompareTag("ConeCollected") && Grab == false )
        {other.tag = "ConeCollect";
        Full = false;
        other.gameObject.transform.parent = null;
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
