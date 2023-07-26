using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleClaw : MonoBehaviour
{

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
        
    }

    void Update()
    {
        if (Input.GetKey("e") && Movelock == false)
        {
            if (ArmAngle < 220)
            {
                ArmAngle = ArmAngle + .2f;
                transform.Rotate(0,-BaseArmSpeed,0,Space.Self);
                MidArm.transform.Rotate(0,0,MidArmSpeed,Space.Self);
            } 
        }
        if (Input.GetKey("q"))
        {
            if (ArmAngle > 0)
            {
                ArmAngle = ArmAngle - .2f;
                transform.Rotate(0,BaseArmSpeed,0,Space.Self);
                MidArm.transform.Rotate(0,0,-MidArmSpeed,Space.Self);
            }
        }
    }
}
