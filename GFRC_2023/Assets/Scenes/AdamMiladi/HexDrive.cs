using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class HexDrive : MonoBehaviour
{
    private Gamepad gamepad;
    
    public float DrivePower = 65f;
    public float BreakPower = 25f;
    public float TurnPower = 20f;
    public float torque = 100f;

    private float horInput;
    private float verInput;

    public Rigidbody rb;
    public Vector3 locVel;

    public Wheel[] RWheels;
    public Wheel[] LWheels;

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
        if (gamepad != null && gamepad.yButton.isPressed == true || Input.GetKey(KeyCode.LeftShift)){
        foreach(Wheel w in RWheels)
        {
            w.Accelerate(verInput * 2 * DrivePower);
            w.UpdatePosition();
        }
        foreach(Wheel w in LWheels)
        {
            w.Accelerate(verInput * 2 * DrivePower);
            w.UpdatePosition();
        }}

        else{
        foreach(Wheel w in RWheels)
        {
            w.Accelerate((verInput - horInput) * DrivePower);
            w.UpdatePosition();
        }
        foreach(Wheel w in LWheels)
        {
            w.Accelerate((verInput + horInput) * DrivePower);
            w.UpdatePosition();
        }}

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