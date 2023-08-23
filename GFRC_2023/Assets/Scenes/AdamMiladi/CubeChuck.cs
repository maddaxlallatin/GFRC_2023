using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CubeChuck : MonoBehaviour
{
    private Gamepad gamepad;

    public float GrabLength = 0;
    public float ArmAngle = 0;
    public GameObject Grabber;
    public ChuckGrabCube FCheck;
    public bool Full = false;
    public bool SlingShot = false;
    public float Power = 0;
    public bool Reset = false;
    public bool Marker = false;
    public GameObject Aimer;
    public GameObject PickUpBox;
    public GameObject AimMarker;

    public CollisionRelay Relay;

    void Start()
    {
        gamepad = Gamepad.current; 
    }

    void Movement() 
    {
        SlingShot = FCheck.SlingShot;
        if (gamepad != null && gamepad.rightTrigger.isPressed == true && SlingShot == false|| Input.GetKey("e") && SlingShot == false)
        {
            Full = FCheck.Full;
            if (ArmAngle < 180 && GrabLength < .16f && Full == false)
            {
                ArmAngle = ArmAngle + 180/20;
                transform.Rotate(0,180/20,0,Space.Self);
                
                GrabLength = GrabLength + .16f/20;
                Grabber.transform.localPosition = new Vector3(GrabLength, 0, .049f);
            }
            if (ArmAngle < 180 && GrabLength < .16f && Full == true)
            {
                ArmAngle = ArmAngle + 180/20;
                transform.Rotate(0,180/20,0,Space.Self);
                
                GrabLength = GrabLength + .16f/10;
                Grabber.transform.localPosition = new Vector3(GrabLength, 0, .049f);
            }
        }
        if (gamepad != null && gamepad.leftTrigger.isPressed == true && SlingShot == false||Input.GetKey("q") && SlingShot == false)
        {
            Full = FCheck.Full;

            if (ArmAngle > 0 && GrabLength > -.16f && Full == true)
            {
                ArmAngle = ArmAngle - 180/20;
                transform.Rotate(0,-180/20,0,Space.Self);

                GrabLength = GrabLength - .16f/10;
                Grabber.transform.localPosition = new Vector3(GrabLength,0, .049f);
            } 
            if (ArmAngle > 0 && GrabLength > 0 && Full == false)
            {
                ArmAngle = ArmAngle - 180/20;
                transform.Rotate(0,-180/20,0,Space.Self);

                GrabLength = GrabLength - .16f/20;
                Grabber.transform.localPosition = new Vector3(GrabLength,0, .049f);
            } 

        }
        if (SlingShot == true)
        {
            if (Marker == false) 
            {
                Marker = true; 
                AimMarker = Instantiate(Aimer, PickUpBox.transform.position, transform.rotation) as GameObject;
                AimMarker.transform.parent = transform;
            }
            Power = FCheck.Power;
            AimMarker.transform.localPosition = new Vector3((-Power*Mathf.Sin(30* Mathf.PI/180)/9.81f)*.5f*Power*Mathf.Sin(60* Mathf.PI/180)-.37f,0, .049f);
            Grabber.transform.localPosition = new Vector3(-GrabLength*(Power-10)/10,0, .049f);
        }

        Reset = FCheck.Reset;

        if (Reset == true) 
        {
            Destroy(AimMarker);
            transform.Rotate(0,-ArmAngle,0,Space.Self);
            ArmAngle = 0;
            GrabLength = 0;
            Grabber.transform.localPosition = new Vector3(0,0, .049f);
            Reset = false;
            Marker = false;
        }
    }
    void FixedUpdate()
    {
        Movement();
    }

}