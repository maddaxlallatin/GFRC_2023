using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotChange : MonoBehaviour
{
    public bool OrangeOctCheck = true;
    public bool OrangeSquCheck = false;
    public bool BlueOctCheck = false;
    public bool BlueSquCheck = false;
    public GameObject OrangeOctBot;
    public GameObject CurrentBot;
    public GameObject BlueOctBot;
    public GameObject OrangeSquBot;
    public GameObject BlueSquBot;

    void Start()
    {
        CurrentBot = Instantiate(OrangeOctBot,transform);
        OrangeOctCheck = true; 
    }

    void Update()
    {
    if (Input.GetKeyDown("p") && BlueOctCheck == false){
        Destroy(CurrentBot); 
        CurrentBot = Instantiate(BlueOctBot,transform);
        CurrentBot.transform.localPosition = new Vector3(0,0,0);
        BlueOctCheck = true;
        OrangeOctCheck = false;
        OrangeSquCheck = false;
        BlueSquCheck = false;}

    if (Input.GetKeyDown("o") && OrangeOctCheck == false){
        Destroy(CurrentBot); 
        CurrentBot = Instantiate(OrangeOctBot,transform);
        CurrentBot.transform.localPosition = new Vector3(0,0,0);
        OrangeOctCheck = true;
        BlueOctCheck = false;
        OrangeSquCheck = false;
        BlueSquCheck = false;}

    if (Input.GetKeyDown("i") && OrangeSquCheck == false){
        Destroy(CurrentBot); 
        CurrentBot = Instantiate(OrangeSquBot,transform);
        CurrentBot.transform.localPosition = new Vector3(0,0,0);
        OrangeSquCheck = true;
        BlueOctCheck = false;
        OrangeOctCheck = false;
        BlueSquCheck = false;}

    if (Input.GetKeyDown("u") && BlueSquCheck == false){
        Destroy(CurrentBot); 
        CurrentBot = Instantiate(BlueSquBot,transform);
        CurrentBot.transform.localPosition = new Vector3(0,0,0);
        BlueSquCheck = true;
        OrangeSquCheck = false;
        BlueOctCheck = false;
        OrangeOctCheck = false;}
    }
}
