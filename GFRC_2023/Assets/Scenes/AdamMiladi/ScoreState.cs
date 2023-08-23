using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreState : MonoBehaviour
{
    public List<GameObject> RCu3;
    public List<GameObject> RCu2;
    public List<GameObject> RCo3;
    public List<GameObject> RCo2;
    public List<GameObject> BCu3;
    public List<GameObject> BCu2;
    public List<GameObject> BCo3;
    public List<GameObject> BCo2;
    public List<GameObject> RM;
    public List<GameObject> BM;

    public List<GameObject> FindRCu3()
    {
    for (int i = 0; i < RCu3.Count; i++)
    {
        if (RCu3[i].tag == "Full")
        {
            RCu3.Remove(RCu3[i]);
        }
    }
    return RCu3;
    }
        public List<GameObject> FindBCu3()
    {
    for (int i = 0; i < BCu3.Count; i++)
    {
        if (BCu3[i].tag == "Full")
        {
            BCu3.Remove(BCu3[i]);
        }
    }
    return BCu3;
    }
        public List<GameObject> FindRCu2()
    {
    for (int i = 0; i < RCu2.Count; i++)
    {
        if (RCu2[i].tag == "Full")
        {
            RCu2.Remove(RCu2[i]);
        }
    }
    return RCu2;
    }
        public List<GameObject> FindBCu2()
    {
    for (int i = 0; i < BCu2.Count; i++)
    {
        if (RCu2[i].tag == "Full")
        {
            BCu2.Remove(BCu2[i]);
        }
    }
    return BCu2;
    }


    void Start()
    {
        
    }

}
