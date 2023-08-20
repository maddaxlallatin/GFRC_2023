using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AILongArm : MonoBehaviour
{
public float GrabAngle = 0;
    public float GrabLength = 0;
    public float ArmAngle = 0;
    public float ArmSpeed;
    public float GrabASpeed;
    public GameObject Grabber;
    public GameObject ExArm;
    public AIGrabCone AICone;
    public AIGrabCube AICube;
    public bool CubeIntent;
    public bool ConeIntent;
    public AIHeavy AI;
    public bool Full;

    void Start()
    {}

    void Movement() 
    {
        CubeIntent = AI.CubeIntent;
        ConeIntent = AI.ConeIntent;
        if (CubeIntent == true || ConeIntent == true)
        {
            if (AICone.Full == true || AICube.Full == true) {Full = true;}
            else {Full = false;}
            if (ArmAngle < 28 && Full == false)
            {
                ArmAngle = ArmAngle + .2f;
                transform.Rotate(0,0,ArmSpeed,Space.Self);
            } 
        }
        // if ()
        // {
        //     if (ArmAngle > 0)
        //     {
        //         ArmAngle = ArmAngle - .2f;
        //         transform.Rotate(0,0,-ArmSpeed,Space.Self);
        //     } 
        // }
            if (CubeIntent == true || ConeIntent == true)
        {
            if (GrabLength < .17f && Full == false)
            {                
                GrabLength = GrabLength + .01f;
                Grabber.transform.localPosition = new Vector3(0, GrabLength, 0);
            } 
            else if (GrabLength < .73f && Full == true)
            {
                GrabLength = GrabLength + .01f;
                Grabber.transform.localPosition = new Vector3(0, GrabLength, 0);
            }
            else if (GrabLength < .87f && Full == true)
            {
                GrabLength = GrabLength + .01f;
                ExArm.transform.localPosition = new Vector3(-.69f + GrabLength, 0, 0);
            }
        }
        
            // if (GrabLength > .73)
            // {
            //     GrabLength = GrabLength - .01f;
            //     ExArm.transform.localPosition = new Vector3(-.69f + GrabLength, 0, 0);
            // } 
            // else
            //     if (GrabLength > 0)
            //     {
            //         GrabLength = GrabLength - .01f;
            //         Grabber.transform.localPosition = new Vector3(0, GrabLength, 0);
            //     }
        
    }

    void FixedUpdate()
    {
        Movement();
    }
}
