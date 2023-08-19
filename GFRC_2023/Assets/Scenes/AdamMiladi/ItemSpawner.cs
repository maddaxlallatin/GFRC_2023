using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] Cubes;

    public GameObject[] FindCubes()
    {
        Cubes = GameObject.FindGameObjectsWithTag("CubeCollect");
        return Cubes;
    }
    
    void Start()
    {
    Cubes = FindCubes();
    Debug.Log(Cubes.Length);
    }
}
