using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class NPCTalk : MonoBehaviour
{
    //Sets if the NPC has been talked to already that day or not
    public string talkedToVariableName;

    public List<int> convoIDs;

    public int convoCounter = 0;

    public bool linear;

    bool convoInProgess;

    public bool inTrigger;

    BoxCollider bc;

    public float cooldownTimerStart = 0.1f;
    float cooldownTimer;

    private void Start()
    {
        bc = GetComponent<BoxCollider>();
        cooldownTimer = cooldownTimerStart;
    }

    private void Update()
    {
        //Disables the collider when in a convo
        if (DialogueManager.isConversationActive)
        {
            cooldownTimer = cooldownTimerStart;
            bc.enabled = false;
            inTrigger = false;
        }
        else if(cooldownTimer < 0)
        {
            bc.enabled = true;

            if (Input.GetKeyDown(KeyCode.Space) && inTrigger)
            {
                convoInProgess = NPCManager.instance.convoInProgress;

                if (DialogueManager.masterDatabase.GetConversation(convoIDs[convoCounter]) != null && !convoInProgess)
                {
                    var conversation = DialogueManager.masterDatabase.GetConversation(convoIDs[convoCounter]);
                    DialogueManager.StartConversation(conversation.Title);

                    //Tells the NPC manager convo has been started (reset in the dialogue managers event component)
                    NPCManager.instance.convoInProgress = true;
                }
            }
        }
        else
        {
            cooldownTimer -= Time.deltaTime;
        }

    }

    private void OnTriggerStay(Collider other)
    {
        inTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }
}
