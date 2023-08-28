using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawConeGrab : MonoBehaviour
{
    public bool Grab = false;
    public bool Full = false;
    public int ConeIntent;
    public AIScout AI;

    void Start()
    {
    }

    void Pickup()
    {
        ConeIntent = AI.ConeIntent;
        if (ConeIntent == 0 && AI.Path.x*AI.Path.x + AI.Path.z*AI.Path.z < .4f && Grab == false || ConeIntent == 6 && AI.Path.x*AI.Path.x + AI.Path.z*AI.Path.z < .4f && Grab == false)
        {
            Grab = true;
        }
        
        else if (ConeIntent == 4 && Grab == true)
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
        if (other.gameObject.CompareTag("ConeCollect") && Full == false && Grab == true)
        {
            other.tag = "ConeCollected";
            Full = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.transform.parent = gameObject.transform;
        }

        if (other.gameObject.CompareTag("ConeCollected") && Grab == true)
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