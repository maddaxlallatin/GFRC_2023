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

        if (AI.Path.x*AI.Path.x + AI.Path.z*AI.Path.z < .4f && CubeIntent == 0)
        {
            if (ArmAngle < 28f)
            {
                ArmAngle = ArmAngle + .2f;
                transform.Rotate(0,0,ArmSpeed,Space.Self);
            } 
            if (GrabLength < .16f)
            {                
                GrabLength = GrabLength + .01f;
                Grabber.transform.localPosition = new Vector3(0, GrabLength, 0);
            } 
        }
        else if (CubeIntent == 1)
        {
            if (ArmAngle > 0f)
            {
                ArmAngle = ArmAngle - .2f;
                transform.Rotate(0,0,-ArmSpeed,Space.Self);
            } 
            if (GrabLength > 0f && ArmAngle < 20f)
            {                
                GrabLength = GrabLength - .01f;
                Grabber.transform.localPosition = new Vector3(0, GrabLength, 0);
            } 
        }

        //     else if (GrabLength < .73f && Full == true)
        //     {
        //         GrabLength = GrabLength + .01f;
        //         Grabber.transform.localPosition = new Vector3(0, GrabLength, 0);
        //     }
        //     else if (GrabLength < .87f && Full == true)
        //     {
        //         GrabLength = GrabLength + .01f;
        //         ExArm.transform.localPosition = new Vector3(-.69f + GrabLength, 0, 0);
        //     }
        // }

        if (CubeIntent == 3 && AI.Row == 3|| ConeIntent == 3 && AI.Row == 3)
        {
            if (ArmAngle < 45)
            {
                ArmAngle = ArmAngle + .2f;
                transform.Rotate(0,0,ArmSpeed,Space.Self);
            } 
        {
            if (GrabLength < .73f && Full == true)
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
            if (GrabAngle < 45f)
            {                
                GrabAngle = GrabAngle + .2f;
                Grabber.transform.Rotate(0,0,-GrabASpeed,Space.Self);
            } 
            // if (GrabLength > 1.45f && ArmAngle > 44.8f)
            // {
            //     AI.CubeIntent = 4;
        }
        else if (CubeIntent == 3 && AI.Row == 2|| ConeIntent == 3 && AI.Row == 2)
        {
            if (ArmAngle < 45)
            {
                ArmAngle = ArmAngle + .2f;
                transform.Rotate(0,0,ArmSpeed,Space.Self);
            } 
        {
            if (GrabLength < .73f && Full == true)
            {
                GrabLength = GrabLength + .01f;
                Grabber.transform.localPosition = new Vector3(0, GrabLength, 0);
            }
            else if (GrabLength < 1f && Full == true)
            {
                GrabLength = GrabLength + .01f;
                ExArm.transform.localPosition = new Vector3(-.69f + GrabLength, 0, 0);
            }
        }
            if (GrabAngle < 45f)
            {                
                GrabAngle = GrabAngle + .2f;
                Grabber.transform.Rotate(0,0,-GrabASpeed,Space.Self);
            } 
        //     if (GrabLength > 1.45f && ArmAngle > 18.8f)
        //     {
        //         AI.CubeIntent = 4;
        // }
        }
        if (CubeIntent == 4 && AICube.Full == false || ConeIntent == 4)
        {
            if (ArmAngle > 0)
            {
                ArmAngle = ArmAngle - .2f;
                transform.Rotate(0,0,-ArmSpeed,Space.Self);
            } 

            if (GrabLength > .73f)
            {
                GrabLength = GrabLength - .01f;
                ExArm.transform.localPosition = new Vector3(-.69f + GrabLength, 0, 0);
            }
            else if (GrabLength > .04f)
            {
                GrabLength = GrabLength - .01f;
                Grabber.transform.localPosition = new Vector3(0, GrabLength, 0);
            }
        
            if (GrabAngle > 0f)
            {                
                GrabAngle = GrabAngle - .2f;
                Grabber.transform.Rotate(0,0,GrabASpeed,Space.Self);
            } 
        }
        
    }

    void FixedUpdate()
    {
        
        Movement();
    }
}
