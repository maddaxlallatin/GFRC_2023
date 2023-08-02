using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.XInput;
using UnityEngine.EventSystems;

public class HighLightExitButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var Controller = XInputController.current;
        if (Controller == null)
            return; // No gamepad connected.
        if (Controller.selectButton.wasPressedThisFrame)
        {
            Debug.Log("Select Button Pressed");

            if (GameObject.Find("ExitButton"))
            {
                EventSystem.current.SetSelectedGameObject(null);
                EventSystem.current.SetSelectedGameObject(GameObject.Find("ExitButton"));
            }
        }
    }
}
