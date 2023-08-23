using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    public GameObject[] Cubes;
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
    
    void Start()
    {
    Cubes = FindCubes();
    }
    void FixedUpdate()
    {
        if (Cubes.Length < 5)
        {
        if (RedBank == BlueBank)
        {
            Tie = Random.Range(0, 1);
            var position = new Vector3(-8.122f + 16.244f * Tie, .617f, 2.748f);
            Instantiate(Cube, position, Quaternion.identity);
            if (Tie == 0) {RedBank--;}
            else {BlueBank--;}
        }
        else if (RedBank > BlueBank)
        {
            var position = new Vector3(-8.122f, .617f, 2.748f);
            Instantiate(Cube, position, Quaternion.identity);
            RedBank--;
        }
        else
        {
            var position = new Vector3(8.122f, .617f, 2.748f);
            Instantiate(Cube, position, Quaternion.identity);
            BlueBank--;
        }
        }
    }
}
