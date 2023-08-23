using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraCycle : MonoBehaviour
{

    public List<Camera> compcams;

    public int currentcam = 0;

    public Camera robocam;
    //public Camera maincam;
    void Start()
    {
        robocam = (FindObjectOfType<RobotCamera>().gameObject.GetComponent<Camera>());
       // maincam = (FindObjectOfType<ThirdPersonCam>().gameObject.GetComponent<Camera>());
        SwitchToCamera(0);
        compcams.Add(robocam);
      //  compcams.Add(maincam);
    }

    void SwitchToCamera(int camIndex)
    {
        for(int i = 0; i < compcams.Count; i++)
        {
            compcams[i].gameObject.SetActive(false);
        }

        compcams[camIndex].gameObject.SetActive(true);
    }

    void OnFire()
    {
        if(currentcam +1 < compcams.Count)
        {
            currentcam = currentcam + 1;
        }
        else
        {
            currentcam = 0;
        }
        SwitchToCamera(currentcam);
    }
}
