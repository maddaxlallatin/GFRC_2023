using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncePad : MonoBehaviour
{
public int Blue;
public Rigidbody Box;
   void OnTriggerStay(Collider Other)
    {   
        if (Other.tag == "CubeCollect")
        {
            Box = Other.gameObject.GetComponent<Rigidbody>();
            Box.AddForceAtPosition(new Vector3(1 - 2*Blue,0,0), Box.position,ForceMode.Impulse);
        }
    }
}