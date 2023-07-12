using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using TMPro;
using static Global;
public class SignUpLogInScript : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
//wahstdas d
    public void SignUpClick()
    {
        var entries = getDatabaseEntries();
        foreach (var databaseEntry in entries)
        {
            if (databaseEntry.username == usernameInput.text.ToLower())
            {
                Debug.Log("Username already exists, Attempting Log in");
                if (databaseEntry.password == passwordInput.text)
                {
                    Debug.Log("Log in successful");
                    isSignedIn = true;
                    username = usernameInput.text;
                    return;
                }
                else
                {
                    Debug.Log("Incorrect password");
                    return;
                }
            }

        }
        Debug.Log("Creating new account");
        entries.Add(
            new databaseEntry
            {
                username = usernameInput.text.ToLower(),
                password = passwordInput.text
            }
        );
        insertDatabaseEntry(entries);
        isSignedIn = true;
        username = usernameInput.text;
        Debug.Log("Account created " + username);

    }
}
