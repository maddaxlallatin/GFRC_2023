using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class LongArm : MonoBehaviour
{
    private Gamepad gamepad;
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
    {
        gamepad = Gamepad.current; 
    }

    void Movement() 
    {
        if (gamepad != null && gamepad.leftTrigger.isPressed == true && Movelock == false || Input.GetKey("e") && Movelock == false)
        {
            if (ArmAngle < 60)
            {
                ArmAngle = ArmAngle + .2f;
                transform.Rotate(0,0,ArmSpeed,Space.Self);
            } 
        }
        if (gamepad != null && gamepad.rightTrigger.isPressed == true ||Input.GetKey("q"))
        {
            if (ArmAngle > 0)
            {
                ArmAngle = ArmAngle - .2f;
                transform.Rotate(0,0,-ArmSpeed,Space.Self);
            } 
        }
        if (gamepad != null && gamepad.buttonSouth.isPressed == true && Movelock == false || Input.GetKey("v") && Movelock == false)
        {
            if (GrabAngle > 0)
            {
                GrabAngle = GrabAngle - .2f;
                Grabber.transform.Rotate(0,0,GrabASpeed,Space.Self);
            } 
        }
            if (gamepad != null && gamepad.buttonNorth.isPressed == true || Input.GetKey("c"))
        {
            if (GrabAngle < 80)
            {
                GrabAngle = GrabAngle + .2f;
                Grabber.transform.Rotate(0,0,-GrabASpeed,Space.Self);
            } 
        }
            if (gamepad != null && gamepad.rightShoulder.isPressed == true || Input.GetKey("r") || Input.mouseScrollDelta.y > 0)
        {
            if (GrabLength < .73f)
            {
                
                GrabLength = GrabLength + .01f + .05f*Input.mouseScrollDelta.y;
                Grabber.transform.localPosition = new Vector3(0, GrabLength, 0);
            } 
            else 
                if (GrabLength < 1.42f)
                {
                    GrabLength = GrabLength + .01f + .05f*Input.mouseScrollDelta.y;
                    ExArm.transform.localPosition = new Vector3(-.69f + GrabLength, 0, 0);
                }
        }
            if (gamepad != null && gamepad.leftShoulder.isPressed == true && Movelock == false || Input.GetKey("f") && Movelock == false || Input.mouseScrollDelta.y < 0 && Movelock == false)
        {
            if (GrabLength > .73)
            {
                GrabLength = GrabLength - .01f + .02f*Input.mouseScrollDelta.y;
                ExArm.transform.localPosition = new Vector3(-.69f + GrabLength, 0, 0);
            } 
            else
                if (GrabLength > 0)
                {
                    GrabLength = GrabLength - .01f + .02f*Input.mouseScrollDelta.y;
                    Grabber.transform.localPosition = new Vector3(0, GrabLength, 0);
                }
        }
    }

    void FixedUpdate()
    {
        Movelock = Relay.Movelock;
        Movement();
        // Debug.Log(ArmAngle);
        // Debug.Log(GrabLength);
    }

}