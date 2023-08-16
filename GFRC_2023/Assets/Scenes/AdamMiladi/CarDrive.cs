using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDrive : MonoBehaviour
{
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

    void Start(){rb = GetComponentInParent<Rigidbody>();}

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
        verInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");
    }
}