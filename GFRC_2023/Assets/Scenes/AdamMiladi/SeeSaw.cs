using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class SeeSaw : MonoBehaviour
{
    //Variables
    public Animator anim;

    public GameObject Chargestation;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    //Animations and Collisions
    void OnTriggerStay(Collider col)
    {
        //if side A collides with player, play animation
        if (gameObject.name == "SlantA")
        {
            if (col.gameObject.name == "col_Wheel")
            {
                UnityEngine.Debug.Log("Charge Station B up");
                anim.SetTrigger("UpB");
            }
        }
        //if side B collides with player, play animation
        if (gameObject.name == "SlantB")
        {
            if (col.gameObject.name == "col_Wheel")
            {
                UnityEngine.Debug.Log("Charge Station B up");
                anim.SetTrigger("UpA");
            }
        }
    }
        
 
}