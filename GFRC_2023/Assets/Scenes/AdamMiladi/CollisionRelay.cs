using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionRelay : MonoBehaviour
{

    public bool Movelock = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

        void OnTriggerEnter(Collider other)
    {   
        if (other.gameObject.CompareTag("Friend"))
        {
        Movelock = true;
        }
    }

        void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Friend"))
        {
        Movelock = false;
        }
    }
}
