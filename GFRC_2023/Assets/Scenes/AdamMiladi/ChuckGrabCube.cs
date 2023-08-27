using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class ChuckGrabCube : MonoBehaviour
{
    private Gamepad gamepad;
    public bool Grab = false;
    public bool Full = false;
    public CubeChuck CubeCheck;
    public float ArmAngle;
    public float Power = 0f;
    public bool PCharge = true;
    public bool SlingShot = false;
    public bool Reset = false;


    void Start()
    {
        gamepad = Gamepad.current;
    }

    void Pickup()
    {
        if (gamepad != null && gamepad.aButton.wasPressedThisFrame == true && Grab == false && Grab == false)
        {
            Grab = true;
        }
        
        else if (gamepad != null && gamepad.aButton.wasPressedThisFrame == true && Grab == false && Grab == true)
        {
            Grab = false;
            Full = false;
        }
        if (gamepad != null && gamepad.aButton.isPressed == true && Full == true && PCharge == true  && Full == true && PCharge == true)
        {
            Power = Power + .1f;
            if (Power > 20){PCharge = false;}
        }
        if (gamepad != null && gamepad.aButton.isPressed == true && Full == true && PCharge == false  && Full == true && PCharge == false)
        {
            Power = Power - .1f;
            if (Power < .01){PCharge = true;}
        }   
    }

    void Update()
    {
        Pickup();
    }

    void OnTriggerStay(Collider other)
    {   
        ArmAngle = CubeCheck.ArmAngle;
        if (other.gameObject.CompareTag("CubeCollect") && Full == false && Grab == true && ArmAngle == 180)
        {
            other.tag = "CubeCollected";
            Full = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.transform.parent = gameObject.transform;
        }

        if (other.gameObject.CompareTag("CubeCollected") && Grab == true)
        {               
            other.gameObject.transform.localPosition = new Vector3(0,0,0);
            other.gameObject.transform.rotation = transform.rotation;
            if (Input.GetKey("space") && ArmAngle == 0) 
            {
              SlingShot = true;  
            }
        }
        if (other.gameObject.CompareTag("CubeCollected") && Grab == false)
        {
            other.tag = "CubeCollect";
            Full = false;
            other.gameObject.transform.parent = null;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            if (ArmAngle == 0) 
            {
                other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(-.5f*Power, 0, -0f*Power, ForceMode.Impulse);
                Power = 0;
            }
            SlingShot = false;
            Reset = true;
        }

        
    }
    void OnTriggerExit(Collider other){Reset = false;}
}