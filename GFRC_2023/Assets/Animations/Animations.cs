using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animations : MonoBehaviour
{
    private Animator anim;

    IEnumerator Start()
    {
        anim = GetComponent<Animator>();

        while(true)
        {
            yield return new WaitForSeconds(Random.Range(25,60));

            anim.SetInteger("ActionsIndex", Random.Range(0,5));
            anim.SetTrigger("Actions");
        }
    }


}
