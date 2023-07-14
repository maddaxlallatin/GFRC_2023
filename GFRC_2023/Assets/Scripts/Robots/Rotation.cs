using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{

    public float xAngle, yAngle, zAngle;

    public GameObject cube1;
    // Start is called before the first frame update
    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {
         transform.Rotate(xAngle, yAngle, zAngle, Space.Self);
    }


}
