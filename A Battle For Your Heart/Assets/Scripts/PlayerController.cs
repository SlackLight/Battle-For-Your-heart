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
    private void Start()
    {
        if (PlayerController.instance)
        {
            Destroy(this);
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
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        if (canMove)
        {
            rb.velocity = new Vector3(hInput * hMovementSpeed, 0, vInput * vMovementSpeed);
        }
    }


}
