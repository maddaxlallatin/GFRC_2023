using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;

public class ScoringManager : MonoBehaviour
{
    // Start is called before the first frame update
#pragma warning disable IDE0051


    void Start()
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int redaCount, redbCount, redcCount;
    private int blueaCount, bluebCount, bluecCount;

    private int redALinks, redBLinks, redCLinks;
    private int blueALinks, blueBLinks, blueCLinks;
    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag == "CubeCollect" || other.gameObject.tag == "ConeCollect")
        {
            if(isOrange && gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.name != "Red Side") return;
            if(!isOrange && gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.name != "Blue Side") return;

            Debug.Log(gameObject.transform.parent.gameObject.name);
            switch (gameObject.transform.parent.gameObject.name)
            {
                case "Level 1":
                    AddPoints(2);
                    break;
                case "Level 2":
                    if(other.gameObject.tag == "ConeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cones") return;
                    if(other.gameObject.tag == "CubeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cubes") return;
                    AddPoints(3);
                    break;
                case "Level 3":
                if(other.gameObject.tag == "ConeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cones") return;
                    if(other.gameObject.tag == "CubeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cubes") return;
                    AddPoints(5);
                    break;
            }
            Debug.Log(points);


            switch (gameObject.name.Substring(0, 4))
            {
                case "reda":
                    redaRowArray[gameObject.name[4] - '1'] = true;
                    foreach (bool b in redaRowArray)
                    {
                        Debug.Log(b);
                        if (!b)
                        {
                            redaCount = 0;
                        }
                        else
                        {
                            redaCount++;
                        }
                        if (redaCount % 3 == 0 && redaCount != 0)
                        {
                            Debug.Log("3 In A Row " + redaCount / 3 + " Times");
                            redALinks = redaCount / 3;
                            redlinks = redALinks + redBLinks + redCLinks;
                            points = points + ((redlinks + bluelinks )* 5); 
                        }
                    }
                    break;

                case "redb":
                if(other.gameObject.tag == "ConeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cones") return;
                    if(other.gameObject.tag == "CubeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cubes") return;
                    redbRowArray[gameObject.name[4] - '1'] = true;
                    foreach (bool b in redbRowArray)
                    {
                        Debug.Log(b);
                        if (!b)
                        {
                            redbCount = 0;
                        }
                        else
                        {
                            redbCount++;
                        }
                        if (redbCount % 3 == 0 && redbCount != 0)
                        {
                            Debug.Log("3 In B Row " + redbCount / 3 + " Times");
                            redBLinks = redbCount / 3;
                            redlinks = redALinks + redBLinks + redCLinks;
                            points = points + ((redlinks + bluelinks )* 5);

                        }
                    }
                    break;


                case "redc":
                    redcRowArray[gameObject.name[4] - '1'] = true;
                    foreach (bool b in redcRowArray)
                    {
                        Debug.Log(b);
                        if (!b)
                        {
                            redcCount = 0;
                        }
                        else
                        {
                            redcCount++;
                        }
                        if (redcCount % 3 == 0 && redcCount != 0)
                        {
                            Debug.Log("3 In C Row " + redcCount / 3 + " Times");
                            redCLinks = redcCount / 3;
                            redlinks = redALinks + redBLinks + redCLinks;
                            points = points + ((redlinks + bluelinks )* 5);

                        }
                    }
                    break;
            }








switch (gameObject.name.Substring(0, 5))
            {
                case "bluea":
                    blueaRowArray[gameObject.name[5] - '1'] = true;
                    foreach (bool b in blueaRowArray)
                    {
                        Debug.Log(b);
                        if (!b)
                        {
                            blueaCount = 0;
                        }
                        else
                        {
                            blueaCount++;
                        }
                        if (blueaCount % 3 == 0 && blueaCount != 0)
                        {
                            Debug.Log("3 In A Row " + blueaCount / 3 + " Times");
                            blueALinks = blueaCount / 3;
                            bluelinks = blueALinks + blueBLinks + blueCLinks;
                            points = points + ((redlinks + bluelinks )* 5);
                        }
                    }
                    break;

                case "blueb":
                if(other.gameObject.tag == "ConeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cones") return;
                    if(other.gameObject.tag == "CubeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cubes") return;
                    bluebRowArray[gameObject.name[5] - '1'] = true;
                    foreach (bool b in bluebRowArray)
                    {
                        Debug.Log(b);
                        if (!b)
                        {
                            bluebCount = 0;
                        }
                        else
                        {
                            bluebCount++;
                        }
                        if (bluebCount % 3 == 0 && bluebCount != 0)
                        {
                            Debug.Log("3 In B Row " + bluebCount / 3 + " Times");
                            blueBLinks = bluebCount / 3;
                            bluelinks = blueALinks + blueBLinks + blueCLinks;
                            points = points + ((redlinks + bluelinks )* 5);

                        }
                    }
                    break;


                case "bluec":
                    bluecRowArray[gameObject.name[5] - '1'] = true;
                    foreach (bool b in bluecRowArray)
                    {
                        Debug.Log(b);
                        if (!b)
                        {
                            bluecCount = 0;
                        }
                        else
                        {
                            bluecCount++;
                        }
                        if (bluecCount % 3 == 0 && bluecCount != 0)
                        {
                            Debug.Log("3 In C Row " + bluecCount / 3 + " Times");
                            blueCLinks = bluecCount / 3;
                            bluelinks = blueALinks + blueBLinks + blueCLinks;
                            points = points + ((redlinks + bluelinks )* 5);

                        }
                    }
                    break;
            }
            Debug.Log("Red Links: " + redlinks);
            Debug.Log("Blue Links: " + bluelinks);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Collision");
        if (other.gameObject.tag == "CubeCollect" || other.gameObject.tag == "ConeCollect")
        {
            if(isOrange && gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.name != "Red Side") return;
            if(!isOrange && gameObject.transform.parent.gameObject.transform.parent.gameObject.transform.parent.name != "Blue Side") return;

            Debug.Log(gameObject.transform.parent.gameObject.name);
            switch (gameObject.transform.parent.gameObject.name)
            {
                case "Level 1":
                    RemovePoints(2);
                    break;
                case "Level 2":
                if(other.gameObject.tag == "ConeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cones") return;
                    if(other.gameObject.tag == "CubeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cubes") return;
                    RemovePoints(3);
                    break;
                case "Level 3":
                if(other.gameObject.tag == "ConeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cones") return;
                    if(other.gameObject.tag == "CubeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cubes") return;
                    RemovePoints(5);
                    break;
            }
            Debug.Log(points);


            switch (gameObject.name.Substring(0, 4))
            {
                case "reda":
                    redaRowArray[gameObject.name[4] - '1'] = false;
                    redlinks = 0;
                    foreach (bool b in redaRowArray)
                    {
                        Debug.Log(b);
                        if (!b)
                        {
                            redaCount = 0;
                        }
                        else
                        {
                            redaCount++;
                        }
                        if (redaCount % 3 != 0 && redaCount != 0)
                        {
                            Debug.Log("3 In A Row " + redaCount / 3 + " Times");
                            redALinks = redaCount / 3;
                            redlinks = redALinks + redBLinks + redCLinks;
                            points = points + ((redlinks + bluelinks )* 5);
                        }
                    }
                    break;

                case "redb":
                if(other.gameObject.tag == "ConeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cones") return;
                    if(other.gameObject.tag == "CubeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cubes") return;
                    redlinks = 0;

                    redbRowArray[gameObject.name[4] - '1'] = false;
                    foreach (bool b in redbRowArray)
                    {
                        Debug.Log(b);
                        if (!b)
                        {
                            redbCount = 0;
                        }
                        else
                        {
                            redbCount++;
                        }
                        if (redbCount % 3 == 0 && redbCount != 0)
                        {
                            Debug.Log("3 In B Row " + redbCount / 3 + " Times");
                            redBLinks = redbCount / 3;
                            redlinks = redALinks + redBLinks + redCLinks;
                            points = points + ((redlinks + bluelinks )* 5);

                        }
                    }
                    break;


                case "redc":
                if(other.gameObject.tag == "ConeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cones") return;
                    if(other.gameObject.tag == "CubeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cubes") return;
                    redlinks = 0;

                    redcRowArray[gameObject.name[4] - '1'] = false;
                    foreach (bool b in redcRowArray)
                    {
                        Debug.Log(b);
                        if (!b)
                        {
                            redcCount = 0;
                        }
                        else
                        {
                            redcCount++;
                        }
                        if (redcCount % 3 == 0 && redcCount != 0)
                        {
                            Debug.Log("3 In C Row " + redcCount / 3 + " Times");
                            redCLinks = redcCount / 3;
                            redlinks = redALinks + redBLinks + redCLinks;
                            points = points + ((redlinks + bluelinks )* 5);

                        }
                    }
                    break;


            }
            switch (gameObject.name.Substring(0, 5))
            {







                case "bluea":
                    bluelinks = 0;
                    blueaRowArray[gameObject.name[5] - '1'] = false;
                    foreach (bool b in blueaRowArray)
                    {
                        Debug.Log(b);
                        if (!b)
                        {
                            blueaCount = 0;
                        }
                        else
                        {
                            blueaCount++;
                        }
                        if (blueaCount % 3 == 0 && blueaCount != 0)
                        {
                            Debug.Log("3 In A Row " + blueaCount / 3 + " Times");
                            blueALinks = blueaCount / 3;
                            bluelinks = blueALinks + blueBLinks + blueCLinks;
                            points = points + ((redlinks + bluelinks )* 5);
                        }
                    }
                    break;

                case "blueb":
                if(other.gameObject.tag == "ConeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cones") return;
                    if(other.gameObject.tag == "CubeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cubes") return;
                    bluelinks = 0;
                    bluebRowArray[gameObject.name[5] - '1'] = false;
                    foreach (bool b in bluebRowArray)
                    {
                        Debug.Log(b);
                        if (!b)
                        {
                            bluebCount = 0;
                        }
                        else
                        {
                            bluebCount++;
                        }
                        if (bluebCount % 3 == 0 && bluebCount != 0)
                        {
                            Debug.Log("3 In B Row " + bluebCount / 3 + " Times");
                            blueBLinks = bluebCount / 3;
                            bluelinks = blueALinks + blueBLinks + blueCLinks;
                            points = points + ((redlinks + bluelinks )* 5);

                        }
                    }
                    break;


                case "bluec":
                if(other.gameObject.tag == "ConeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cones") return;
                    if(other.gameObject.tag == "CubeCollect" && gameObject.transform.parent.gameObject.transform.parent.name != "Cubes") return;
                    bluelinks = 0;
                    bluecRowArray[gameObject.name[5] - '1'] = false;
                    foreach (bool b in bluecRowArray)
                    {
                        Debug.Log(b);
                        if (!b)
                        {
                            bluecCount = 0;
                        }
                        else
                        {
                            bluecCount++;
                        }
                        if (bluecCount % 3 == 0 && bluecCount != 0)
                        {
                            Debug.Log("3 In C Row " + bluecCount / 3 + " Times");
                            blueCLinks = bluecCount / 3;
                            bluelinks = blueALinks + blueBLinks + blueCLinks;
                            points = points + ((redlinks + bluelinks )* 5);

                        }
                    }
                    break;
            }
            Debug.Log("Red Links: " + redlinks);
            Debug.Log("Blue Links: " + bluelinks);
        }
    }
    public static void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }
    public static void RemovePoints(int pointsToAdd)
    {
        points -= pointsToAdd;
    }
}
