using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class CutsceneManager : MonoBehaviour
{
    //Convos to be changed to in order
    public List<int> convoIDsToBeStarted;
    int currentConvo = 0;
    
    [Tooltip("only needed if going to change background")]
    public GameObject currentBackground;

    //Backgrounds to be changed to in order
    public List<GameObject> backgroundPrefabsToChangeTo;
    int backgroundCounter = 0;

    public GameObject backgroundSpawnSpot;


    //Games to be enabled in order
    public List<GameObject> gameParents;
    int currentGameCounter = 0;

    private void Start()
    {
       
            nextConvo();
        
    }

    //Run this to begin the next convo in the list
    public void nextConvo()
    {


        if(currentConvo + 1 <= convoIDsToBeStarted.Count)
        {
            if (FindObjectOfType<WinstateManager>().firstTimeThrough) // intro cutscene
            {
                var conversation = DialogueManager.masterDatabase.GetConversation(convoIDsToBeStarted[currentConvo]);
                DialogueManager.StartConversation(conversation.Title);
                
            }else if (!FindObjectOfType<WinstateManager>().firstTimeThrough && FindObjectOfType<WinstateManager>().win) //if win battle
            {
                currentConvo=1;
                var conversation = DialogueManager.masterDatabase.GetConversation(convoIDsToBeStarted[currentConvo]);
                DialogueManager.StartConversation(conversation.Title);
                FindObjectOfType<WinstateManager>().firstTimeThrough = true;

            }
            else if(!FindObjectOfType<WinstateManager>().firstTimeThrough && !FindObjectOfType<WinstateManager>().win) // if lose battle
            {
                currentConvo = 2;
                var conversation = DialogueManager.masterDatabase.GetConversation(convoIDsToBeStarted[currentConvo]);
                DialogueManager.StartConversation(conversation.Title);
                FindObjectOfType<WinstateManager>().firstTimeThrough = true;
            }
          
        }
        else
        {
            print("Not enough conversations in convoIDsToBeStarted to start another convo.");
        }
        
    }

    public void enableNextGame()
    {
        if(currentGameCounter + 1 <= gameParents.Count)
        {
            gameParents[currentGameCounter].SetActive(true);
            currentGameCounter++;
        }
        else
        {
            print("Not enough games in the gameParents to load another game");
        }
        
    }

    public void transitionBackground()
    {
        if (backgroundCounter + 1 <= backgroundPrefabsToChangeTo.Count)
        {
            currentBackground.SetActive(false);
            Instantiate(backgroundPrefabsToChangeTo[backgroundCounter], backgroundSpawnSpot.transform.position, Quaternion.identity);
            backgroundCounter++;
        }
        else
        {
            print("Not enough backgrounds in background prefabs to change to");
        }
    }
}
