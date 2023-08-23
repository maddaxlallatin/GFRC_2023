using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.XInput;


public class GrabCube : MonoBehaviour
{
    private Gamepad gamepad;

    public bool Grab = false;
    public bool Full = false;
    public bool Checkother = false;
    public GrabCone ConeCheck;
    public ItemSpawner Deposit;

    void Start()
    {
        Deposit = FindObjectOfType<ItemSpawner>();
        gamepad = Gamepad.current; 
        // var Controller = XInputController.current;
    }

    void Pickup()
    {

        if (gamepad != null && gamepad.aButton.wasPressedThisFrame == true && Grab == false  ||Input.GetKeyDown("space") && Grab == false)
        {
            Grab = true;
        }

        else if (gamepad != null && gamepad.aButton.wasPressedThisFrame == true && Grab == true  ||Input.GetKeyDown("space") && Grab == true)
        {
            Grab = false;   
            Full = false;
        }
    }

    void Update()
    {
        Pickup();
    }

    void OnTriggerStay(Collider other)
    {   
        Checkother = ConeCheck.Full;
        if (other.gameObject.CompareTag("CubeCollect") && Full == false && Checkother == false && Grab == true)
        {
            other.tag = "CubeCollected";
            Full = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.transform.parent = gameObject.transform;
        }

        if (other.gameObject.CompareTag("CubeCollected") && Grab == true && Checkother == false)
        {               
            other.gameObject.transform.position = gameObject.transform.position;
            other.gameObject.transform.rotation = transform.rotation;
        }
        if (other.gameObject.CompareTag("CubeCollected") && Grab == false )
        {other.tag = "CubeCollect";

        Full = false;
        other.gameObject.transform.parent = Deposit.gameObject.transform;
        other.gameObject.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}