using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;

public class WheelChange : MonoBehaviour
{
    public GameObject Module;
    public GameObject HDrive;
    public bool HDCheck = true;
    public GameObject THexDrive;
    public bool TDCheck = false;
    public GameObject CDrive;
    public bool CDCheck = false;
    public BotChange BotChange;
    public int Bot = 0;
    public int MemBot = 0;
    public bool Change = false;

    void Start()
    {
        if(driveTrain != null) return;
        Module = Instantiate(HDrive,transform);
    }

    // Update is called once per frame
    void Update()
    {
    // MemBot = Bot;
    // Bot = BotChange.Bot;


    if (Input.GetKeyDown("0") && TDCheck == false){Destroy(Module); HDCheck = false; TDCheck = false; CDCheck = false;}

    if (Input.GetKeyDown("9") && HDCheck == false){
    Destroy(Module);
    Module = Instantiate(HDrive,transform);
    Module.transform.localPosition = new Vector3(0,0,0);
    HDCheck = true;
    TDCheck = false;
    CDCheck = false; }

    if (Input.GetKeyDown("8") && CDCheck == false){
    Destroy(Module);
    Module = Instantiate(CDrive,transform);
    Module.transform.localPosition = new Vector3(0,0,0);
    CDCheck = true;
    TDCheck = false;
    HDCheck = false; }
    

    if (Input.GetKeyDown("7") && TDCheck == false){
    Destroy(Module);
    Module = Instantiate(THexDrive,transform);
    Module.transform.localPosition = new Vector3(0,0,0);
    CDCheck = false;
    TDCheck = true;
    HDCheck = false; }
    }

}
