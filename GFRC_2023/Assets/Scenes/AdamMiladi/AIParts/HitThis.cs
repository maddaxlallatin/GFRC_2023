using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitThis : MonoBehaviour
{
    public float RoTarget;
    public float Blue;
    // Start is called before the first frame update
    void Start()
    {
        RoTarget = 0 + 180*Blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay()
    {
        RoTarget += .1f;
    }
}
