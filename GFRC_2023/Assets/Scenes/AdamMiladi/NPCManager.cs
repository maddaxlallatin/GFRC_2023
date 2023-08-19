using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;

public class NPCManager : MonoBehaviour
{
    public GameObject AIScout;
    public GameObject AIHeavy;
    public GameObject AISniper;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(manipulator);
        if (manipulator == "OrangeCubeChuckerUIVERSION(Clone)")
        {Debug.Log("AHHHHHH");}
    }

    // Update is called once per frame
    void Update()
    {

    }
}
