using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeChuck : MonoBehaviour
{
    public float GrabAngle = 0;
    public float GrabLength = 0;
    public float ArmAngle = 0;
    public float ArmSpeed;
    public float GrabASpeed;
    public GameObject Grabber;
    public GameObject ExArm;
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
                ArmAngle = ArmAngle + .6f;
                transform.Rotate(0,ArmSpeed,0,Space.Self);
            } 
        }
        if (Input.GetKey("q"))
        {
            if (ArmAngle > 0)
            {
                ArmAngle = ArmAngle - .6f;
                transform.Rotate(0,-ArmSpeed,0,Space.Self);
            } 
        }
        if (Input.GetKey("v") && Movelock == false)
        {
            if (GrabAngle > 0)
            {
                GrabAngle = GrabAngle - .2f;
                Grabber.transform.Rotate(0,0,GrabASpeed,Space.Self);
            } 
        }
            if (Input.GetKey("c"))
        {
            if (GrabAngle < 80)
            {
                GrabAngle = GrabAngle + .2f;
                Grabber.transform.Rotate(0,0,-GrabASpeed,Space.Self);
            } 
        }
            if (Input.GetKey("r") || Input.mouseScrollDelta.y > 0)
        {
            if (GrabLength < .16f)
            {
                
                GrabLength = GrabLength + .01f + .05f*Input.mouseScrollDelta.y;
                Grabber.transform.localPosition = new Vector3( GrabLength, 0, .05f);
            } 

        }
            if (Input.GetKey("f") && Movelock == false || Input.mouseScrollDelta.y < 0 && Movelock == false)
        {
            if (GrabLength > -.16)
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