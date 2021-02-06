using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float hInput;
    public float vInput;

    public bool stunned;

    Rigidbody rb;
    public float hMovementSpeed;
    public float vMovementSpeed;

    bool frontWall;
    bool backWall;

    public Renderer spriteRenderer;
    private void Start()
    {
       rb = this.GetComponent<Rigidbody>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        hInput = Input.GetAxis("Horizontal");
        vInput = Input.GetAxis("Vertical");

        //Checks if currently stunned before moving (should check this also if someone is trying to damage (maybe add an invisible period as well), or if they are trying to attack). 
        if(stunned == false)
        {
            rb.velocity = new Vector3(hInput * hMovementSpeed, 0, vInput * vMovementSpeed);
        }

    }


}
