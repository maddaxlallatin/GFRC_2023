using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchScript : MonoBehaviour
{
    public GameObject Claw;
    public GameObject Oct_mesh;
    public GameObject ArmFiller;
    public bool ClawCheck = false;
    public GameObject Module;
    public bool GrabCheck = true;

    // Start is called before the first frame update
    void Start()
    {
        Module = Instantiate(ArmFiller,transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1") && ClawCheck == false){
        Destroy(Module);
        Module = Instantiate(Claw,transform);
        Module.transform.localPosition = new Vector3(0,0,0);
        ClawCheck = true;
        GrabCheck = false;
        }
        
        if (Input.GetKeyDown("2") && GrabCheck == false){
        Destroy(Module);
        Module = Instantiate(ArmFiller,transform);
        Module.transform.localPosition = new Vector3(0,0,0);
        ClawCheck = false;
        GrabCheck = true;
        }
    }
}
