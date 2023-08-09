using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharAnim : MonoBehaviour
{
    public Side1 Side1;
    public Side2 Side2;
    public int Up1 = 0;
    public int Up2 = 0;
    public GameObject SideA;
    public GameObject SideB;
    public GameObject SideC;
    public float S1Angle = 34.25f;
    public float S2Angle = 34.25f;
    public float Mem1 = 0f;
    public float Mem2 = 0f;
    // Start is called before the first frame update
    void Start()
    {
            Debug.Log(-(-0.93882f+.38542f*Mathf.Cos(34.25f*Mathf.PI/180)-.38542f*Mathf.Cos((-34.25f+57.5f)*Mathf.PI/180)));
            Debug.Log(-0.93882f+.38542f*Mathf.Cos(34.25f*Mathf.PI/180)-.38542f*Mathf.Cos((-34.25f+57.5f)*Mathf.PI/180));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Up1 = Side1.Up1;
        Up2 = Side2.Up2;
        if (Up1 > 0)
        {
            if (S1Angle > 19.25f && Up2 == 0)
            {
                S1Angle = S1Angle - .75f;
                SideA.transform.Rotate(-.75f,0,0,Space.Self);

                SideB.transform.localRotation = Quaternion.Euler(180/Mathf.PI*Mathf.Asin((.38542f*Mathf.Sin(34.25f*Mathf.PI/180)-.38542f*Mathf.Sin(S1Angle*Mathf.PI/180))/.6096f),90,0);

                SideC.transform.localRotation = Quaternion.Euler(57.5f-(180/Mathf.PI*Mathf.Asin((2*.38542f*Mathf.Sin(34.25f*Mathf.PI/180)-.38542f*Mathf.Sin(S1Angle*Mathf.PI/180))/.38542f)),90,0);
                SideC.transform.localPosition = new Vector3(-0.93882f+.38542f*Mathf.Cos(34.25f*Mathf.PI/180)-.38542f*Mathf.Cos((-SideC.transform.eulerAngles.x+57.5f)*Mathf.PI/180), 0.00451f, 0);
            }
        }
        if (Up1 == 0)
        {
            if (S1Angle < 34.25f && Up2 == 0)
            {
                S1Angle = S1Angle + .75f;
                SideA.transform.Rotate(.75f,0,0,Space.Self);

                SideB.transform.localRotation = Quaternion.Euler(180/Mathf.PI*Mathf.Asin((.38542f*Mathf.Sin(34.25f*Mathf.PI/180)-.38542f*Mathf.Sin(S1Angle*Mathf.PI/180))/.6096f),90,0);

                SideC.transform.localRotation = Quaternion.Euler(57.5f-(180/Mathf.PI*Mathf.Asin((2*.38542f*Mathf.Sin(34.25f*Mathf.PI/180)-.38542f*Mathf.Sin(S1Angle*Mathf.PI/180))/.38542f)),90,0);
                SideC.transform.localPosition = new Vector3(-0.93882f+.38542f*Mathf.Cos(34.25f*Mathf.PI/180)-.38542f*Mathf.Cos((-SideC.transform.eulerAngles.x+57.5f)*Mathf.PI/180), 0.00451f, 0);
            }
        }
        if (Up2 > 0)
        {
            if (S2Angle > 19.25f && Up1 == 0)
            {
                S2Angle = S2Angle - .75f;
                SideC.transform.Rotate(.75f,0,0,Space.Self);

                SideB.transform.localRotation = Quaternion.Euler(-180/Mathf.PI*Mathf.Asin((.38542f*Mathf.Sin(34.25f*Mathf.PI/180)-.38542f*Mathf.Sin(S2Angle*Mathf.PI/180))/.6096f),90,0);

                SideA.transform.localRotation = Quaternion.Euler(-11f+(180/Mathf.PI*Mathf.Asin((2*.38542f*Mathf.Sin(34.25f*Mathf.PI/180)-.38542f*Mathf.Sin(S2Angle*Mathf.PI/180))/.38542f)),90,0);
                SideA.transform.localPosition = new Vector3(0.93882f-.38542f*Mathf.Cos(34.25f*Mathf.PI/180)+.38542f*Mathf.Cos((SideA.transform.eulerAngles.x+11f)*Mathf.PI/180), 0.00451f, 0);
            }
        }
        if (Up2 == 0)
        {
            if (S2Angle < 34.25f && Up1 == 0)
            {
                S2Angle = S2Angle + .75f;
                SideC.transform.Rotate(-.75f,0,0,Space.Self);

                SideB.transform.localRotation = Quaternion.Euler(-180/Mathf.PI*Mathf.Asin((.38542f*Mathf.Sin(34.25f*Mathf.PI/180)-.38542f*Mathf.Sin(S2Angle*Mathf.PI/180))/.6096f),90,0);

                SideA.transform.localRotation = Quaternion.Euler(-11f+(180/Mathf.PI*Mathf.Asin((2*.38542f*Mathf.Sin(34.25f*Mathf.PI/180)-.38542f*Mathf.Sin(S2Angle*Mathf.PI/180))/.38542f)),90,0);
                SideA.transform.localPosition = new Vector3(0.93882f-.38542f*Mathf.Cos(34.25f*Mathf.PI/180)+.38542f*Mathf.Cos((SideA.transform.eulerAngles.x+11f)*Mathf.PI/180), 0.00451f, 0);
            }
        }
    }
}
