using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AnyPortrait;

public class FollowBone : MonoBehaviour
{

    public Vector3 globalTransform;

    public GameObject hand;

    private void Update()
    {
        transform.position = hand.transform.TransformPoint(hand.transform.position);
    }


}
