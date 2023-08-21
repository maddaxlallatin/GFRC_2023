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
    public int CubeIntent;
    public int ConeIntent;
    public AIHeavy AI;
    public bool Full;

    void Start()
    {}

    void Movement() 
    {
        CubeIntent = AI.CubeIntent;
        ConeIntent = AI.ConeIntent;

        if (AICone.Full == true || AICube.Full == true) {Full = true;}
        else {Full = false;}

        if (CubeIntent == 1 || ConeIntent == 1)
        {
            if (ArmAngle < 28)
            {
                ArmAngle = ArmAngle + .2f;
                transform.Rotate(0,0,ArmSpeed,Space.Self);
            } 
        }

            if (CubeIntent == 2 || ConeIntent == 2)
        {
            if (GrabLength < .17f)
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

        if (CubeIntent == 3 || ConeIntent == 3)
        {
            if (ArmAngle < 38)
            {
                ArmAngle = ArmAngle + .2f;
                transform.Rotate(0,0,ArmSpeed,Space.Self);
            } 
        }

            if (CubeIntent == 3 || ConeIntent == 3)
        {
            if (GrabLength < .17f)
            {                
                GrabLength = GrabLength + .01f;
                Grabber.transform.localPosition = new Vector3(0, GrabLength, 0);
            } 
            else if (GrabLength < .73f && Full == true)
            {
                GrabLength = GrabLength + .01f;
                Grabber.transform.localPosition = new Vector3(0, GrabLength, 0);
            }
            else if (GrabLength < 1.46f && Full == true)
            {
                GrabLength = GrabLength + .01f;
                ExArm.transform.localPosition = new Vector3(-.69f + GrabLength, 0, 0);
            }
        }
            if (CubeIntent == 3 || ConeIntent == 3)
        {
            if (GrabAngle < 20f)
            {                
                GrabAngle = GrabAngle + .2f;
                Grabber.transform.Rotate(0,0,-GrabASpeed,Space.Self);
            } 
        }
        
    }

    void FixedUpdate()
    {
        Movement();
    }
}
