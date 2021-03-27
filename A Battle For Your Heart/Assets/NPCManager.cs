using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class NPCManager : MonoBehaviour
{
    public static NPCManager instance;
    bool newDay;

    private void Start()
    {
        if (NPCManager.instance)
        {
            Destroy(this);
        }
        else
        {
            NPCManager.instance = this;
            DontDestroyOnLoad(this);
        }
    }

    //Need to implement a storage system where we can setup which NPCS we want to spawn each day (Maybe a dictionary of lists?)
    public void SpawnTheNPCs()
    {

    }


    public void ResetTalkedTo()
    {
        newDay = true;
        foreach (Transform child in transform)
        {
            DialogueLua.SetVariable(child.GetComponent<NPCTalk>().talkedToVariableName, false);
        }
    }


}
