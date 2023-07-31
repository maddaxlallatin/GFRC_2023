using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChange : MonoBehaviour
{
    public GameObject HDrive;
    public bool HDCheck = false;
    public GameObject Module;
    public bool TDCheck = false;

    void Start()
    {
        Module = Instantiate(HDrive,transform);
        HDCheck = true;
    }

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown("0") && TDCheck == false){Destroy(Module); HDCheck = false;}

    if (Input.GetKeyDown("9") && HDCheck == false){
    Module = Instantiate(HDrive,transform);
    Module.transform.localPosition = new Vector3(0,0,0);
    HDCheck = true;
    TDCheck = false; }
    }
}
