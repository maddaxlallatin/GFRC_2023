using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIGrabCube : MonoBehaviour
{
    public bool Grab = false;
    public bool Full = false;
    public bool Checkother = false;
    public AIGrabCone ConeCheck;
    public int CubeIntent;
    public AIHeavy AI;

    void Start()
    {
    }

    void Pickup()
    {
        CubeIntent = AI.CubeIntent;
        if (CubeIntent == 0 && AI.Path.x*AI.Path.x + AI.Path.z*AI.Path.z < .4f && Grab == false || CubeIntent == 6 && AI.Path.x*AI.Path.x + AI.Path.z*AI.Path.z < .4f && Grab == false)
        {
            Grab = true;
        }
        
        else if (CubeIntent == 4 && Grab == true)
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
        Checkother = ConeCheck.Full;
        if (other.gameObject.CompareTag("CubeCollect") && Full == false && Grab == true)
        {
            other.tag = "CubeCollected";
            Full = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.transform.parent = gameObject.transform;
        }

        if (other.gameObject.CompareTag("CubeCollected") && Grab == true && Checkother == false)
        {               
            other.gameObject.transform.position = gameObject.transform.position;
            other.gameObject.transform.rotation = transform.rotation;
        }
        if (other.gameObject.CompareTag("CubeCollected") && Grab == false )
        {other.tag = "CubeCollect";
        Full = false;
        other.gameObject.transform.parent = null;
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}