using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTextAssigner : MonoBehaviour
{
    
    public string interactionText;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            InteractionText.instance.gameObject.SetActive(true);
            
            if(interactionText != null)
            {
                InteractionText.instance.thisText.text = interactionText;
            }
            else
            {
                InteractionText.instance.thisText.text = InteractionText.instance.interactionDefault;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            InteractionText.instance.gameObject.SetActive(false);
        }
    }

}
