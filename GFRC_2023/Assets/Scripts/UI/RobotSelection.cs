using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using static Global;
using UnityEngine.UI;
using Unity.Burst.Intrinsics;

public class RobotSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DriveImages;
    public GameObject ManipulatorOneImages;
    public GameObject ManipulatorTwoImages;
    public GameObject mainMenu, StartButton;
    private GameObject CurrentImage;



    public GameObject CurrentManipulator;
    private GameObject Claw;
    private GameObject ArmFiller;
    private GameObject CubeChuck;


    public GameObject BlueClaw;
    public GameObject BlueArmFiller;
    public GameObject BlueCubeChuck;
    public GameObject OrangeClaw;
    public GameObject OrangeArmFiller;
    public GameObject OrangeCubeChuck;


    private GameObject OctBot;
    private GameObject SquBot;
    private GameObject PentaBot;

    public GameObject CurrentBot;
    public GameObject OrangeOctBot;
    public GameObject BlueOctBot;
    public GameObject OrangeSquBot;
    public GameObject BlueSquBot;
    public GameObject OrangePentaBot;
    public GameObject BluePentaBot;

    public bool isOrange = false;

    public GameObject HDrive;
    public GameObject Module;
    public GameObject CurrentDrive;

    public GameObject spawnPoint;

    private Vector3 ImagePosition = new Vector3(540.6867065429688f, 79.61088562011719f, 0);
    private Vector3 LeftSideImagePos = new Vector3(-512.8449096679688f, 79.61088562011719f, 0);
    private Vector3 RightSideImagePos = new Vector3(1497.155029296875f, 79.61088562011719f, 0);
    private float animSpeed = 1.0f;
    void Start()
    {
        CurrentImage = DriveImages;
        CurrentManipulator = Instantiate(BlueArmFiller, spawnPoint.transform);
        CurrentDrive = Instantiate(HDrive, spawnPoint.transform);
        CurrentBot = Instantiate(BlueOctBot, spawnPoint.transform);

    }
    public void DriveImageSelected()
    {
        CurrentImage.transform.DOMove(LeftSideImagePos, animSpeed).OnComplete(() =>
        {
            CurrentImage.transform.position = RightSideImagePos;
            CurrentImage = DriveImages;
        });
        DriveImages.transform.DOMove(ImagePosition, animSpeed);



    }
    public void ManipulatorOneImageSelected()
    {
        CurrentImage.transform.DOMove(LeftSideImagePos, animSpeed).OnComplete(() =>
         {
             CurrentImage.transform.position = RightSideImagePos;
             CurrentImage = ManipulatorOneImages;
         });
        ManipulatorOneImages.transform.DOMove(ImagePosition, animSpeed);


    }
    public void ManipulatorTwoImageSelected()
    {
        CurrentImage.transform.DOMove(LeftSideImagePos, animSpeed).OnComplete(() =>
        {
            CurrentImage.transform.position = RightSideImagePos; CurrentImage = ManipulatorTwoImages;

        });
        ManipulatorTwoImages.transform.DOMove(ImagePosition, animSpeed);


    }

    public void CloseRobotSelection()
    {
        gameObject.SetActive(false);
        mainMenu.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(StartButton);
    }

    public void ArmFillerSelect()
    {
        if (isOrange)
        {
            ArmFiller = OrangeArmFiller;
        }
        else
        {
            ArmFiller = BlueArmFiller;
        }
        Destroy(CurrentManipulator);
        CurrentManipulator = Instantiate(ArmFiller, spawnPoint.transform);
        CurrentManipulator.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void ClawSelect()
    {
        if (isOrange)
        {
            Claw = OrangeClaw;
        }
        else
        {
            Claw = BlueClaw;
        }
        Destroy(CurrentManipulator);
        CurrentManipulator = Instantiate(Claw, spawnPoint.transform);
        CurrentManipulator.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void CubeChuckSelect()
    {
        if (isOrange)
        {
            CubeChuck = OrangeCubeChuck;
        }
        else
        {
            CubeChuck = BlueCubeChuck;
        }
        Destroy(CurrentManipulator);
        CurrentManipulator = Instantiate(CubeChuck, spawnPoint.transform);
        CurrentManipulator.transform.localPosition = new Vector3(0, .20f, 0);
    }


    public void HDriveSelect()
    {
        Destroy(CurrentDrive);
        CurrentDrive = Instantiate(HDrive, spawnPoint.transform);
        CurrentDrive.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void OctBotSelect()
    {
        if (isOrange)
        {
            OctBot = OrangeOctBot;
        }
        else
        {
            OctBot = BlueOctBot;
        }


        Destroy(CurrentBot);
        CurrentBot = Instantiate(OctBot, spawnPoint.transform);
        CurrentBot.transform.localPosition = new Vector3(0, 0, 0);
    }


    public void SquBotSelect()
    {
        if (isOrange)
        {
            SquBot = OrangeSquBot;
        }
        else
        {
            SquBot = BlueSquBot;
        }
        Destroy(CurrentBot);
        CurrentBot = Instantiate(SquBot, spawnPoint.transform);
        CurrentBot.transform.localPosition = new Vector3(0, 0, 0);
    }

    public void PentaBotSelect()
    {
        if (isOrange)
        {
            PentaBot = OrangePentaBot;
        }
        else
        {
            PentaBot = BluePentaBot;
        }
        Destroy(CurrentBot);
        CurrentBot = Instantiate(PentaBot, spawnPoint.transform);
        CurrentBot.transform.localPosition = new Vector3(0, 0, 0);
    }
    public void StartGame()
    {
        chasis = CurrentBot.gameObject.name;
        manipulator = CurrentManipulator.gameObject.name;
        driveTrain = CurrentDrive.gameObject.name;

        Debug.Log(chasis);
        Debug.Log(manipulator);
        Debug.Log(driveTrain);
        UnityEngine.SceneManagement.SceneManager.LoadScene("AdamMiladi");
    }



    public void ToggleColor()
    {
        isOrange = !isOrange;
        if (isOrange)
        {
            Destroy(CurrentManipulator);
            
            Instantiate(Resources.Load(CurrentManipulator.gameObject.name.Replace("Blue", "Orange").Replace("(Clone)", "")), spawnPoint.transform);
            CurrentManipulator = GameObject.Find(CurrentManipulator.gameObject.name.Replace("Blue", "Orange"));
            Destroy(CurrentBot);
            Instantiate(Resources.Load(CurrentBot.gameObject.name.Replace("Blue", "Orange").Replace("(Clone)", "")), spawnPoint.transform);
            CurrentBot = GameObject.Find(CurrentBot.gameObject.name.Replace("Blue", "Orange"));
            if(CurrentManipulator == GameObject.Find("OrangeCubeChuckerUIVERSION(Clone)") || CurrentManipulator == GameObject.Find("BlueCubeChuckerUIVERSION(Clone)")){
                        CurrentManipulator.transform.localPosition = new Vector3(0, .20f, 0);

            }
        }
        else
        {
            Destroy(CurrentManipulator);
            Instantiate(Resources.Load(CurrentManipulator.gameObject.name.Replace("Orange", "Blue").Replace("(Clone)", "")), spawnPoint.transform);
            CurrentManipulator = GameObject.Find(CurrentManipulator.gameObject.name.Replace("Orange", "Blue"));
            Destroy(CurrentBot);
            Instantiate(Resources.Load(CurrentBot.gameObject.name.Replace("Orange", "Blue").Replace("(Clone)", "")), spawnPoint.transform);
            CurrentBot = GameObject.Find(CurrentBot.gameObject.name.Replace("Orange", "Blue"));
            if(CurrentManipulator == GameObject.Find("OrangeCubeChuckerUIVERSION(Clone)") || CurrentManipulator == GameObject.Find("BlueCubeChuckerUIVERSION(Clone)")){
                        CurrentManipulator.transform.localPosition = new Vector3(0, .20f, 0);

            }
        }

    }



























}
