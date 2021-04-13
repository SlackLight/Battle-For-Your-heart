using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MashingTest : Minigame
{
    public Slider slider;

    bool notResetting;

    public int sliderSpeed = 4;

    public override void Start()
    {
        base.Start();
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
