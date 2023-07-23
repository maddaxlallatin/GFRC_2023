using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using TMPro;
using static Global;
using DG.Tweening;
using System;
public class LeaderboardManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Textprefab;
    public GameObject rowsObject;
    private GameObject thisPrefab;

    void Start()
    {
        var entries = getDatabaseEntries();
        foreach (var databaseEntry in entries)
        {
            thisPrefab = GameObject.Instantiate(Textprefab);
            thisPrefab.transform.SetParent(rowsObject.transform);
            thisPrefab.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            thisPrefab.transform.GetChild(0).GetChild(0).GetComponent<TMP_Text>().text = databaseEntry.username;
            thisPrefab.transform.GetChild(1).GetChild(0).GetComponent<TMP_Text>().text = databaseEntry.unixtime;
            thisPrefab.transform.GetChild(2).GetChild(0).GetComponent<TMP_Text>().text = databaseEntry.build;
            thisPrefab.transform.GetChild(3).GetChild(0).GetComponent<TMP_Text>().text = databaseEntry.teamnumber;
            thisPrefab.transform.GetChild(4).GetChild(0).GetComponent<TMP_Text>().text = databaseEntry.points + "";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}