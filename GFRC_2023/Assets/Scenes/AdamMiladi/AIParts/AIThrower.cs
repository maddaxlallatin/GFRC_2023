using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIThrower : MonoBehaviour
{
    public GameObject Bot;
    public float DrivePower = 10f;
    public GrabCubeThrower AICube;
    public int CubeIntent = 1;
    public GameObject Closest;
    public GameObject Drive;
    public float distance;
    public Rigidbody AIChasis;

    public bool Ready = false;

    public GameObject[] Cubes;
    public Wheel[] RWheels;
    public Wheel[] LWheels;
    public Wheel[] UWheels;
    public Wheel[] BWheels;

    ItemSpawner FieldObjects;
    ScoreState ScoreZone;
    public Vector3 Target;
    public Vector3 Path;
    public float RoTarget;
    public int BlueColor;
    // Start is called before the first frame update

    void RoTargeter()
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
    RoTarget += 90;
     if (RoTarget < 0) {RoTarget += 360;}
    }
    void Start()
    {
    Target = new Vector3 (-6.5f+13*BlueColor,0,2.75f);
    CubeIntent = 0;
    FieldObjects = FindObjectOfType<ItemSpawner>();
    ScoreZone = FindObjectOfType<ScoreState>();
    foreach(Wheel w in UWheels)
    {
        w.transform.GetChild(0).GetComponent<WheelCollider>().steerAngle = w.offset;
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.transform.GetChild(0).GetComponent<WheelCollider>().steerAngle = w.offset;
        w.UpdatePosition();
    }
    }

    public Vector3 FindNearestCube()
    {
        GameObject Closest = null;
        float distance = 10f;
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
        if (Closest != null)
        {
        return Closest.transform.position;
        }
        else {return new Vector3(1,1,1);}
    }
    // Update is called once per frame
    void FixedUpdate()
    {
    // Debug.Log(Path);
    if (CubeIntent == 0)
    {
    Path = Target - Bot.transform.position;
    // Debug.Log(Path.x*Path.x + Path.z*Path.z);
    RoTargeter();
    // Debug.Log(RoTarget);
    // Debug.Log(transform.eulerAngles.y);
    if (transform.eulerAngles.y > RoTarget + 1.5f || transform.eulerAngles.y < RoTarget - 1.5f)
    {
    
    if (transform.eulerAngles.y > RoTarget && transform.eulerAngles.y - 180f < RoTarget || transform.eulerAngles.y < RoTarget - 180f && transform.eulerAngles.y - 180f < RoTarget)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(-.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(-.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    }
    else
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(-.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(-.3f*DrivePower);
        w.UpdatePosition();
    }
    }
    }
    else if (Path.x*Path.x + Path.z*Path.z > .4f)
    {

    AIChasis.angularVelocity = new Vector3 (AIChasis.angularVelocity.x,AIChasis.angularVelocity.y/5f,AIChasis.angularVelocity.z);

    foreach(Wheel w in LWheels)
    {
        w.Accelerate(15*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(15*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(0);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(0);
        w.UpdatePosition();
    }
    }
    else
    {
    // Debug.Log("owie");
    CubeIntent = 1;
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(0);
        w.UpdatePosition();
    }
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(0);
        w.UpdatePosition();
    }
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(0);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(0);
        w.UpdatePosition();
    }
    AIChasis.velocity = new Vector3(AIChasis.velocity.x/10, AIChasis.velocity.y/10, AIChasis.velocity.z/10);
    RoTarget = 90+180*BlueColor;
    }
    }
    else if (CubeIntent == 1)
    {
        if (transform.eulerAngles.y > RoTarget + 1.5f && AICube.Full == false|| transform.eulerAngles.y < RoTarget - 1.5f && AICube.Full == false)
    {
    
    if (transform.eulerAngles.y > RoTarget && transform.eulerAngles.y - 180f < RoTarget || transform.eulerAngles.y < RoTarget - 180f && transform.eulerAngles.y - 180f < RoTarget)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(-.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(-.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    }
    else
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(-.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(-.3f*DrivePower);
        w.UpdatePosition();
    }
    }
    }
    else if (AICube.Full == false) 
    {
    AIChasis.angularVelocity = new Vector3 (AIChasis.angularVelocity.x,AIChasis.angularVelocity.y/5f,AIChasis.angularVelocity.z);
    Cubes = FieldObjects.FindCubes();
    Target = FindNearestCube();
    // Debug.Log(Path.x);
    Path = Target - Bot.transform.position;
    if (Path.z < -.1 && BlueColor == 0 || Path.z > .1 && BlueColor == 1)
    {
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(-3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    }
    else if (Path.z > .1 && BlueColor == 0 || Path.z < -.1 && BlueColor == 1)
    {
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(-3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    }
    else if (Path.x < -.3f && BlueColor == 0|| BlueColor == 1 && Path.x > .3f)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(-3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(-3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    }
    else
    {
    AIChasis.velocity = new Vector3(AIChasis.velocity.x/10, AIChasis.velocity.y/10, AIChasis.velocity.z/10);
    }
    }
    else if (AICube.Full == true)
    {
    CubeIntent = 2;
    }
    }
    else if (CubeIntent == 2)
    {
    Target = new Vector3 (-6f+12*BlueColor,0,2.5f);
    // Debug.Log(Path.x);
    Path = Target - Bot.transform.position;
    if (Path.z < -.1 && BlueColor == 0 || Path.z > .1 && BlueColor == 1)
    {
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(-3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    }
    else if (Path.z > .1 && BlueColor == 0 || Path.z < -.1 && BlueColor == 1)
    {
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(-3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    }
    else if (Path.x < -.1f && BlueColor == 0|| BlueColor == 1 && Path.x > .1f)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(-3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(-3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    }
    else if (Path.x > .1f && BlueColor == 0|| BlueColor == 1 && Path.x < -.1f)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    }
    else
    {
    RoTarget = 125 + 110*BlueColor;
    CubeIntent = 3;
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(0f*DrivePower);
        w.UpdatePosition();
    }    
    }
    }
    else if (CubeIntent == 3)
    {
    if (transform.eulerAngles.y > RoTarget + 1.5f|| transform.eulerAngles.y < RoTarget - 1.5f)
    {
    if (transform.eulerAngles.y > RoTarget && transform.eulerAngles.y - 180f < RoTarget || transform.eulerAngles.y < RoTarget - 180f && transform.eulerAngles.y - 180f < RoTarget)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(-.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(-.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    }
    else
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(-.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(-.3f*DrivePower);
        w.UpdatePosition();
    }
    }
    }
    else if (AICube.Full == true)
    {
    AIChasis.angularVelocity = new Vector3 (AIChasis.angularVelocity.x,AIChasis.angularVelocity.y/5f,AIChasis.angularVelocity.z);
    AICube.SlingShot = true;
    // AICube.Full = false;
    }
    else if (AICube.SlingShot = false || AICube.Full == false)
    {
    RoTarget = 90 + 180*BlueColor;
    CubeIntent = 1;
    }
    }
    }
}