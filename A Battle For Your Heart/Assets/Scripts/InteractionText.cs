using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractionText : MonoBehaviour
{
    public string interactionDefault;

    public static InteractionText instance;

    public Text thisText;

    private void Start()
    {
        if (InteractionText.instance)
        {
            Destroy(gameObject);
        }
        else
        {
            InteractionText.instance = this;
            interactionDefault = thisText.text;
            gameObject.SetActive(false);
        }
    }
}
