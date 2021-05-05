using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowDirection : MonoBehaviour
{
    public GameObject arrowDown;
    public GameObject arrowLeft;
    public GameObject arrowRight;

    public bool left;
    public bool down;

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Player")
        {
            if (down && !arrowDown.activeSelf)
            {
                arrowDown.SetActive(true);
                arrowLeft.SetActive(false);
                arrowRight.SetActive(false);
            }
            else if (!down)
            {
                if (left && !arrowLeft.activeSelf)
                {
                    arrowDown.SetActive(false);
                    arrowLeft.SetActive(true);
                    arrowRight.SetActive(false);
                }
                else if (!left && !arrowRight.activeSelf)
                {
                    arrowDown.SetActive(false);
                    arrowLeft.SetActive(false);
                    arrowRight.SetActive(true);
                }
            }

            
        }


    }
}
