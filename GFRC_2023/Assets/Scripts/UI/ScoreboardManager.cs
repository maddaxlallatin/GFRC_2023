using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Global;
using TMPro;
public class ScoreboardManager : MonoBehaviour
{
    // Start is called before the first frame update

    public TMP_Text pointsText;
    public TMP_Text rankPointsText;
    public TMP_Text nameText;
    void Start()
    {
        nameText.text = username==""?"Guest":username;
        pointsText.text = points.ToString();
        //rankPointsText.text = rankPoints.ToString(); RANKING POINTS DONT EXIST YET
    }

    // Update is called once per frame
    void Update()
    {
        pointsText.text = points.ToString();
    }
}
