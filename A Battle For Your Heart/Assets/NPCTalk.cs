using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class NPCTalk : MonoBehaviour
{
    //Sets if the NPC has been talked to already that day or not
    public string talkedToVariableName;

    public List<int> convoIDs;

    public int convoCounter;

    public bool linear;

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            //Turns off collider
            GetComponent<Collider>().enabled = false;
        }    
    }

}
