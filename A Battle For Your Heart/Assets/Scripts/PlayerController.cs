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

    public SpriteRenderer spriteRenderer;

    public GameObject tomomi;

    public float deadZone = 0.1f;

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
    }

    private void Update()
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

        

        if (hInput > deadZone)
        {
            if(!tomomi.GetComponent<Animator>().GetBool("walking"))
            {
                tomomi.GetComponent<Animator>().SetBool("walking", true);
            }

            tomomi.transform.localScale = new Vector3(-1, tomomi.transform.localScale.y, tomomi.transform.localScale.z);
        }
        else if(hInput < -deadZone)
        {
            if (!tomomi.GetComponent<Animator>().GetBool("walking"))
            {
                tomomi.GetComponent<Animator>().SetBool("walking", true);
            }

            tomomi.transform.localScale = new Vector3(1, tomomi.transform.localScale.y, tomomi.transform.localScale.z);
        }
        else if((hInput > -deadZone && hInput < deadZone) && tomomi.GetComponent<Animator>().GetBool("walking"))
        {
            tomomi.GetComponent<Animator>().SetBool("walking", false);
        }

        if (canMove)
        {
            rb.velocity = new Vector3(hInput * hMovementSpeed, 0, vInput * vMovementSpeed);
        }
    }


}
