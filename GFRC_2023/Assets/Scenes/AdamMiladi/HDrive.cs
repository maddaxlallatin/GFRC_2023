using System.Collections;
using System.Collections.Generic;
using UnityEngine; 
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class HDrive : MonoBehaviour
{
    private Gamepad gamepad;

    public float DrivePower = 65f;
    public float BreakPower = 25f;
    public float TurnPower = 20f;
    public float torque = 100f;

    private float horInput = 0;
    private float verInput = 0;

    public Rigidbody rb;
    public Vector3 locVel;

    public Wheel UW;
    public Wheel BW;
    public Wheel LW;
    public Wheel RW;

    void Start()
    {
        rb = GetComponentInParent<Rigidbody>();
        gamepad = Gamepad.current;        
    }

    void Update() 
    {
        ProcessInput();
    }

    void FixedUpdate()
    {
        LW.Accelerate(verInput * DrivePower);
        LW.UpdatePosition();
        RW.Accelerate(verInput * DrivePower);
        RW.UpdatePosition();
        if (gamepad != null && gamepad.yButton.isPressed == true || Input.GetKey(KeyCode.LeftShift)){
            UW.Accelerate(horInput * DrivePower);
            UW.UpdatePosition();
            BW.Accelerate(horInput * -DrivePower);
            BW.UpdatePosition();}
        else {
            UW.Accelerate(horInput * TurnPower);
            UW.UpdatePosition();
            BW.Accelerate(horInput * TurnPower);
            BW.UpdatePosition();}

        locVel = transform.InverseTransformDirection(rb.velocity);

    //break system
        if (horInput == 0  && locVel.x > 1)
        {
            UW.Accelerate(-locVel.x * BreakPower);
            UW.UpdatePosition();
            BW.Accelerate(-locVel.x * 1.0f * -BreakPower);
            BW.UpdatePosition();
        }
            if (horInput == 0 && locVel.x < -1)
        {
            UW.Accelerate(-locVel.x * BreakPower);
            UW.UpdatePosition();
            BW.Accelerate(-locVel.x * 1.0f * -BreakPower);
            BW.UpdatePosition();
        }
        if (verInput == 0 && locVel.z > 1)
        {
            LW.Accelerate(-locVel.z * BreakPower);
            LW.UpdatePosition();
            RW.Accelerate(-locVel.z * BreakPower);
            RW.UpdatePosition();
        }
        if (verInput == 0 && locVel.z < -1)
        {
            LW.Accelerate(-locVel.z * BreakPower);
            LW.UpdatePosition();
            RW.Accelerate(-locVel.z * BreakPower);
            RW.UpdatePosition();
        }
    }
        

    void ProcessInput()
    {
    if (gamepad != null && gamepad.leftStick.ReadValue().y != 0)
    {
    verInput = gamepad.leftStick.ReadValue().y;
    }
    else{verInput = Input.GetAxis("Vertical");}

    if (gamepad != null && gamepad.leftStick.ReadValue().x != 0)
    {
    horInput = gamepad.leftStick.ReadValue().x;
    }
    else{horInput = Input.GetAxis("Horizontal");}

    }

}