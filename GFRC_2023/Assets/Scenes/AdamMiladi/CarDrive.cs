using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;


public class CarDrive : MonoBehaviour
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

    public TurnWheel TR;
    public TurnWheel TL;
    public Wheel BL;
    public Wheel BR;

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
        TL.Accelerate(verInput * DrivePower * 1.5f);
        TL.UpdatePosition();
        TL.Steer(horInput);
        TR.Accelerate(verInput * DrivePower * 1.5f);
        TR.UpdatePosition();
        TR.Steer(horInput);
        BL.Accelerate(verInput * DrivePower);
        BL.UpdatePosition();
        BR.Accelerate(verInput * DrivePower);
        BR.UpdatePosition();

    }

    void ProcessInput()
    {
    if (gamepad != null && gamepad.leftStick.ReadValue().y != 0)
    {
    verInput = gamepad.leftStick.ReadValue().y;
    }
    else if (gamepad==null){verInput = Input.GetAxis("Vertical");}

    if (gamepad != null && gamepad.leftStick.ReadValue().x != 0)
    {
    horInput = gamepad.leftStick.ReadValue().x;
    }
    else if (gamepad==null){horInput = Input.GetAxis("Horizontal");}
    }
}