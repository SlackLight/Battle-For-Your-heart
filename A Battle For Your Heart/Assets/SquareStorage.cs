using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareStorage : MonoBehaviour
{
    public MatchingTest matching;

    public GameObject currentlyStored;

    public GameObject squareParent;

    public int squareNumber;

    public bool alreadyStored;

    Vector3 lastPosition;

    private void Update()
    {
        if(currentlyStored != null)
        {
            lastPosition = currentlyStored.transform.position;
            //if the player moves the object its not stored here anymore
            if (currentlyStored.transform.position != lastPosition)
            {
                currentlyStored = null;
            }
        }
       
    }

    private void OnTriggerStay2D(Collider2D other)
    {

        if(other.gameObject != currentlyStored && !MatchingTest.currentlyPressed)
        {
            foreach (Transform child in squareParent.transform)
            {
                if (child != this.transform && child.GetComponent<SquareStorage>().currentlyStored == other.gameObject)
                {
                    alreadyStored = true;
                }
            }

            if (!alreadyStored)
            {
                //Destroy(currentlyStored);

                currentlyStored = other.gameObject;

                currentlyStored.transform.position = gameObject.transform.position;

                matching.placedList[squareNumber - 1] = currentlyStored;
            }

            alreadyStored = false;
        }
    }

}
