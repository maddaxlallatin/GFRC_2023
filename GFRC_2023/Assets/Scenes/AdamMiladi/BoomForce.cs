using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomForce : MonoBehaviour
{
public Vector3 PZBump = new Vector3(0,0,1000);
public Rigidbody BotBody;


    void OnTriggerStay(Collider Other)
    {   
        if (Other.tag == "LeftEdge")
        {
            BotBody.AddForceAtPosition(PZBump, transform.position,ForceMode.Impulse);
            Debug.Log("Boom");
        }
        if (Other.tag == "RightEdge")
        {
            BotBody.AddForceAtPosition(-PZBump, transform.position,ForceMode.Impulse);
            Debug.Log("Boom2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}