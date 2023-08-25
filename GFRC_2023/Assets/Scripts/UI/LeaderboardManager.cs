using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using TMPro;
using static Global;
using DG.Tweening;
using UnityEngine.EventSystems;
using System;
public class LeaderboardManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Textprefab;
    public GameObject rowsObject;
    private GameObject thisPrefab;
    public GameObject mainMenu;
    public GameObject ExitButton, StartButton;

    public void OpenLeaderBoard()
    {
        mainMenu.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(ExitButton);
        var entries = getDatabaseEntries();
        GameObject w = GameObject.Instantiate(Textprefab);
        w.transform.SetParent(rowsObject.transform);
        w.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        foreach (var databaseEntry in entries)
        {
            ExitButton.SetActive(false);
            ExitButton.SetActive(true);
            thisPrefab = GameObject.Instantiate(Textprefab);
            thisPrefab.transform.SetParent(rowsObject.transform);
            thisPrefab.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            thisPrefab.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = databaseEntry.username;
            thisPrefab.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = databaseEntry.unixtime;
           // thisPrefab.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = databaseEntry.build;
            thisPrefab.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = databaseEntry.teamnumber;
            thisPrefab.transform.GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = databaseEntry.points + "";
        }
    }

    public void CloseLeaderBoard()
    {
        mainMenu.SetActive(true);
        gameObject.SetActive(false);
        foreach (Transform child in rowsObject.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(StartButton);
        
    }



    // Update is called once per frame
    void Update()
    {

    }

    public void gameOverLeaderboardUpdate(){
        if(username == ""){
            return;
        }

        var entries = getDatabaseEntries();
        for (int i = 0; i < entries.Count; i++)    
        {
            if (entries[i].username.ToLower() == username.ToLower())
            {
                Debug.Log(entries[i].username);
                Debug.Log(entries[i].points);
                if(entries[i].points < points){
                    entries[i].points = points;
                    entries[i].unixtime = DateTime.Now.ToString("hh:mm tt MMMM dd, yyyy") + "";

                }
            
                
            }

        }
        insertDatabaseEntry(entries);
        
    }
}
