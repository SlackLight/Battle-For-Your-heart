using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public float hInput;
    public float vInput;

    public bool stunned;

    Rigidbody rb;
    public float hMovementSpeed;
    public float vMovementSpeed;

    bool frontWall;
    bool backWall;

    public bool canMove = true;

    public Renderer spriteRenderer;
    private void Awake()
    {
        if (PlayerController.instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            PlayerController.instance = this;
        }
        rb = this.GetComponent<Rigidbody>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if (NPCManager.instance.convoInProgress)
        {
            canMove = false;
            rb.velocity = Vector3.zero;
        }
        else
        {
            canMove = true;
        }

        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if (canMove)
        {
            rb.velocity = new Vector3(hInput * hMovementSpeed, 0, vInput * vMovementSpeed);
        }
    }


}
