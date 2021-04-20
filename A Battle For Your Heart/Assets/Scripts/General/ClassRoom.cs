using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRoom : MonoBehaviour
{
    //Put in 3 in order
    public List<string> sceneNamesToBeLoadedForEachWeek;

    //Starts at 1 in bottom left
    public int classRoomNumber;

    public int difficultyLevel;

    public bool active;

    public SpriteRenderer sr;
    public BoxCollider bc;

    bool inTrigger;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider>();
        if (!active)
        {
            NotActive();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && inTrigger)
        {
            TimeManager.instance.LoadClassMinigame(sceneNamesToBeLoadedForEachWeek[TimeManager.instance.weekCounter - 1], classRoomNumber);
        }
    }

    public void NotActive()
    {
        //sr.color = Color.black;
        bc.enabled = false;
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
