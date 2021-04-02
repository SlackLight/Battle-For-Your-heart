using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    bool inTrigger;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) && inTrigger)
        {
            TimeManager.instance.LoadHallwayScene();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        inTrigger = true;
    }
    private void OnTriggerExit(Collider other)
    {
        inTrigger = false;
    }

}
