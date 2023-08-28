using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] Cubes;
    public GameObject[] Cones;
    public GameObject Cube;
    public GameObject Cone;
    public int Tie;
    public int RedBank = 3;
    public int BlueBank = 3;

    public GameObject[] FindCubes()
    {
        Cubes = GameObject.FindGameObjectsWithTag("CubeCollect");
        return Cubes;
    }
    public GameObject[] FindCones()
    {
        Cones = GameObject.FindGameObjectsWithTag("ConeCollect");
        return Cones;
    }
    
    void Start()
    {
    Cubes = FindCubes();
    Cones = FindCones();
    }
    void FixedUpdate()
    {
        Cubes = FindCubes();
        Cones = FindCones();
        if (Cubes.Length < 5 && Time.timeSinceLevelLoad > 5f)
        {
        if (RedBank == BlueBank)
        {
            Tie = Random.Range(0, 1);
            var position = new Vector3(-8.122f + 16.244f * Tie, .617f, 2.26f + Random.Range(0, 2) * 0.48f);
            Instantiate(Cube, position, Quaternion.identity, transform);
            if (Tie == 0) {RedBank--;}
            else {BlueBank--;}
        }
        else if (RedBank > BlueBank)
        {
            var position = new Vector3(-8.122f, .617f, 2.26f + Random.Range(0, 2) * 0.48f);
            Instantiate(Cube, position, Quaternion.identity, transform);
            RedBank--;
        }
        else
        {
            var position = new Vector3(8.122f, .617f, 2.26f + Random.Range(0, 2) * 0.48f);
            Instantiate(Cube, position, Quaternion.identity, transform);
            BlueBank--;
        }
        }

        if (Cones.Length < 5 && Time.timeSinceLevelLoad > 5f)
        {
        if (RedBank == BlueBank)
        {
            Tie = Random.Range(0, 1);
            var position = new Vector3(-6.25f + 12f * Tie + Random.Range(0, 2)*.25f, .75f,3.75f);
            Instantiate(Cone, position, Quaternion.identity, transform);
            if (Tie == 0) {RedBank--;}
            else {BlueBank--;}
        }
        else if (RedBank > BlueBank)
        {
            var position = new Vector3(-6.25f + Random.Range(0, 2)*.25f, .75f,3.75f);
            Instantiate(Cone, position, Quaternion.identity, transform);
            RedBank--;
        }
        else
        {
            var position = new Vector3(6.25f + Random.Range(0, 2)*-.25f, .75f,3.75f);
            Instantiate(Cone, position, Quaternion.identity, transform);
            BlueBank--;
        }
        }
    }
}