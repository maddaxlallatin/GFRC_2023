using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIHeavy : MonoBehaviour
{
    public GameObject FLift;
    public GameObject Bot;
    public float DrivePower = 9f;
    public AIGrabCone AICone;
    public AIGrabCube AICube;
    public bool OneEighty = false;
    public int CubeIntent = 0;
    public int ConeIntent = 0;
    public GameObject Closest;
    public GameObject THexDrive;
    public GameObject Drive;
    public float distance;
    public List<GameObject> Zones;
    public int Overpass = 0;
    public float Pastpass;

    public Wheel[] RWheels;
    public Wheel[] LWheels;
    public GameObject[] Cones;
    public GameObject[] Cubes;
    ItemSpawner FieldObjects;
    ScoreState ScoreZone;
    public Vector3 Target;
    public Vector3 Path;
    public float RoTarget;
    // Start is called before the first frame update
    void Start()
    {
    FieldObjects = FindObjectOfType<ItemSpawner>();
    ScoreZone = FindObjectOfType<ScoreState>();
    // Drive = Instantiate(THexDrive,transform);
    // RWheels = Drive.GetComponent<WheelArray>().RWheels;
    // LWheels = Drive.GetComponent<WheelArray>().LWheels;


    }

    public Vector3 FindClosestCube()
    {
        GameObject Closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject Cube in Cubes)
        {
            if (Cube.transform.position.y < .23f)
            {
            Vector3 diff = Cube.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                Closest = Cube;
                distance = curDistance;
            }
            }
        }
        return Closest.transform.position;
    }

    void FixedUpdate()
    {
if (AICone.Full == false && AICube.Full == false)
{
    Cubes = FieldObjects.FindCubes();
    Target = FindClosestCube();
    // Debug.Log(Target);
    Path = Target - Bot.transform.position;
    Debug.Log(Path);
    // Debug.Log(Path.x*Path.x + Path.z*Path.z);
    
    if (Path.x < 0 && Path.z > 0)
    {
    RoTarget = 180-((180/Mathf.PI)*Mathf.Atan(Path.z/Path.x)+360);
    }
    else if (Path.x > 0)
    {
    RoTarget = 180-((180/Mathf.PI)*Mathf.Atan(Path.z/Path.x)+180);
    }
    else 
    {
    RoTarget = 180-(180/Mathf.PI)*Mathf.Atan(Path.z/Path.x);
    }
     if (RoTarget < 0) {RoTarget = RoTarget + 360;}
    //  Debug.Log(RoTarget);
    //  Debug.Log(transform.eulerAngles.y);

    if (transform.eulerAngles.y > RoTarget + 1f || transform.eulerAngles.y < RoTarget - 1f)
    {
    
    if (transform.eulerAngles.y > RoTarget && transform.eulerAngles.y - 180f < RoTarget || transform.eulerAngles.y < RoTarget - 180f && transform.eulerAngles.y - 180f < RoTarget)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(-DrivePower);
        w.UpdatePosition();
    }
    }
    else
    {
    foreach(Wheel w in RWheels)
        {
            w.Accelerate(-DrivePower);
            w.UpdatePosition();
        }
        foreach(Wheel w in LWheels)
        {
            w.Accelerate(DrivePower);
            w.UpdatePosition();
        }
    }
    }
    else if (Path.x*Path.x + Path.z*Path.z > .4f)
    {
    foreach(Wheel w in RWheels)
        {
            w.Accelerate(2*DrivePower);
            w.UpdatePosition();
        }
        foreach(Wheel w in LWheels)
        {
            w.Accelerate(2*DrivePower);
            w.UpdatePosition();
        }
    }
    else
    {
        CubeIntent = 1;
        Debug.Log("Victory");
        foreach(Wheel w in RWheels)
        {
            w.Accelerate(0);
            w.UpdatePosition();
        }
        foreach(Wheel w in LWheels)
        {
            w.Accelerate(0);
            w.UpdatePosition();
        }
    }
}
else
{
    Zones = ScoreZone.FindRCu3();
    if (Zones.Count > 0)
    {
    CubeIntent = 3;    
    Target = Zones[0].transform.position;
    // Debug.Log(Target);
    Path = Target - Bot.transform.position + new Vector3(-1.1f,0,.25f); 
    if (OneEighty == false){
    if (Path.x < 0 && Path.z > 0)
    {
    RoTarget = 180-((180/Mathf.PI)*Mathf.Atan(Path.z/Path.x)+360);
    }
    else if (Path.x > 0)
    {
    RoTarget = 180-((180/Mathf.PI)*Mathf.Atan(Path.z/Path.x)+180);
    }
    else 
    {
    RoTarget = 180-(180/Mathf.PI)*Mathf.Atan(Path.z/Path.x);
    }
    }
    
     if (RoTarget < 0) {RoTarget = RoTarget + 360;}
    //  if (RoTarget - Pastpass > 50f || RoTarget - Pastpass < -50f){Overpass = Overpass + 50; Debug.Log("Oof");}
     Pastpass = RoTarget;
    //  Debug.Log(RoTarget);
    //  Debug.Log(transform.eulerAngles.y);

    if (transform.eulerAngles.y > RoTarget + 1f || transform.eulerAngles.y < RoTarget - 1f)
    {
    
    if (transform.eulerAngles.y > RoTarget && transform.eulerAngles.y - 180f < RoTarget || transform.eulerAngles.y < RoTarget - 180f && transform.eulerAngles.y - 180f < RoTarget)
    {
    if (Overpass == 0)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(.8f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(-.8f*DrivePower);
        w.UpdatePosition();
    }
    }
    else {Overpass--; foreach(Wheel w in RWheels){w.Accelerate(-DrivePower); w.UpdatePosition();}foreach(Wheel w in LWheels){w.Accelerate(-DrivePower);w.UpdatePosition();}}
    }
    else
    {
    if (Overpass == 0)
    {
    foreach(Wheel w in RWheels)
        {
            w.Accelerate(-.8f*DrivePower);
            w.UpdatePosition();
        }
    foreach(Wheel w in LWheels)
        {
            w.Accelerate(.8f*DrivePower);
            w.UpdatePosition();
        }
    }
    else {Overpass--; foreach(Wheel w in RWheels){w.Accelerate(-DrivePower); w.UpdatePosition();}foreach(Wheel w in LWheels){w.Accelerate(-DrivePower);w.UpdatePosition();}}
    }
    }
    else if (Path.x*Path.x + Path.z*Path.z > .12f)
    {
    foreach(Wheel w in RWheels)
        {
            w.Accelerate(2*DrivePower);
            w.UpdatePosition();
        }
    foreach(Wheel w in LWheels)
        {
            w.Accelerate(2*DrivePower);
            w.UpdatePosition();
        }
    }
    else if (OneEighty == false){RoTarget = 0; OneEighty = true; DrivePower = 7;}

    else
    {
        Debug.Log("Victory");
        OneEighty = false;
        CubeIntent = 0;
        Debug.Log(Path);
        foreach(Wheel w in RWheels)
        {
            w.Accelerate(0);
            w.UpdatePosition();
        }
        foreach(Wheel w in LWheels)
        {
        w.Accelerate(0);
        w.UpdatePosition();
        }
    }
    }
    else 
    {
            CubeIntent = 2;    
        // Zones = ScoreZone.FindRCu2();
    }
}
Debug.Log(CubeIntent);
Debug.Log(Target);

}
    // void Update()
    // {
    //     if (ConeCheck.Grab == false && CubeCheck.Grab == false && Searched == false)
    //     {
    //     Searched = true;
    //     }
    // }
}
