using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIScout : MonoBehaviour
{
    public HitThis HitBox;
    public GameObject Bot;
    public float DrivePower = 10f;
    public ClawConeGrab AICone;
    public int ConeIntent = 1;
    public GameObject Closest;
    public GameObject Drive;
    public float distance;
    public Rigidbody AIChasis;

    public bool Ready = false;

    public GameObject[] Cones;
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
    Target = new Vector3 (6.5f,.25f,-2.95f);
    ConeIntent = 0;
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

    public Vector3 FindNearestCone()
    {
        GameObject Closest = null;
        float distance = 10f;
        Vector3 position = transform.position;
        foreach (GameObject Cone in Cones)
        {
            if (Cone.transform.position.y < .23f)
            {
            Vector3 diff = Cone.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                Closest = Cone;
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

    void FixedUpdate()
    {
        // Cones = FieldObjects.FindCones();
        RoTarget = HitBox.RoTarget;
    if (transform.eulerAngles.y > RoTarget && transform.eulerAngles.y - 180f < RoTarget || transform.eulerAngles.y < RoTarget - 180f && transform.eulerAngles.y - 180f < RoTarget)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(.3f*DrivePower);
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
    else if (transform.eulerAngles.y < RoTarget && transform.eulerAngles.y - 180f > RoTarget || transform.eulerAngles.y > RoTarget - 180f && transform.eulerAngles.y - 180f > RoTarget)
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(.3f*DrivePower);
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
    else
    {
    foreach(Wheel w in RWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in LWheels)
    {
        w.Accelerate(.3f*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in UWheels)
    {
        w.Accelerate(0*DrivePower);
        w.UpdatePosition();
    }
    foreach(Wheel w in BWheels)
    {
        w.Accelerate(0*DrivePower);
        w.UpdatePosition();
    }
    }
    }
}