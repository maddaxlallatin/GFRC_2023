using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;
public class RobotSpawner : MonoBehaviour
{

    public GameObject BlueClaw;
    public GameObject BlueArmFiller;
    public GameObject BlueCubeChuck;
    public GameObject OrangeClaw;
    public GameObject OrangeArmFiller;
    public GameObject OrangeCubeChuck;


    public GameObject OrangeOctBot;
    public GameObject BlueOctBot;
    public GameObject OrangeSquBot;
    public GameObject BlueSquBot;
    public GameObject OrangePentaBot;
    public GameObject BluePentaBot;

    public GameObject HDrive;
    public GameObject THexDrive;
    public GameObject CarDrive;

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
                Module = BlueClaw;
                break;
            case "BlueArmFillerUIVERSION":
                Module = BlueArmFiller;
                break;
            case "BlueCubeChuckerUIVERSION":
                Module = BlueCubeChuck;
                break;
                case "OrangeCircleClawUIVERSION":
                Module = OrangeClaw;
                break;
            case "OrangeArmFillerUIVERSION":
                Module = OrangeArmFiller;
                break;
            case "OrangeCubeChuckerUIVERSION":
                Module = OrangeCubeChuck;
                break;
        }

        switch (driveTrain.TrimEnd(MyChar))
        {
            case "H+DriveUIVERSION":
                DriveTrain = HDrive;
                break;
            case "HexTankDriveUIVERSION":
                DriveTrain = THexDrive;
                break;
            case "CarDriveUIVERSION":
                DriveTrain = CarDrive;
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
        if (Module == BlueCubeChuck || Module == OrangeCubeChuck)
        {
            SpawnedModule.transform.localPosition = new Vector3(0, .21f, 0);
            SpawnedModule.transform.localRotation = Quaternion.Euler(0,180,0);
        }
        else
        {
            SpawnedModule.transform.localPosition = new Vector3(0, .03f, 0);
            SpawnedModule.transform.localRotation = Quaternion.Euler(0,180,0);
        }
    }


}
