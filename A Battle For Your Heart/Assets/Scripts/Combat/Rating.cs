using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Rating : MonoBehaviour
{
    CombatManager managerRef;
    Text myText;
    int ratings=0;

    // Start is called before the first frame update
    void Awake()
    {
        myText = GetComponent<Text>();
        managerRef = FindObjectOfType<CombatManager>();
       

    }

    // Update is called once per frame
    void Update()
    {
        myText.text = managerRef.LatestRating;
        if (managerRef.LatestRating == "Perfect!")
        {
            
            myText.color = Color.yellow;

        }
        else if (managerRef.LatestRating == "Too Early!")
        {
            myText.color = Color.white;
        }
        else if (managerRef.LatestRating == "Too Late!")
        {
            myText.color = Color.white;
        }
        else if (managerRef.LatestRating == "Miss!")
        {
            myText.color = Color.black;
        }
    }
}
