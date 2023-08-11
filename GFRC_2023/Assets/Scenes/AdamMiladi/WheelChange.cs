using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelChange : MonoBehaviour
{
    public GameObject Module;
    public GameObject HDrive;
    public bool HDCheck = true;

    public bool TDCheck = false;

    public bool CDCheck = false;
    public BotChange BotChange;
    public int Bot = 0;
    public int MemBot = 0;
    public bool Change = false;

    void Start()
    {
        Module = Instantiate(HDrive,transform);
    }

    // Update is called once per frame
    void Update()
    {
    MemBot = Bot;
    Bot = BotChange.Bot;


    if (Input.GetKeyDown("0") && TDCheck == false){Destroy(Module); HDCheck = false; TDCheck = false; CDCheck = false;}

    if (Input.GetKeyDown("9") && HDCheck == false){
    Module = Instantiate(HDrive,transform);
    Module.transform.localPosition = new Vector3(0,0,0);
    HDCheck = true;
    TDCheck = false; }
    }
}
