using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System;

public static class Global
{

    //Database Managers
    const string databaseName = "URI=file:Assets/Database/GFRC2023Database.db";
    const string databaseLayout = "users (username VARCHAR(16), password VARCHAR(16), points INT, teamnumber VARCHAR(16), build VARCHAR(16), unixtime VARCHAR(16));";
    private const string DB_TABLE_LAYOUT = "users (username VARCHAR(16), pin VARCHAR(4), teamnumber VARCHAR(16), points INT, build VARCHAR(16), unixtime VARCHAR(16));";

    public static bool[] redcRowArray = new bool[] {false, false, false, false, false, false, false, false, false };
    public static bool[] redbRowArray = new bool[] {false, false, false, false, false, false, false, false, false };
    public static bool[] redaRowArray = new bool[] {false, false, false, false, false, false, false, false, false };
    public static bool[] bluecRowArray = new bool[] {false, false, false, false, false, false, false, false, false };
    public static bool[] bluebRowArray = new bool[] {false, false, false, false, false, false, false, false, false };
    public static bool[] blueaRowArray = new bool[] {false, false, false, false, false, false, false, false, false };


    public static bool isSignedIn = false;
    public static string username = "";
    public static int points = 0;
    public static int redlinks = 0;
    public static int bluelinks = 0;

    public static string driveTrain;
    public static string manipulator;
    public static string shape;

    public class databaseEntry
    {
        public string username;
        public string password;
        public int points;
        public string teamnumber;
        public string build;
        public string unixtime;
    }

    static public List<databaseEntry> getDatabaseEntries()
    {
    
        var list = new List<databaseEntry>();
        using (var connection = new SqliteConnection(databaseName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "CREATE TABLE IF NOT EXISTS " + databaseLayout + ";\n";
                command.ExecuteNonQuery();

                command.CommandText = "SELECT * FROM users;";
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add
                        (
                            new databaseEntry
                            {
                                username = reader["username"].ToString(),
                                password = reader["password"].ToString(),
                                points = int.Parse(reader["points"].ToString()),
                                teamnumber = reader["teamnumber"].ToString(),
                                build = reader["build"].ToString(),
                                unixtime = reader["unixtime"].ToString(),

                            }
                        );
                    }
                    reader.Close();
                }
            }
            connection.Close();


        }
        return list;
    }



    public static void insertDatabaseEntry(List<databaseEntry> entries)
    {
        using (var connection = new SqliteConnection(databaseName))
        {
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "DROP TABLE IF EXISTS users;\nCREATE TABLE " + databaseLayout + ";\n";
                command.ExecuteNonQuery();

                foreach (var entry in entries)
                {
                    command.CommandText =
                        "INSERT INTO users (username, password, points, teamnumber, build, unixtime) VALUES\n" +
                            "(" +
                                "\"" + entry.username + "\", " +
                                "\"" + entry.password + "\", " +
                                "\"" + entry.points + "\", " +
                                "\"" + entry.teamnumber + "\", " +
                                "\"" + entry.build + "\", " +
                                "\"" + entry.unixtime + "\");\n";
                    command.ExecuteNonQuery();
                }
            }
            connection.Close();
        }
    }
}
