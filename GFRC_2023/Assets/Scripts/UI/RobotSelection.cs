using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.EventSystems;
using static Global;
public class RobotSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DriveImages;
    public GameObject ManipulatorOneImages;
    public GameObject ManipulatorTwoImages;
    public GameObject mainMenu, StartButton;
    private GameObject CurrentImage;



    public GameObject CurrentManipulator;
    public GameObject Claw;
    public GameObject ArmFiller;
    public GameObject CubeChuck;

    public GameObject CurrentBot;
    public GameObject OrangeOctBot;
    public GameObject BlueOctBot;
    public GameObject OrangeSquBot;
    public GameObject BlueSquBot;



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
        CurrentManipulator = Instantiate(ArmFiller, spawnPoint.transform);
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

    public void ArmFillerSelect(){
        Destroy(CurrentManipulator);
        CurrentManipulator = Instantiate(ArmFiller, spawnPoint.transform);
        CurrentManipulator.transform.localPosition = new Vector3(0,0,0);
    }

    public void ClawSelect(){
        Destroy(CurrentManipulator);
        CurrentManipulator = Instantiate(Claw, spawnPoint.transform);
        CurrentManipulator.transform.localPosition = new Vector3(0,0,0);
    }

    public void CubeChuckSelect(){
        Destroy(CurrentManipulator);
        CurrentManipulator = Instantiate(CubeChuck, spawnPoint.transform);
        CurrentManipulator.transform.localPosition = new Vector3(0,.20f,0);
    }


    public void HDriveSelect(){
        Destroy(CurrentDrive);
        CurrentDrive = Instantiate(HDrive, spawnPoint.transform);
        CurrentDrive.transform.localPosition = new Vector3(0,0,0);
    }

    public void BlueOctBotSelect(){
        Destroy(CurrentBot);
        CurrentBot = Instantiate(BlueOctBot, spawnPoint.transform);
        CurrentBot.transform.localPosition = new Vector3(0,0,0);
    }

    public void OrangeOctBotSelect(){
        Destroy(CurrentBot);
        CurrentBot = Instantiate(OrangeOctBot, spawnPoint.transform);
        CurrentBot.transform.localPosition = new Vector3(0,0,0);
    }

    public void BlueSquBotSelect(){
        Destroy(CurrentBot);
        CurrentBot = Instantiate(BlueSquBot, spawnPoint.transform);
        CurrentBot.transform.localPosition = new Vector3(0,0,0);
    }

    public void OrangeSquBotSelect(){
        Destroy(CurrentBot);
        CurrentBot = Instantiate(OrangeSquBot, spawnPoint.transform);
        CurrentBot.transform.localPosition = new Vector3(0,0,0);
    }
































}
