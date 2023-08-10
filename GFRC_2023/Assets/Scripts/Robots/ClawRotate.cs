using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClawRotate : MonoBehaviour
{
    public float TurnSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("r"))
        {
            transform.Rotate(0,TurnSpeed,0,Space.Self);
        }
        if (Input.GetKey("f"))
        {
            transform.Rotate(0,-TurnSpeed,0,Space.Self);
        }
    }
}
