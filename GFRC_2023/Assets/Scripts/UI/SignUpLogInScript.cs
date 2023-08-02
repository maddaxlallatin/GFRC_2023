using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Mono.Data.Sqlite;
using System.Data;
using TMPro;
using static Global;
using DG.Tweening;
using System;

public class SignUpLogInScript : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public TMP_InputField teamNumberInput;
    public TMP_Text userText;
    public GameObject signUpScreen;
    public GameObject welcomeObejct;
    public GameObject incpasswordObj;

    public GameObject LoginFirstButton, WelcomeFirstButton, InccorrectFirstButton, StartButton;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OpenScreen(){
        signUpScreen.SetActive(true);
        signUpScreen.transform.DOScale(new Vector3(1,1,1), 0.5f);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(LoginFirstButton);
    }
    public void CloseScreen(){
        signUpScreen.transform.DOScale(new Vector3(0,0,0), 0.5f);
        signUpScreen.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(StartButton);


    }

    public void Sucess(){
        userText.text = username + "";
        signUpScreen.transform.DOScale(new Vector3(0f,0f,0f), 0.35f).OnComplete(() => {
           signUpScreen.SetActive(false);
        });
        welcomeObejct.SetActive(true);
        welcomeObejct.transform.DOScale(new Vector3(1,1,1), 0.35f);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(WelcomeFirstButton);             

    }

    public void fail(){
        incpasswordObj.SetActive(true);
        incpasswordObj.transform.DOScale(new Vector3(1,1,1), 0.5f);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(InccorrectFirstButton);
    }
    public void CloseFail(){
        incpasswordObj.transform.DOScale(new Vector3(0,0,0), 0.5f);
        incpasswordObj.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(LoginFirstButton);
    }
//wahstdas d\

    public void CloseWelcome(){
        welcomeObejct.transform.DOScale(new Vector3(0,0,0), 0.5f);
        welcomeObejct.SetActive(false);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(StartButton);
    }
    public void SignUpClick()
    {
        var entries = getDatabaseEntries();
        foreach (var databaseEntry in entries)
        {
            if (databaseEntry.username.ToLower() == usernameInput.text.ToLower())
            {
                Debug.Log("Username already exists, Attempting Log in");
                if (databaseEntry.password == passwordInput.text)
                {
                    Debug.Log("Log in successful");
                    isSignedIn = true;
                    username = databaseEntry.username;
                    Sucess();
                    return;
                }
                else
                {
                    Debug.Log("Incorrect password");
                    fail();
                    return;
                }
            }

        }
        Debug.Log("Creating new account");
        entries.Add(
            new databaseEntry
            {
                username = usernameInput.text,
                password = passwordInput.text,
                points = 0,
                teamnumber = teamNumberInput.text,
                build = "N/A",  
                unixtime = DateTime.Now.ToString("hh:mm tt MMMM dd, yyyy") + ""
            }
        );
        insertDatabaseEntry(entries);
        isSignedIn = true;
        username = usernameInput.text;
        Debug.Log("Account created " + username);
        Sucess();

    }
}
