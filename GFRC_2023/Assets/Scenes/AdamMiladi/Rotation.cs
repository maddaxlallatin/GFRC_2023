using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float xAngle, yAngle, zAngle;

    public GameObject cube1;


    // Update is called once per frame
    void Update()
    {
         transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }


}
