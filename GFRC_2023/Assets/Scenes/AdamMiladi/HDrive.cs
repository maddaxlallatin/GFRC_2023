using System.Collections;
using System.Collections.Generic;
using UnityEngine; 

public class HDrive : MonoBehaviour
{
    

    public float DrivePower = 65f;
    public float BreakPower = 25f;
    public float TurnPower = 20f;
    public float torque = 100f;

    private float horInput;
    private float verInput;

    public Rigidbody rb;
    public Vector3 locVel;

    public Wheel UW;
    public Wheel BW;
    public Wheel LW;
    public Wheel RW;

    void Start(){rb = GetComponentInParent<Rigidbody>();}

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
        if (Input.GetKey(KeyCode.LeftShift)){
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

        if (Input.GetKey("d") == false && locVel.x > 1)
        {
            UW.Accelerate(-locVel.x * BreakPower);
            UW.UpdatePosition();
            BW.Accelerate(-locVel.x * 1.0f * -BreakPower);
            BW.UpdatePosition();
        }
            if (Input.GetKey("a") == false && locVel.x < -1)
        {
            UW.Accelerate(-locVel.x * BreakPower);
            UW.UpdatePosition();
            BW.Accelerate(-locVel.x * 1.0f * -BreakPower);
            BW.UpdatePosition();
        }
        if (Input.GetKey("w") == false && locVel.z > 1)
        {
            LW.Accelerate(-locVel.z * BreakPower);
            LW.UpdatePosition();
            RW.Accelerate(-locVel.z * BreakPower);
            RW.UpdatePosition();
        }
        if (Input.GetKey("s") == false && locVel.z < -1)
        {
            LW.Accelerate(-locVel.z * BreakPower);
            LW.UpdatePosition();
            RW.Accelerate(-locVel.z * BreakPower);
            RW.UpdatePosition();
        }
    }
        

    void ProcessInput()
    {
        verInput = Input.GetAxis("Vertical");
        horInput = Input.GetAxis("Horizontal");
    }

}