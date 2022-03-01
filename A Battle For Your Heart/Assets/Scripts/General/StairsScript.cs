using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PixelCrushers.DialogueSystem;

public class StairsScript : MonoBehaviour
{
    public GameObject otherDoor;
    public GameObject otherDoorSpawnPosition;

    public GameObject player;

    public float cooldownTimer;
    float timerStartValue;

    private void Start()
    {
        timerStartValue = cooldownTimer;
        cooldownTimer = 0;
    }

    private void Update()
    {
        if(cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(cooldownTimer <= 0 && Input.GetKey(KeyCode.Space))
        {
           otherDoor.GetComponent<StairsScript>().cooldownTimer = timerStartValue;
           player.transform.position = otherDoorSpawnPosition.transform.position;
           cooldownTimer = timerStartValue;
           //DialogueManager.StopConversation();
        }
        
    }
}
