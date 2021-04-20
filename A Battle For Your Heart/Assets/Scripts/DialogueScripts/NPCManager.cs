using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;
    bool newDay;

    public bool convoInProgress;

    public GameObject NPCHolder;

    //[HideInInspector]
    public List<GameObject> NPCList;

    public GameObject NPCSpawnParent;

    //[HideInInspector]
    public List<Transform> NPCSpawnSpots;

    public GameObject NPCReturnPosition;

    //The weeks of day lists established
    public List<Day> Week1;
    public List<Day> Week1AfterClass;
    public List<Day> Week2;
    public List<Day> Week2AfterClass;
    public List<Day> Week3;
    public List<Day> Week3AfterClass;

    private void Start()
    {
        if (NPCManager.instance)
        {
            Destroy(this.gameObject);
        }
        else
        {
            NPCManager.instance = this;
            DontDestroyOnLoad(this);

            //Assigns the spawn points list
            foreach (Transform child in NPCSpawnParent.transform)
            {
                NPCSpawnSpots.Add(child);
            }

            //Assigns the NPCs to a list
            foreach (Transform child in NPCHolder.transform)
            {
                NPCList.Add(child.gameObject);
            }

            //Moves the NPCs to the despawn point
            for (int i = 0; i < NPCList.Count; i++)
            {
                    NPCList[i].transform.position = NPCReturnPosition.transform.position;
            }

            SpawnTheNPCs();
        }
    }

    //Teleport the NPCs for that day to a random spawnpoint
    public void SpawnTheNPCs()
    {
        //Local copies of the current day and week
        int currentDay = TimeManager.instance.dayCounter;
        int currentWeek = TimeManager.instance.weekCounter;

        List<int> temporaryValues = new List<int>();

        int randomSpawnNumber;

        //Sets the current week
        List<Day> currentWeekList = Week1;
        
        //If it is the morning selects from the lists of morning NPCs
        if (TimeManager.instance.beginningOfDay)
        {
            switch (currentWeek)
            {
                case 1:
                    currentWeekList = Week1;
                    break;
                case 2:
                    currentWeekList = Week2;
                    break;
                case 3:
                    currentWeekList = Week3;
                    break;
            }
        }
        //otherwise selects from the lists of evening NPCs
        else
        {
            switch (currentWeek)
            {
                case 1:
                    currentWeekList = Week1AfterClass;
                    break;
                case 2:
                    currentWeekList = Week2AfterClass;
                    break;
                case 3:
                    currentWeekList = Week3AfterClass;
                    break;
            }
        }
        
        //Checks if there are enough positions to spawn the NPCs
        if (NPCSpawnSpots.Count < currentWeekList[currentDay - 1].list.Count)
        {
            print("Not enough spawn points for the number of NPCs.");
        }
        //If there are NPCs on the current day
        else if (currentWeekList[currentDay - 1].list.Count > 0)
        {
            //For each NPC
            for (int i = 0; i < currentWeekList[currentDay - 1].list.Count; i++)
            {
                //Comesup with a random spawn point to be at
                randomSpawnNumber = Random.Range(0, NPCSpawnSpots.Count);
                //While the spawnpoint already exists comes up with new spawnpoints
                while (temporaryValues.Contains(randomSpawnNumber))
                {
                    randomSpawnNumber = Random.Range(0, NPCSpawnSpots.Count);
                }
                //Adds the value to a for next NPC to check against
                temporaryValues.Add(randomSpawnNumber);
                //Move the NPC to the position
                currentWeekList[currentDay - 1].list[i].transform.position = NPCSpawnSpots[randomSpawnNumber].position;
                foreach (Transform child in currentWeekList[currentDay - 1].list[i].gameObject.transform)
                {
                    if (child.gameObject.tag == "NPCPortrait")
                        child.gameObject.SetActive(true);
                }
            }
        }
    }

    //Moves all the NPCs back to the holding position
    public void DespawnTheNPCs()
    {
        //For every NPC
        for (int i = 0; i < NPCList.Count; i++)
        {
            //If they haven't despawned
            if(!(NPCList[i].transform.position == NPCReturnPosition.transform.position))
            {
                //get the child object with the npctalk component
                NPCTalk npcTalkComp = null;
                foreach (Transform child in NPCList[i].transform)
                {
                    if (child.gameObject.tag != "NPCPortrait")
                        npcTalkComp = child.GetComponent<NPCTalk>();
                }
                //If the NPC being removed is non-linear increment their convo
                if (npcTalkComp.linear == false)
                {
                    npcTalkComp.convoCounter++;
                }

                NPCList[i].transform.position = NPCReturnPosition.transform.position;
                foreach (Transform child in NPCList[i].transform)
                {
                    if (child.gameObject.tag == "NPCPortrait")
                        child.gameObject.SetActive(false);
                }
            }
        }
    }

    //Resets all NPCs already talked to variables
    public void ResetTalkedTo()
    {
        newDay = true;
        foreach (Transform child in NPCHolder.transform)
        {
            foreach (Transform grandchild in child)
            {
                if (grandchild.gameObject.tag != "NPCPortrait")
                    DialogueLua.SetVariable(grandchild.GetComponent<NPCTalk>().talkedToVariableName, false);
            }
            
        }
    }

    public void IncrementLinearNPCs()
    {
        foreach (Transform child in NPCHolder.transform)
        {
            NPCTalk temp = null;
            foreach (Transform grandchild in child)
            {
                    if (grandchild.gameObject.tag != "NPCPortrait")
                    temp = grandchild.GetComponent<NPCTalk>();
            }
            //If it's linear and the talked to variable for this scene is true 
            if (temp.linear == true && DialogueLua.GetVariable(temp.talkedToVariableName).asBool)
            {
                //Add to it's convo counter
                temp.convoCounter++;
            }
        }
    }

    public void EndConversation()
    {
        convoInProgress = false;
    }

}
