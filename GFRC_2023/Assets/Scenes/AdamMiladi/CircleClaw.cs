using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class CircleClaw : MonoBehaviour
{
    private Gamepad gamepad;
    public float GrabAngle = 0;
    public float GrabLength = 0;
    public float ArmAngle = 0;
    public float BaseArmSpeed;
    public float GrabASpeed;
    public float MidArmSpeed;
    public GameObject TopArm;
    public GameObject MidArm;
    public bool Movelock = false;

    void Start()
    {
        gamepad = Gamepad.current;
    }

    void Update()
    {
        if (gamepad != null && gamepad.leftTrigger.isPressed == true && Movelock == false || Input.GetKey("e") && Movelock == false)
        {
            if (ArmAngle < 220)
            {
                ArmAngle = ArmAngle + 1f;
                transform.Rotate(0,-5f*BaseArmSpeed,0,Space.Self);
                MidArm.transform.Rotate(0,0,5f*MidArmSpeed,Space.Self);
            } 
        }
        if (gamepad != null && gamepad.rightTrigger.isPressed == true || Input.GetKey("q"))
        {
            if (ArmAngle > 0)
            {
                ArmAngle = ArmAngle - 1f;
                transform.Rotate(0,5f*BaseArmSpeed,0,Space.Self);
                MidArm.transform.Rotate(0,0,-5f*MidArmSpeed,Space.Self);
            }
        }
    }
}
