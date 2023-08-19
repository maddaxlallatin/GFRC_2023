using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIHeavy : MonoBehaviour
{
    public GameObject FLift;
    public float DrivePower = 8f;
    public AIGrabCone ConeCheck;
    public AIGrabCube CubeCheck;
    public bool Searched = false;
    public GameObject Closest;
    public GameObject THexDrive;
    public GameObject Drive;
    public float distance;


    public Wheel[] RWheels;
    public Wheel[] LWheels;
    public GameObject[] Cones;
    public GameObject[] Cubes;
    ItemSpawner FieldObjects;
    public Vector3 Target;
    public Vector3 Path;
    public float RoTarget;
    // Start is called before the first frame update
    void Start()
    {
    FieldObjects = FindObjectOfType<ItemSpawner>();
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
            Vector3 diff = Cube.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                Closest = Cube;
                distance = curDistance;
            }
        }
        return Closest.transform.position;
    }

    void FixedUpdate()
    {
    Cubes = FieldObjects.FindCubes();
    Target = FindClosestCube();
    // Debug.Log(Target);
    Path = Target - transform.position;
    // Debug.Log(Path);
    
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
    // Debug.Log(RoTarget);
    // Debug.Log(transform.eulerAngles.y);

    if (transform.eulerAngles.y > RoTarget + .5f || transform.eulerAngles.y < RoTarget - .5f)
    {
    
    if (transform.eulerAngles.y - RoTarget > 0)
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
    else 
    {
    // Debug.Log("Victory");
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
    // void Update()
    // {
    //     if (ConeCheck.Grab == false && CubeCheck.Grab == false && Searched == false)
    //     {
    //     Searched = true;
    //     }
    // }
}
