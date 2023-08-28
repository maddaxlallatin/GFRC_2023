using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomForce : MonoBehaviour
{
public Vector3 PZBump = new Vector3(0,0,1000);
public int Blue;
public float chuck = 1f;

public Rigidbody BotBody;

    void OnTriggerEnter(Collider Other)
    {   
        if (Other.tag == "Bumper")
        {
            BotBody.velocity = new Vector3(BotBody.velocity.x*-1, BotBody.velocity.y*-1, BotBody.velocity.z*-1);
        }
        if (Other.tag == "Grabber")
        {
            BotBody.velocity = new Vector3(BotBody.velocity.x*-.8f, BotBody.velocity.y*-.8f, BotBody.velocity.z*-.8f);
        }
    }
    void OnTriggerStay(Collider Other)
    {   
        if (Other.tag == "LeftEdge")
        {
            BotBody.AddForceAtPosition(PZBump/chuck, transform.position,ForceMode.Impulse);
            Debug.Log("Boom");
        }
        else if (Other.tag == "RightEdge")
        {
            BotBody.AddForceAtPosition(-PZBump/chuck, transform.position,ForceMode.Impulse);
            Debug.Log("Boom2");
        }
        else if (Other.tag == "Bumper")
        {
            BotBody.AddForceAtPosition(new Vector3(0,0,100 - 200*Blue), transform.position,ForceMode.Impulse);
            Debug.Log("Boom2");
        }
        else if (Other.tag == "Grabber")
        {
            BotBody.AddForceAtPosition(new Vector3(0,0,50 - 100*Blue), transform.position,ForceMode.Impulse);
            Debug.Log("Boom2");
        }
        else if (Other.tag == "Wall")
        {
            BotBody.AddForceAtPosition(new Vector3(0,0,50), transform.position,ForceMode.Impulse);
            Debug.Log("Boom2");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}