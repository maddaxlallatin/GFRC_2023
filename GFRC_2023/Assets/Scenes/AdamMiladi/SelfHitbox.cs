using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfHitbox : MonoBehaviour
{

    public GameObject Robot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = Robot.transform.position;
        transform.rotation = Robot.transform.rotation;
    }
}
