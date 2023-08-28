using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class ClawRotate : MonoBehaviour
{
    private Gamepad gamepad;
    private float TurnSpeed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        gamepad = Gamepad.current;
    }

    // Update is called once per frame
    void Update()
    {
        if (gamepad != null && gamepad.rightShoulder.isPressed == true || Input.GetKey("r"))
        {
            transform.Rotate(0,TurnSpeed,0,Space.Self);
        }
        if (gamepad != null && gamepad.leftShoulder.isPressed == true || Input.GetKey("f"))
        {
            transform.Rotate(0,-TurnSpeed,0,Space.Self);
        }
    }
}
