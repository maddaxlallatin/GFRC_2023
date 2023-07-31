using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChuck : MonoBehaviour
{
    public float GrabLength = 0;
    public float ArmAngle = 0;
    public float ArmSpeed = 10;
    public GameObject Grabber;
    public bool Movelock = false;

    public CollisionRelay Relay;

    void Start()
    {}

    void Movement() 
    {
        if (Input.GetKey("e") && Movelock == false)
        {
            if (ArmAngle < 180)
            {
                ArmAngle = ArmAngle + 10f;
                transform.Rotate(0,ArmSpeed,0,Space.Self);
            } 
            if (GrabLength < .16f)
            {
                
                GrabLength = GrabLength + .01f + .05f*Input.mouseScrollDelta.y;
                Grabber.transform.localPosition = new Vector3( GrabLength, 0, .05f);
            }
        }
        if (Input.GetKey("q"))
        {
            if (ArmAngle > 0)
            {
                ArmAngle = ArmAngle - 10f;
                transform.Rotate(0,-ArmSpeed,0,Space.Self);
            } 
             if (GrabLength > 0)
            {
                GrabLength = GrabLength - .01f + .02f*Input.mouseScrollDelta.y;
                Grabber.transform.localPosition = new Vector3( GrabLength,0, .05f);
            } 
        }
    }
    void FixedUpdate()
    {
        Movement();
    }

}