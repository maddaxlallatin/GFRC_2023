using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fullness : MonoBehaviour
{
    public bool AntiCone;
    public bool AntiCube;
    public GameObject RedSpawn;
    public GameObject BlueSpawn;
    public ItemSpawner Deposit;
    public bool Red;

    void start()
    {
       Deposit = FindObjectOfType<ItemSpawner>();
    }


    void OnTriggerStay(Collider Other)
    {   
        if (Other.tag == "ConeCollect" && AntiCone == false && gameObject.tag != "Full")
        {
            Other.tag = "ConeScored";
            Destroy(Other.gameObject.GetComponent<Rigidbody>());
            Other.transform.position = transform.position + new Vector3(0,.09f,0);
            Other.transform.rotation = transform.rotation;
            Other.gameObject.transform.parent = gameObject.transform;
            gameObject.tag = "Full";
        }
        else if (Other.tag == "CubeCollect" && AntiCube == false && gameObject.tag != "Full")
        {
            Other.tag = "CubeScored";
            Destroy(Other.gameObject.GetComponent<Rigidbody>());
            Other.transform.position = transform.position + new Vector3(0,.09f,0);
            Other.transform.rotation = transform.rotation;
            Other.gameObject.transform.parent = gameObject.transform;
            gameObject.tag = "Full";
            if (Red == true){Deposit.RedBank++;}
            else {Deposit.BlueBank++;}
        }
    }
}
