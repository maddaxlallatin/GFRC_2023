using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour
{
    public bool powered = false;
    public float offset = 0f;

    private WheelCollider wcol;
    private Transform wmesh;

    private void Start()
    {
        wcol = GetComponentInChildren<WheelCollider>();
        wmesh = transform.Find("mesh_Wheel");
        wcol.steerAngle = offset;
    }



    public void Accelerate(float powerInput)
    {
        if(powered) wcol.motorTorque = powerInput;
        else wcol.brakeTorque = 0;
    }

    public void UpdatePosition()
    {
        Vector3 pos = transform.position;
        Quaternion rot = transform.rotation;

        wcol.GetWorldPose(out pos, out rot);
        wmesh.transform.position = pos;
        wmesh.transform.rotation = rot;
    }
}
