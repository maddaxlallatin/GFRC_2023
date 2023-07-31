using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class Robot : MonoBehaviour
{
    

    public float DrivePower = 70f;
    public float TurnPower = 8f;
    public float torque = 100f;

    private float horInput;
    private float verInput;

    public Wheel[] DriveWheels;
    public Wheel[] TurnWheels;

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
        //Vector3 force = new Vector3(0f, 0f, verInput * power);
        //rb.AddRelativeForce(force);

        //Vector3 rforce = new Vector3(0f, horInput* torque, 0f);
        //rb.AddRelativeTorque(rforce);

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