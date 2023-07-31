using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuckGrabCube : MonoBehaviour
{
    public bool Grab = false;
    public bool Full = false;
    public CubeChuck CubeCheck;
    public float ArmAngle;

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
        ArmAngle = CubeCheck.ArmAngle;
        Pickup();
    }

    void OnTriggerStay(Collider other)
    {   
        if (other.gameObject.CompareTag("CubeCollect") && Full == false && Grab == true)
        {
            other.tag = "CubeCollected";
            Full = true;
            other.gameObject.transform.parent = gameObject.transform;
        }

        if (other.gameObject.CompareTag("CubeCollected") && Grab == true)
        {               
            other.gameObject.transform.position = gameObject.transform.position;
            other.gameObject.transform.rotation = transform.rotation;
        }
        if (other.gameObject.CompareTag("CubeCollected") && Grab == false)
        {
        other.tag = "CubeCollect";
        Full = false;
        other.gameObject.transform.parent = null;
        if (ArmAngle == 0) 
        {
          Debug.Log(other.gameObject.transform.rotation);
          other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(-10, 0, 5, ForceMode.Impulse);
        }
        }
    }
}