using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIHeavy : MonoBehaviour
{
    public int Orange;
    public GameObject FLift;
    public GameObject Bot;
    public float DrivePower = 10f;
    public AIGrabCone AICone;
    public AIGrabCube AICube;
    public AILongArm AIArm;
    public int CubeIntent = 0;
    public int ConeIntent = 0;
    public GameObject Closest;
    public GameObject THexDrive;
    public GameObject Drive;
    public float distance;
    public List<GameObject> Zones;
    public Rigidbody AIChasis;
    public int Overpass = 0;
    public float Pastpass;
    public int Row;

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


    void RoTargeting()
    {
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
    }


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

    if (CubeIntent == 0 || CubeIntent == 6)
    { 
    Cubes = FieldObjects.FindCubes();
    Target = FindClosestCube();
    // Debug.Log(Target);
    Path = Target - Bot.transform.position;
    // Debug.Log(Path);
    // Debug.Log(Path.x*Path.x + Path.z*Path.z);
    
    RoTargeting();
    //  Debug.Log(RoTarget);
    //  Debug.Log(transform.eulerAngles.y);

    if (transform.eulerAngles.y > RoTarget + 1.5f && AICube.Full == false|| transform.eulerAngles.y < RoTarget - 1.5f && AICube.Full == false)
    {
    
    if (transform.eulerAngles.y > RoTarget && transform.eulerAngles.y - 180f < RoTarget || transform.eulerAngles.y < RoTarget - 180f && transform.eulerAngles.y - 180f < RoTarget)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(.7f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(-.7f*DrivePower);
        w.UpdatePosition();
    }
    }
    else
    {
    foreach(Wheel w in RWheels)
        {
            w.Accelerate(-.7f*DrivePower);
            w.UpdatePosition();
        }
        foreach(Wheel w in LWheels)
        {
            w.Accelerate(.7f*DrivePower);
            w.UpdatePosition();
        }
    }
    }
    else if (Path.x*Path.x + Path.z*Path.z > .4f && AICube.Full == false)
    {
    foreach(Wheel w in RWheels)
        {
            w.Accelerate(2.2f*DrivePower);
            w.UpdatePosition();
        }
        foreach(Wheel w in LWheels)
        {
            w.Accelerate(2.2f*DrivePower);
            w.UpdatePosition();
        }
    }
    else if (AICube.Full == true)
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
else if (CubeIntent == 1)
{
    if (Orange == 0)
    {
    if (ScoreZone.FindBCu3().Count > 0)
    {
        Zones = ScoreZone.FindBCu3();
        Row = 3;
    }
    else if (ScoreZone.FindBCu2().Count > 0)
    {
        Zones = ScoreZone.FindBCu2();
        Row = 2;
    }
    else
    {
        Row = 1;
    }
    }
    else
    {
    if (ScoreZone.FindRCu3().Count > 0)
    {
        Zones = ScoreZone.FindRCu3();
        Row = 3;
    }
    else if (ScoreZone.FindRCu2().Count > 0)
    {
        Zones = ScoreZone.FindRCu2();
        Row = 2;
    }   
    else
    {
        Row = 1;
    }
    }
    GameObject Closest = null;
    float distance = Mathf.Infinity;
    Vector3 position = transform.position;
    for (int i = 0; i < Zones.Count; i++)
    {
        Vector3 diff = Zones[i].transform.position - position;
        float curDistance = diff.sqrMagnitude;
        if (curDistance < distance)
        {
            Closest = Zones[i];
            distance = curDistance;
        }
    }
    Target = Closest.transform.position;
    // Debug.Log(Target);
if (Orange == 0)  
{
if (ScoreZone.FindBCu3().Count > 0)
    {
    Path = Target - Bot.transform.position + new Vector3(6.1f,0,0); 
    }
else {Path = Target - Bot.transform.position + new Vector3(5.7f,0,0);}
}
else
{
if (ScoreZone.FindRCu3().Count > 0)
    {
    Path = Target - Bot.transform.position + new Vector3(-6.1f,0,0); 
    }
else {Path = Target - Bot.transform.position + new Vector3(-5.7f,0,0);}
}

    RoTargeting();
    //  Debug.Log(transform.eulerAngles.y);

    if (transform.eulerAngles.y > RoTarget + 1.5f || transform.eulerAngles.y < RoTarget - 1.5f)
    {
    
    if (transform.eulerAngles.y > RoTarget && transform.eulerAngles.y - 180f < RoTarget || transform.eulerAngles.y < RoTarget - 180f && transform.eulerAngles.y - 180f < RoTarget)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(.7f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(-.7f*DrivePower);
        w.UpdatePosition();
    }
    }
    else
    {

    foreach(Wheel w in RWheels)
        {
            w.Accelerate(-.7f*DrivePower);
            w.UpdatePosition();
        }
    foreach(Wheel w in LWheels)
        {
            w.Accelerate(.7f*DrivePower);
            w.UpdatePosition();
        }
    }
    }
    else if (Path.x*Path.x + Path.z*Path.z > .12f)
    {
    foreach(Wheel w in RWheels)
        {
            w.Accelerate(.75f*DrivePower);
            w.UpdatePosition();
        }
    foreach(Wheel w in LWheels)
        {
            w.Accelerate(.75f*DrivePower);
            w.UpdatePosition();
        }
    }
    else
    {
        AIChasis.velocity = new Vector3(AIChasis.velocity.x/10, AIChasis.velocity.y/10, AIChasis.velocity.z/10);
        // Debug.Log("Victory");
        CubeIntent = 2;
        if (Orange == 0)
        {
        if (ScoreZone.FindBCu3().Count > 0)
        {
        Target = Target - new Vector3(-1.2f,0,0);
        }
        else if (ScoreZone.FindBCu2().Count > 0){Target = Target - new Vector3(-.8f,0,0);}
        }
        else
        {
        if (ScoreZone.FindRCu3().Count > 0)
        {
        Target = Target - new Vector3(1.2f,0,0);
        }
        else if (ScoreZone.FindRCu2().Count > 0){Target = Target - new Vector3(.8f,0,0);}
        }
        // Debug.Log(Path);
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
    else if (CubeIntent == 2)
    {
        Path = Target - Bot.transform.position;
        RoTargeting();
    //  Debug.Log(transform.eulerAngles.y);

    if (transform.eulerAngles.y > RoTarget + 1.5f || transform.eulerAngles.y < RoTarget - 1.5f)
    {
    
    if (transform.eulerAngles.y > RoTarget && transform.eulerAngles.y - 180f < RoTarget || transform.eulerAngles.y < RoTarget - 180f && transform.eulerAngles.y - 180f < RoTarget)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(.7f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(-.7f*DrivePower);
        w.UpdatePosition();
    }
    }
    else
    {

    foreach(Wheel w in RWheels)
        {
            w.Accelerate(-.7f*DrivePower);
            w.UpdatePosition();
        }
    foreach(Wheel w in LWheels)
        {
            w.Accelerate(.7f*DrivePower);
            w.UpdatePosition();
        }
    }
    }
    else if (Path.x*Path.x + Path.z*Path.z > .12f)
    {
    foreach(Wheel w in RWheels)
        {
            w.Accelerate(2.5f*DrivePower);
            w.UpdatePosition();
        }
    foreach(Wheel w in LWheels)
        {
            w.Accelerate(2.5f*DrivePower);
            w.UpdatePosition();
        }
    }
    else
    {
        AIChasis.velocity = new Vector3(AIChasis.velocity.x/10, AIChasis.velocity.y/10, AIChasis.velocity.z/10);
        CubeIntent = 3;
        if (Row == 3)
        {
        Target = Target - new Vector3(3.7f-Orange*7.4f,0,0);
        }
        if (Row == 2)
        {
        Target = Target - new Vector3(3.7f-Orange*7.4f,0,0);
        }
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
    else if (CubeIntent == 3)
    {
    Path = Target - Bot.transform.position;
    RoTargeting();
    Debug.Log(transform.eulerAngles.y);
    Debug.Log(RoTarget);
    if (transform.eulerAngles.y > RoTarget + 1f || transform.eulerAngles.y < RoTarget - 1f)
    {
    
    if (transform.eulerAngles.y > RoTarget && transform.eulerAngles.y - 180f < RoTarget || transform.eulerAngles.y < RoTarget - 180f && transform.eulerAngles.y - 180f < RoTarget)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(.7f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(-.7f*DrivePower);
        w.UpdatePosition();
    }
    }
    else
    {

    foreach(Wheel w in RWheels)
        {
            w.Accelerate(-.7f*DrivePower);
            w.UpdatePosition();
        }
    foreach(Wheel w in LWheels)
        {
            w.Accelerate(.7f*DrivePower);
            w.UpdatePosition();
        }
    }
    }
    else if (AICube.Full == true)
    {
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
    if (AIArm.GrabLength > 1.45f && AIArm.ArmAngle > 44.8f && Row == 3)
    {
        Target = Target + new Vector3(10f+Orange*-20f,0,0);
        CubeIntent = 4;
    }
    else if (AIArm.GrabLength > .79f && AIArm.ArmAngle > 44.8f && Row == 2)
    {
        Target = Target + new Vector3(10f+Orange*-20f,0,0);
        CubeIntent = 4;
    }
    }
    else if (CubeIntent == 4)
    {
        Path = Target - Bot.transform.position;
        RoTargeting();
        Debug.Log(Path);

    if (transform.eulerAngles.y > RoTarget + 1.5f || transform.eulerAngles.y < RoTarget - 1.5f)
    {
    
    if (transform.eulerAngles.y > RoTarget && transform.eulerAngles.y - 180f < RoTarget || transform.eulerAngles.y < RoTarget - 180f && transform.eulerAngles.y - 180f < RoTarget)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(.7f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(-.7f*DrivePower);
        w.UpdatePosition();
    }
    }
    else
    {

    foreach(Wheel w in RWheels)
        {
            w.Accelerate(-.7f*DrivePower);
            w.UpdatePosition();
        }
    foreach(Wheel w in LWheels)
        {
            w.Accelerate(.7f*DrivePower);
            w.UpdatePosition();
        }
    }
    }
    else if (Path.x*Path.x + Path.z*Path.z > .12f)
    {
    foreach(Wheel w in RWheels)
        {
            w.Accelerate(2.5f*DrivePower);
            w.UpdatePosition();
        }
    foreach(Wheel w in LWheels)
        {
            w.Accelerate(2.5f*DrivePower);
            w.UpdatePosition();
        }
    }
    else
    {
        AIChasis.velocity = new Vector3(AIChasis.velocity.x/10, AIChasis.velocity.y/10, AIChasis.velocity.z/10);
        CubeIntent = 0;
    }
    }
}
// Debug.Log(CubeIntent);
// Debug.Log(Target);

}