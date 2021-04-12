using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkIn : MonoBehaviour
{
    public GameObject walkTo;
    Vector2 walkToPosition;

    public GameObject spriteToWalkIn;

    public float lerpRatio = 0.01f;

    bool walk = false;

    private void Start()
    {
        walkToPosition = walkTo.transform.position;
    }

    private void Update()
    {
        if (walk && Vector2.Distance(walkToPosition, spriteToWalkIn.transform.position) > 0.1f)
        {
            spriteToWalkIn.transform.position = Vector2.Lerp(spriteToWalkIn.transform.position, walkToPosition, lerpRatio);
            print(Vector2.Lerp(spriteToWalkIn.transform.position, walkToPosition, lerpRatio));
        }
    }

    public void Walk()
    {
        print("tried to wak");
        walk = true;
    }
}
