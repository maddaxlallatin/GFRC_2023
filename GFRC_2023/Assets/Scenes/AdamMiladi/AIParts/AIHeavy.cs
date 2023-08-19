using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AIHeavy : MonoBehaviour
{
    public GameObject FLift;

    public AIGrabCone ConeCheck;
    public AIGrabCube CubeCheck;
    public bool Searched = false;
    public GameObject Closest;
    public float distance;

    public Wheel[] RWheels;
    public Wheel[] LWheels;
    public GameObject[] Cones;
    public GameObject[] Cubes;
    ItemSpawner FieldObjects;
    public Vector3 Target;
    // Start is called before the first frame update
    void Start()
    {
    FieldObjects = FindObjectOfType<ItemSpawner>();
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

    void Update()
    {
    Cubes = FieldObjects.FindCubes();
    Target = FindClosestCube();
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
