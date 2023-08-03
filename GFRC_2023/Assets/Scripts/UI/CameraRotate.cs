using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//-20 60
public class CameraRotate : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float speed;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(target);
        transform.Translate(Vector3.right * Time.deltaTime * speed);

    }
}
