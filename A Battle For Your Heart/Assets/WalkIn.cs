using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkIn : MonoBehaviour
{
    public GameObject walkTo;
    public GameObject walkOutTo;
    Vector2 walkToPosition;
    Vector2 walkOutPosition;

    public GameObject spriteToWalkIn;

    public float lerpRatio = 0.01f;

    bool walk = false;
    bool walkOut = false;

    private void Start()
    {
        walkToPosition = walkTo.transform.position;
        if(walkOutTo == null)
        {
            walkOutTo = null;
        }
        else
        {
        walkOutPosition = walkOutTo.transform.position;
        }

    }

    private void Update()
    {
        if (walk && Vector2.Distance(walkToPosition, spriteToWalkIn.transform.position) > 0.1f)
        {
            spriteToWalkIn.transform.position = Vector2.Lerp(spriteToWalkIn.transform.position, walkToPosition, lerpRatio);
            print(Vector2.Lerp(spriteToWalkIn.transform.position, walkToPosition, lerpRatio));
        }
        if (walkOut && Vector2.Distance(walkOutPosition, spriteToWalkIn.transform.position) > 0.1f)
        {
            spriteToWalkIn.transform.position = Vector2.Lerp(spriteToWalkIn.transform.position, walkOutPosition, lerpRatio);
            print(Vector2.Lerp(spriteToWalkIn.transform.position, walkOutPosition, lerpRatio));
        }
    }

    public void Walk()
    {
        print("tried to wak");
        walk = true;
    }

    public void WalkOut()
    {
        print("tried to wak out");
        walkOut = true;
    }
}
