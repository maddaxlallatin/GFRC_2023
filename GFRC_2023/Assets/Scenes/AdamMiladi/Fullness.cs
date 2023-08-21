using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullness : MonoBehaviour
{
    public bool AntiCone;
    public bool AntiCube;

    void OnTriggerStay(Collider Other)
    {   
        if (Other.tag == "ConeCollect" && AntiCone == false)
        {
            Other.tag = "ConeCollected";
            // Other.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            Destroy(Other.gameObject.GetComponent<Rigidbody>());
            Other.transform.position = transform.position;
            Other.transform.rotation = transform.rotation;
        }
        else if (Other.tag == "CubeCollect" && AntiCube == false)
        {
            Other.tag = "CubeCollected";
        }
    }
}
