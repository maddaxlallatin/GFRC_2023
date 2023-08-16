using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexDrive : MonoBehaviour
{
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

    void Start(){rb = GetComponentInParent<Rigidbody>();}

    void Update() 
    {
        ProcessInput();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift)){
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
        verInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");
    }
}