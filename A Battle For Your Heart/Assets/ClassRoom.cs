using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassRoom : MonoBehaviour
{

    public string sceneIDToBeLoaded;
    //Starts at 1 in bottom left
    public int classRoomNumber;

    public int difficultyLevel;

    public bool active;

    public SpriteRenderer sr;
    public BoxCollider bc;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        bc = GetComponent<BoxCollider>();
        if (!active)
        {
            NotActive();
        }
    }

    public void NotActive()
    {
        sr.color = Color.black;
        bc.enabled = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TimeManager.instance.LoadClassMinigame(sceneIDToBeLoaded, classRoomNumber);
        }
    }

}
