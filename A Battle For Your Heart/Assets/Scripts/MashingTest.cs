using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MashingTest : Minigame
{
    public Slider slider;

    bool notResetting;

    public int sliderSpeed = 4;

    //Anim to speed up/slowdown
    public List<Animator> anim;

    public float animSlowdownRate = 0.01f;

    public override void Start()
    {
        base.Start();

        for (int i = 0; i < anim.Count; i++)
        {
           anim[i].speed = 0;
        }
    }

    public override void Update()
    {
        base.Update();

        if (gameStillGoing)
        {
            MashingMinigame();
        }
    }

    public void MashingMinigame()
    {
        //If not in sucess menu
        if (notResetting && Input.GetKeyDown(KeyCode.Space))
        {
            slider.value += sliderSpeed;

            for (int i = 0; i < anim.Count; i++)
            {
                anim[i].speed = 1;
            }

            //If the slider has reached max
            if(slider.value >= slider.maxValue)
            {
                notResetting = false;

                scoreValue++;
                score.text = "Score : " + scoreValue;
                successTextParent.SetActive(true);
                scored.Invoke();
            }
        }
        //Anim needs to be slowed down
        else if (notResetting)
        {
            for (int i = 0; i < anim.Count; i++)
            {
                if ((anim[i].speed -= Time.deltaTime * animSlowdownRate) > 0)
                {
                    anim[i].speed -= Time.deltaTime * animSlowdownRate;
                    print(anim[i].speed);
                }
                else
                {
                    anim[i].speed = 0;
                }
            }
            
        }
        //Else if in sucess menu
        else if(!notResetting)
        {
            if(restartTimer <= 0)
            {
                //Disable the text
                successTextParent.SetActive(false);
                //Runs clear unity event
                clear.Invoke();

                //Sets it back to not resetting
                notResetting = true;

                restartTimer = restartTimerValue;

                slider.value = slider.minValue;
            }
            else
            {
                restartTimer -= Time.deltaTime;
            }
        }

    }
}
