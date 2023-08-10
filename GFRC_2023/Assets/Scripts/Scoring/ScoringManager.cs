using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;

public class ScoringManager : MonoBehaviour
{
    // Start is called before the first frame update
    #pragma warning disable IDE0051


    void Start() 
    {
        points = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    private void OnTriggerEnter(Collider other) {
        Debug.Log("Collision");
        if(other.gameObject.tag == "Cube" || other.gameObject.tag == "Cone")
        { 
            
            Debug.Log(gameObject.transform.parent.gameObject.name);
            switch(gameObject.transform.parent.gameObject.name){
                case "Level 1":
                    AddPoints(2);
                    break;
                case "Level 2":
                    AddPoints(3);
                    break;
                case "Level 3":
                    AddPoints(5);
                    break;
            }
            Debug.Log(points);
        }
    }

    private void OnTriggerExit(Collider other) {
        Debug.Log("Collision");
        if(other.gameObject.tag == "Cube" || other.gameObject.tag == "Cone")
        { 
            
            Debug.Log(gameObject.transform.parent.gameObject.name);
            switch(gameObject.transform.parent.gameObject.name){
                case "Level 1":
                    RemovePoints(2);
                    break;
                case "Level 2":
                    RemovePoints(3);
                    break;
                case "Level 3":
                    RemovePoints(5);
                    break;
            }
            Debug.Log(points);
        }
    }
    public static void AddPoints(int pointsToAdd)
    {
        points += pointsToAdd;
    }
     public static void RemovePoints(int pointsToAdd)
    {
        points -= pointsToAdd;
    }
}
