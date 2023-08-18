using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;
public class RobotSpawner : MonoBehaviour
{

    public GameObject Claw;
    public GameObject ArmFiller;
    public GameObject CubeChuck;

    public GameObject OrangeOctBot;
    public GameObject BlueOctBot;
    public GameObject OrangeSquBot;
    public GameObject BlueSquBot;
    public GameObject OrangePentaBot;
    public GameObject BluePentaBot;

    public GameObject HDrive;

    public GameObject DriveTrain;
    public GameObject Module;
    public GameObject Chasis;
    char[] MyChar = { '(', 'C', 'l', 'o', 'n', 'e', ')' };


    private GameObject SpawnedChasis;
    private GameObject SpawnedDriveTrain;
    private GameObject SpawnedModule;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(chasis);
        Debug.Log(driveTrain);
        Debug.Log(manipulator);
        switch (manipulator.TrimEnd(MyChar))
        {
            case "BlueCircleClawUIVERSION":
                Module = Claw;
                break;
            case "BlueArmFillerUIVERSION":
                Module = ArmFiller;
                break;
            case "BlueCubeChuckerUIVERSION":
                Module = CubeChuck;
                break;
        }

        switch (driveTrain.TrimEnd(MyChar))
        {
            case "H+DriveUIVERSION":
                DriveTrain = HDrive;
                break;
        }

        switch (chasis.TrimEnd(MyChar))
        {
            case "BlueOctBotUIVERSION":
                Chasis = BlueOctBot;
                break;
            case "OrangeOctBotUIVERSION":
                Chasis = OrangeOctBot;
                break;
            case "BlueSquBotUIVERSION":
                Chasis = BlueSquBot;
                break;
            case "OrangeSquBotUIVERSION":
                Chasis = OrangeSquBot;
                break;
            case "BluePentBotUIVERSION":
                Chasis = BluePentaBot;
                break;
            case "OrangePentBotUIVERSION":
                Chasis = OrangePentaBot;
                break;
        }

        SpawnedChasis = Instantiate(Chasis, transform);


        SpawnedDriveTrain = Instantiate(DriveTrain, transform);
        SpawnedModule = Instantiate(Module, transform);
        if (Module == CubeChuck)
        {
            SpawnedModule.transform.localPosition = new Vector3(0, .21f, 0);
        }
        else
        {
            SpawnedModule.transform.localPosition = new Vector3(0, .03f, 0);
        }
    }


}
