using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCube : MonoBehaviour
{
    public bool Grab = false;
    public bool Full = false;
    public bool Checkother = false;
    public GrabCone ConeCheck;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Pickup()
    {
        if (Input.GetKeyDown("space") && Grab == false)
        {
            Debug.Log("nowTrue");
            Grab = true;

            // gameObject.GetComponent<Collider>().isTrigger = true;
        }
        
        else if (Input.GetKeyDown("space") && Grab == true)
        {
            Debug.Log("nowFalse");
            Grab = false;
            Full = false;
            // gameObject.GetComponent<Collider>().isTrigger = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Pickup();
    }

    void OnTriggerStay(Collider other)
    {   
        Checkother = ConeCheck.Full;
        if (other.gameObject.CompareTag("CubeCollect") && Full == false && Checkother == false && Grab == true)
        {
            other.tag = "CubeCollected";
            Full = true;
        }

        if (other.gameObject.CompareTag("CubeCollected") && Grab == true && Checkother == false)
        {               
            other.gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
            other.gameObject.transform.rotation = transform.rotation;
        }
        if (other.gameObject.CompareTag("CubeCollected") && Grab == false )
        {other.tag = "CubeCollect";
        Full = false;}
    }
}