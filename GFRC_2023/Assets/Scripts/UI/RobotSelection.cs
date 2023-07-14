using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RobotSelection : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject DriveImages;
    public GameObject ManipulatorOneImages;
    public GameObject ManipulatorTwoImages;

    private GameObject CurrentImage;
    private Vector3 ImagePosition = new Vector3(438.1551513671875f, 75.92829895019531f, 0);
    private Vector3 LeftSideImagePos = new Vector3(-512.8449096679688f, 75.92829895019531f, 0);
    private Vector3 RightSideImagePos = new Vector3(1487.155029296875f, 75.92829895019531f, 0);
    private float animSpeed = 1.0f;

    void Start()
    {
        CurrentImage = DriveImages;
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
            CurrentImage.transform.position = RightSideImagePos;
            CurrentImage = ManipulatorTwoImages;

        });
        ManipulatorTwoImages.transform.DOMove(ImagePosition, animSpeed);


    }

}
