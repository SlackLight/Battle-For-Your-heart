using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    public float cameraFollowDistance;

    public float distanceToPlayerX;

    public Vector3 distance;

    public float lerpSpeed;

    private void FixedUpdate()
    {
        distanceToPlayerX = Mathf.Abs(player.transform.position.x - transform.position.x);

        if (player.transform.position.x > transform.position.x + cameraFollowDistance)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(distanceToPlayerX,0,0), lerpSpeed);
        }
        if (player.transform.position.x < transform.position.x - cameraFollowDistance)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + new Vector3(-distanceToPlayerX, 0, 0), lerpSpeed);
        }
    }
}
