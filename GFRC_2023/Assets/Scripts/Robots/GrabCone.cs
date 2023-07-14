using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCone : MonoBehaviour
{
    public bool Grab = false;
    public bool Full = false;
    public bool Checkother = false;
    public GrabCube CubeCheck;
    // Start is called before the first frame update
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
    // Update is called once per frame
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
        }

        if (other.gameObject.CompareTag("ConeCollected") && Grab == true && Checkother == false)
        {               
            other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            other.gameObject.transform.rotation = transform.rotation;
        }
        if (other.gameObject.CompareTag("ConeCollected") && Grab == false )
        {other.tag = "ConeCollect";
        Full = false;}
    }
    
}
