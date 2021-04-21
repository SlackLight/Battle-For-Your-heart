using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationToStartOn : MonoBehaviour
{

    Animator anim;

    public string triggerToStartWith;

    private void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetTrigger(triggerToStartWith);
    }

}
