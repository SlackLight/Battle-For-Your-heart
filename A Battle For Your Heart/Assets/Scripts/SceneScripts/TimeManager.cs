﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public int dayCounter = 0;
    public int weekCounter = 1;
    public int nextWeekCount;
    
    public int hallWaySceneID;
    public int hallWayEndOfDayID;
    public int currentClassroom;
    public List<GameObject> classRoomSpawnLocations;
    public bool toBeSpawned;
    public GameObject playerPrefab;
    public GameObject player;

    public bool beginningOfDay = true;

    public int endingScene;

    //In order of appearance
    public List<int> bossFightSceneID;

    public int weekLength;

    private void Awake()
    {
        //Checks it it exists and assigns it if not
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
            dayCounter = 1;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {
        if(toBeSpawned == true && SceneManager.GetActiveScene().name == "EndOfDayHallway")
        {
            toBeSpawned = false;
            //Make a new player character at the door
            player = PlayerController.instance.gameObject;
            player.transform.position = classRoomSpawnLocations[currentClassroom - 1].transform.position;
        }
    }

    public void LoadClassMinigame(string sceneToLoad, int classRoomNumber)
    {   //Increment the NPCs convo changes from the hallway scene
        NPCManager.instance.IncrementLinearNPCs();

        //Sets current classroom for return spawn
        currentClassroom = classRoomNumber;
        SceneManager.LoadScene(sceneToLoad);
        NPCManager.instance.DespawnTheNPCs();
        NPCManager.instance.enabled = false;
    }

    public void LoadHallwayScene()
    {
        beginningOfDay = true;
        //Increment the NPCs convo changes from the hallway end scene
        //NPCManager.instance.IncrementLinearNPCs();
        //If the final boss fight is done load the final scene
        if (weekCounter == 4)
        {
            dayCounter++;
            NPCManager.instance.DespawnTheNPCs();
            SceneManager.LoadScene(endingScene);
        }
        //Checks if it should be loading a bossfight
        else if (dayCounter == (weekCounter) * weekLength)
        {
            weekCounter++;
            dayCounter = 1;
            NPCManager.instance.DespawnTheNPCs();
            SceneManager.LoadScene(bossFightSceneID[weekCounter - 1]);
        }
        else
        {
            dayCounter++;
            SceneManager.LoadScene(hallWaySceneID);
            //Resets all the talked to variables for the scene
            NPCManager.instance.SpawnTheNPCs();
            NPCManager.instance.ResetTalkedTo();
        }
    }

    public void LoadEndHallwayScene()
    {
        beginningOfDay = false;
        SceneManager.LoadScene(hallWayEndOfDayID);
        toBeSpawned = true;
        //Resets all the talked to variables for the scene
        NPCManager.instance.SpawnTheNPCs();
        NPCManager.instance.ResetTalkedTo();
    }

}