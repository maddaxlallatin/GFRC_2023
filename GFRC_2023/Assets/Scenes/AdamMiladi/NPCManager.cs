using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;

public class NPCManager : MonoBehaviour
{
    public GameObject OAIScout;
    public GameObject OAIHeavy;
    public GameObject OAISniper;
    public GameObject BAIScout;
    public GameObject BAIHeavy;
    public GameObject BAISniper;
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        if (isOrange == true)
        {
            Debug.Log("Orange");
        if (manipulator == "OrangeCubeChuckerUIVERSION(Clone)")
        {
            Player.transform.position = new Vector3(6f,.25f,.425f);
            Player.transform.Rotate(0, -90.0f, 0.0f, Space.Self);
        }
        else if (manipulator == "OrangeCircleClawUIVERSION(Clone)")
        {
            Player.transform.position = new Vector3(6f,.25f,-2.95f);
            Player.transform.Rotate(0, -90.0f, 0.0f, Space.Self);
        }
        else
        {
            Player.transform.position = new Vector3(6f,.25f,-1.25f);
            Player.transform.Rotate(0, -90.0f, 0.0f, Space.Self);
        }
        }
        else
        {
            Debug.Log("Blue");
            if (manipulator == "BlueCubeChuckerUIVERSION(Clone)")
        {
            Player.transform.position = new Vector3(-6f,.25f,.425f);
            Player.transform.Rotate(0, 90.0f, 0.0f, Space.Self);
        }
        else if (manipulator == "BlueCircleClawUIVERSION(Clone)")
        {
            Player.transform.position = new Vector3(-6f,.25f,-2.95f);
            Player.transform.Rotate(0, 90.0f, 0.0f, Space.Self);
        }
        else
        {
            Player.transform.position = new Vector3(-6f,.25f,-1.25f);
            Player.transform.Rotate(0, 90.0f, 0.0f, Space.Self);
        }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
