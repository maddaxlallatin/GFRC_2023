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
    public GameObject AIHub;

    // Start is called before the first frame update
    void Start()
    {
        if (isOrange == true)
        {
            Debug.Log("Orange");
        if (manipulator == "OrangeCubeChuckerUIVERSION(Clone)")
        {
            Player.transform.position = new Vector3(6.5f,.25f,.425f);
            Player.transform.Rotate(0, -90.0f, 0.0f, Space.Self);

            Instantiate(OAIHeavy, new Vector3(6.5f,.25f,-1.25f), Quaternion.Euler(0, 180, 0), AIHub.transform);
            Instantiate(OAIScout, new Vector3(1.5f,.25f,-5.5f), Quaternion.Euler(0, 180, 0), AIHub.transform);

            Instantiate(BAIHeavy, new Vector3(-6.5f,.25f,-1.25f), Quaternion.identity, AIHub.transform);
            Instantiate(BAISniper, new Vector3(-6.5f,.25f,.425f), Quaternion.Euler(0, 90, 0), AIHub.transform);
            Instantiate(BAIScout, new Vector3(-1.5f,.25f,-5.5f), Quaternion.Euler(0, 180, 0), AIHub.transform);            
        }
        else if (manipulator == "OrangeCircleClawUIVERSION(Clone)")
        {
            Player.transform.position = new Vector3(6.5f,.25f,-2.95f);
            Player.transform.Rotate(0, -90.0f, 0.0f, Space.Self);

            Instantiate(OAIHeavy, new Vector3(6.5f,.25f,-1.25f), Quaternion.Euler(0, 180, 0), AIHub.transform);
            Instantiate(OAISniper, new Vector3(6.5f,.25f,.425f), Quaternion.Euler(0, 270, 0), AIHub.transform);

            Instantiate(BAIHeavy, new Vector3(-6.5f,.25f,-1.25f), Quaternion.identity, AIHub.transform);
            Instantiate(BAISniper, new Vector3(-6.5f,.25f,.425f), Quaternion.Euler(0, 90, 0), AIHub.transform);
            Instantiate(BAIScout, new Vector3(-1.5f,.25f,-5.5f), Quaternion.Euler(0, 180, 0), AIHub.transform);
        }
        else
        {
            Player.transform.position = new Vector3(6.5f,.25f,-1.25f);
            Player.transform.Rotate(0, -90.0f, 0.0f, Space.Self);

            Instantiate(OAISniper, new Vector3(6.5f,.25f,.425f), Quaternion.Euler(0, 270, 0), AIHub.transform);
            Instantiate(OAIScout, new Vector3(1.5f,.25f,-5.5f), Quaternion.Euler(0, 180, 0), AIHub.transform);

            Instantiate(BAIHeavy, new Vector3(-6.5f,.25f,-1.25f), Quaternion.identity, AIHub.transform);
            Instantiate(BAISniper, new Vector3(-6.5f,.25f,.425f), Quaternion.Euler(0, 90, 0), AIHub.transform);
            Instantiate(BAIScout, new Vector3(-1.5f,.25f,-5.5f), Quaternion.Euler(0, 180, 0), AIHub.transform);
        }
        }
        else
        {
        if (manipulator == "BlueCubeChuckerUIVERSION(Clone)")
        {
            Player.transform.position = new Vector3(-6.5f,.25f,.425f);
            Player.transform.Rotate(0, 90.0f, 0.0f, Space.Self);

            Instantiate(BAIHeavy, new Vector3(-6.5f,.25f,-1.25f), Quaternion.identity, AIHub.transform);
            Instantiate(BAIScout, new Vector3(-1.5f,.25f,-5.5f), Quaternion.Euler(0, 180, 0), AIHub.transform);

            Instantiate(OAIHeavy, new Vector3(6.5f,.25f,-1.25f), Quaternion.Euler(0, 180, 0), AIHub.transform);
            Instantiate(OAISniper, new Vector3(6.5f,.25f,.425f), Quaternion.Euler(0, 270, 0), AIHub.transform);
            Instantiate(OAIScout, new Vector3(1.5f,.25f,-5.5f), Quaternion.Euler(0, 180, 0), AIHub.transform);
        }
        else if (manipulator == "BlueCircleClawUIVERSION(Clone)")
        {
            Player.transform.position = new Vector3(-6.5f,.25f,-2.95f);
            Player.transform.Rotate(0, 90.0f, 0.0f, Space.Self);

            Instantiate(BAIHeavy, new Vector3(-6.5f,.25f,-1.25f), Quaternion.identity, AIHub.transform);
            Instantiate(BAISniper, new Vector3(-6.5f,.25f,.425f), Quaternion.Euler(0, 90, 0), AIHub.transform);

            Instantiate(OAIHeavy, new Vector3(6.5f,.25f,-1.25f), Quaternion.Euler(0, 180, 0), AIHub.transform);
            Instantiate(OAISniper, new Vector3(6.5f,.25f,.425f), Quaternion.Euler(0, 270, 0), AIHub.transform);
            Instantiate(OAIScout, new Vector3(1.5f,.25f,-5.5f), Quaternion.Euler(0, 180, 0), AIHub.transform);
        }
        else
        {
            Player.transform.position = new Vector3(-6.5f,.25f,-1.25f);
            Player.transform.Rotate(0, 90.0f, 0.0f, Space.Self);

            Instantiate(BAISniper, new Vector3(-6.5f,.25f,.425f), Quaternion.Euler(0, 90, 0), AIHub.transform);
            Instantiate(BAIScout, new Vector3(-1.5f,.25f,-5.5f), Quaternion.Euler(0, 180, 0), AIHub.transform);

            Instantiate(OAIHeavy, new Vector3(6.5f,.25f,-1.25f), Quaternion.Euler(0, 180, 0), AIHub.transform);
            Instantiate(OAISniper, new Vector3(6.5f,.25f,.425f), Quaternion.Euler(0, 270, 0), AIHub.transform);
            Instantiate(OAIScout, new Vector3(1.5f,.25f,-5.5f), Quaternion.Euler(0, 180, 0), AIHub.transform);            
        }
        }

    }

    // Update is called once per frame
    void Update()
    {

    }
}
