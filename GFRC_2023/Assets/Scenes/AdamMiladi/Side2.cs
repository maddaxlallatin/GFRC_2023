using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Side2 : MonoBehaviour
{
    public GameObject CPlate;
    public AudioClip Move;
    public int Up2 = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


void OnTriggerEnter(Collider col)
{

if (col.gameObject.name == "col_Wheel")
            {
                Up2++;
            }
if (Up2 == 1)
{
AudioSource.PlayClipAtPoint(Move,CPlate.transform.position, 0.1f);
}
}
void OnTriggerExit(Collider col)
{

if (col.gameObject.name == "col_Wheel")
            {
                Up2--;
            }
}
}

