using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;
public class ChargeStationPoints : MonoBehaviour
{
    public bool shouldGainPoints = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public  void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Robot"){
            shouldGainPoints= true;
        }
    }
    
    public  void OnTriggerExit(Collider other) {
        if(other.gameObject.tag == "Robot"){
            shouldGainPoints= false;
        }
    }

    public void gameIsOver(){
        if(shouldGainPoints){
        points += 10;
        }

        
    }
}
