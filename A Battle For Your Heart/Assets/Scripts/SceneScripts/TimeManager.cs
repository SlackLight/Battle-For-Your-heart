using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using PixelCrushers.DialogueSystem;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;

    public int dayCounter = 0;
    public int weekCounter = 1;
    public int nextWeekCount;
    
    public string hallWaySceneName;
    public string hallWayEndOfDayName;
    public int currentClassroom;
    public List<GameObject> classRoomSpawnLocations;
    public bool toBeSpawned;
    public GameObject playerPrefab;
    public GameObject player;

    public bool beginningOfDay = true;

    public int endingScene;

    public int weekLength;

    [Tooltip("Put the cutscenes in order of appearance here")]
    public List<string> cutsceneSceneNames;

    private void Awake()
    {
        //Checks it it exists and assigns it if not
        if(TimeManager.instance == null)
        {
            TimeManager.instance = this;
            DontDestroyOnLoad(this);
            dayCounter = 1;
        }
        else
        {
            Destroy(this.gameObject);
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

        DialogueManager.StopConversation();

        //Sets current classroom for return spawn
        currentClassroom = classRoomNumber;
        SceneManager.LoadScene(sceneToLoad);
        //Turns of the interaction text
        InteractionText.instance.gameObject.SetActive(false);
        NPCManager.instance.DespawnTheNPCs();
        NPCManager.instance.enabled = false;
    }

    public void LoadHallwayScene()
    {
        //Increment the NPCs convo changes from the hallway scene
        NPCManager.instance.IncrementLinearNPCs();

        NPCManager.instance.DespawnTheNPCs();

        InteractionText.instance.gameObject.SetActive(false);

        beginningOfDay = true;
  
        if (dayCounter == (weekCounter) * weekLength && weekCounter < 4)
        {
            if(weekCounter == 1)
            {
                SceneManager.LoadScene("ShouCutscenes");
            }
            else if (weekCounter == 2)
            {
                SceneManager.LoadScene("KanaCutscenes");
            }else if (weekCounter == 3)
            {
                SceneManager.LoadScene("HimekoCutscenes");
            }
            weekCounter++;
            dayCounter = 1;

            //SceneManager.LoadScene(cutsceneSceneNames[weekCounter]);
        }
        else
        {
            dayCounter++;
            SceneManager.LoadScene(hallWaySceneName);
            //Resets all the talked to variables for the scene
            NPCManager.instance.SpawnTheNPCs();
            NPCManager.instance.ResetTalkedTo();
        }
    }

    public void LoadEndHallwayScene()
    {
        beginningOfDay = false;
        SceneManager.LoadScene(hallWayEndOfDayName);
        toBeSpawned = true;
        //Resets all the talked to variables for the scene
        NPCManager.instance.SpawnTheNPCs();
        NPCManager.instance.ResetTalkedTo();
    }

}
