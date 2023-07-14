using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Robot : MonoBehaviour
{
    

    public float DrivePower = 60f;
    public float TurnPower = 8f;
    public float torque = 100f;

    private float horInput;
    private float verInput;

    public Wheel[] DriveWheels;
    public Wheel[] TurnWheels;
    public bool Movelock = false;

    void Start(){}

    void Update() 
    {
        ProcessInput();
    }

    void FixedUpdate()
    {
        ProcessForces();
    }

    void ProcessInput()
    {
        verInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");
    }

    void ProcessForces()
    {
        foreach(Wheel w in DriveWheels)
        {   
            w.Accelerate(verInput * DrivePower);
            w.UpdatePosition();
        }

        foreach(Wheel w in TurnWheels)
        {   
            w.Accelerate(horInput * TurnPower);
            w.UpdatePosition();
        }
    }
}