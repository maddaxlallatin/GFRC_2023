using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCubeThrower : MonoBehaviour
{
    public bool Grab = false;
    public bool Full = false;
    public int CubeIntent;
    public AIThrower AI;
    public float GrabLength = 0;
    public float ArmAngle = 0;
    public bool SlingShot = false;
    public float Power = 0;
    public bool Reset = false;
    public bool Marker = false;
    public GameObject Aimer;
    public GameObject AimMarker;
    public GameObject Pivot;

    void Start()
    {
    }

    void Pickup()
    {
        CubeIntent = AI.CubeIntent;
        if (CubeIntent == 1 && Grab == false)
        {
            Grab = true;
        }

        if (Full == true && Power < 15.1f && CubeIntent == 3 && SlingShot == true)
        {
            Power += .1f;
        }
        if (Power > 15)
        {
            Grab = false;
        }
        if (CubeIntent == 1 && Full == false)
        {
            if (ArmAngle < 180 && GrabLength < .16f)
            {
                ArmAngle = ArmAngle + 180/20;
                Pivot.transform.Rotate(0,180/20,0,Space.Self);
                
                GrabLength = GrabLength + .16f/20;
                Pivot.transform.localPosition = new Vector3(GrabLength, 0, .049f);
            }
        }
        if (CubeIntent == 2 && Full == true)
        {
            if (ArmAngle > 0 && GrabLength > -.16f)
            {
                ArmAngle = ArmAngle - 180/20;
                Pivot.transform.Rotate(0,-180/20,0,Space.Self);

                GrabLength = GrabLength - .16f/10;
                Pivot.transform.localPosition = new Vector3(GrabLength,0, .049f);
            } 
        }
        if (SlingShot == true)
        {
            if (Marker == false) 
            {
                Marker = true; 
                AimMarker = Instantiate(Aimer, Pivot.transform.position, Pivot.transform.rotation) as GameObject;
                AimMarker.transform.parent = Pivot.transform;
            }
            AimMarker.transform.localPosition = new Vector3((-Power*Mathf.Sin(30* Mathf.PI/180)/9.81f)*.5f*Power*Mathf.Sin(60* Mathf.PI/180)-.37f,0, .049f);
            Pivot.transform.localPosition = new Vector3(-GrabLength*(Power-10)/10,0, .049f);
        }

        if (Reset == true) 
        {
            Destroy(AimMarker);
            transform.Rotate(0,-ArmAngle,0,Space.Self);
            ArmAngle = 0;
            GrabLength = 0;
            Pivot.transform.localPosition = new Vector3(0,0, .049f);
            Reset = false;
            Marker = false;
        }
    }

    void Update()
    {
        Pickup();
    }

void OnTriggerStay(Collider other)
    {   
        if (other.gameObject.CompareTag("CubeCollect") && Full == false && Grab == true && ArmAngle == 180)
        {
            other.tag = "CubeCollected";
            Full = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
            other.gameObject.transform.parent = gameObject.transform;
        }

        if (other.gameObject.CompareTag("CubeCollected") && Grab == true)
        {               
            other.gameObject.transform.localPosition = new Vector3(0,0,0);
            other.gameObject.transform.rotation = transform.rotation;
            if (Input.GetKey("space") && ArmAngle == 0) 
            {
              SlingShot = true;  
            }
        }
        if (other.gameObject.CompareTag("CubeCollected") && Grab == false)
        {
            other.tag = "CubeCollect";
            Full = false;
            other.gameObject.transform.parent = null;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            if (ArmAngle == 0) 
            {
                other.gameObject.GetComponent<Rigidbody>().AddRelativeForce(-.5f*Power, 0, -0f*Power, ForceMode.Impulse);
                Power = 0;
            }
            SlingShot = false;
            Reset = true;
        }
    }
}