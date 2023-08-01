using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class GrabberArm : MonoBehaviour
{

    ArmControls armControl;
    public float GrabAngle = 0;
    public float GrabLength = 0;
    public float ArmAngle = 0;
    public float BaseArmSpeed = 0.06f;
    public float GrabASpeed = 0.06f;
    public float MidArmSpeed = 0.1f;
    public GameObject TopArm;
    public GameObject MidArm;
    public bool Movelock = false;


    // public bool mbf = false;
    // public bool mbb = false;
    // public bool mmf = false;
    // public bool mmb = false;

    // void Awake()
    // {
    //     armControl = new ArmControls();

    //     armControl.Arm.MoveBaseForward.performed += ctx => MoveBaseForward();
    //     armControl.Arm.MoveBaseBack.performed += ctx => MoveBaseBack();
    //     armControl.Arm.MoveMidForward.performed += ctx => MoveMidForward();
    //     armControl.Arm.MoveMidBack.performed += ctx => MoveMidBack();
    // }

    // void MoveBaseForward()
    // {
    //     mbf = true;
    //     if (Movelock == false)
    //     {
    //         if (ArmAngle < 220 && mbf == true)
    //         {
    //             ArmAngle = ArmAngle + .2f;
    //             transform.Rotate(0, 0, BaseArmSpeed,Space.Self);
    //             mbf = false;
    //             MoveBaseForward();
    //         } 
    //     }

    // }
    // void MoveBaseBack()
    // {
    //     mbb = true;
    //     if (ArmAngle > 0 && mbb == true)
    //     {
    //         ArmAngle = ArmAngle - .2f;
    //         transform.Rotate(0,0, -BaseArmSpeed,Space.Self);
    //         MoveBaseBack();
    //     }
    // }
    // void MoveMidForward()
    // {
    //     mmf = true;
    //     if (Movelock == false)
    //     {
    //         if (GrabAngle < 220 && mmf == true)
    //         {
    //             GrabAngle = GrabAngle + .2f;
    //             MidArm.transform.Rotate(0,0,MidArmSpeed,Space.Self);
    //             MoveMidForward();
    //         } 
    //     }
    // }
    // void MoveMidBack()
    // {
    //     mmb = true;
    //     if (GrabAngle > 0 && mmb == true)
    //     {
    //         GrabAngle = GrabAngle - .2f;
    //         MidArm.transform.Rotate(0,0,-MidArmSpeed,Space.Self);
    //         MoveMidBack();
    //     }
    // }

    // void OnEnable()
    // {
    //     armControl.Arm.Enable();
    // }

    // void OnDisable()
    // {
    //     armControl.Arm.Disable();
    //     // mbf = false;
    //     // mbb = false;
    //     // mmf = false;
    //     // mmb = false;
    // }

//////////////////////////////////////////////////////////////////////////

    void Update()
    {
        if (Input.GetKey("q") && Movelock == false)
        {
            if (ArmAngle < 220)
            {
                ArmAngle = ArmAngle + .2f;
                transform.Rotate(0, 0, BaseArmSpeed,Space.Self);

            } 
        }

        if (Input.GetKey("e"))
        {
            if (ArmAngle > 0)
            {
                ArmAngle = ArmAngle - .2f;
                transform.Rotate(0,0, -BaseArmSpeed,Space.Self);
            }
        }

        if (Input.GetKey("z") && Movelock == false)
        {
            if (GrabAngle < 220)
            {
                GrabAngle = GrabAngle + .2f;
                MidArm.transform.Rotate(0,0,MidArmSpeed,Space.Self);
            } 
        }

        if (Input.GetKey("c"))
        {
            if (GrabAngle > 0)
            {
                GrabAngle = GrabAngle - .2f;
                MidArm.transform.Rotate(0,0,-MidArmSpeed,Space.Self);
            }
        }

        ////////////////////////////////////////////////////////////////////

        // if(Input.GetButton("LeftTrigger"))
        // {
        //     ArmAngle = ArmAngle + .2f;
        //     transform.Rotate(0,0,-BaseArmSpeed,Space.Self);
        // }
    }
}

