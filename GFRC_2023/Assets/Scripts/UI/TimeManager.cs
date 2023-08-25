using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
public class TimeManager : MonoBehaviour
{
    public TMP_Text timeText;
    public UnityEvent gameOverEvent= new UnityEvent();
    public float timeRemaining = 150.0f;
    public bool gameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver) return;
        timeRemaining -= Time.deltaTime;
        float minutes = Mathf.FloorToInt(timeRemaining / 60);

        float seconds = Mathf.FloorToInt(timeRemaining % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

     if(timeRemaining <= 0.0f ){
        gameOverEvent.Invoke();
        gameOver = true;
     }

    }


}
