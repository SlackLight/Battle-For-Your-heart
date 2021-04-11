using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[System.Serializable]
public class TimingTest : Minigame
{
    public Slider slider;

    bool notPressed;

    public int winRangeMin = 35;
    public int winRangeMax = 60;

    bool goingUp;
    public int sliderSpeed = 2;

    public override void Update()
    {
        base.Update();

        //If the functionality from minigame means the game is still running
        if (gameStillGoing)
        {
            TimingMinigame();
        }
    }

    public void TimingMinigame()
    {
        //Moves the slider when not in pressed mode
        if (notPressed)
        {
            //Moves the slider right
            if (goingUp == true)
            {
                slider.value += sliderSpeed * Time.deltaTime;
                if (slider.value == slider.maxValue)
                {
                    goingUp = false;
                }
            }
            //Moves the slider left
            if (goingUp == false)
            {
                slider.value -= sliderSpeed * Time.deltaTime;
                if (slider.value == slider.minValue)
                {
                    goingUp = true;
                }
            }

            //Recieves input
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Sets it to pressed
                notPressed = false;

                //If it's in the winning range
                if (slider.value < winRangeMax && slider.value > winRangeMin)
                {
                    scoreValue++;
                    score.text = "Score - " + scoreValue;
                    successTextParent.SetActive(true);
                    scored.Invoke();
                }
                //Otherwise
                else
                {
                    missTextParent.SetActive(true);
                    //Runs everthing in miss unity event
                    miss.Invoke();
                }
            }
        }
        //Otherwise it's pressed
        else
        {
            //If the display win/lose text timers over
            if (restartTimer <= 0)
            {
                //Disable the text
                successTextParent.SetActive(false);
                missTextParent.SetActive(false);
                //Runs everything in the clear unity event
                clear.Invoke();

                //Resets the pressing
                notPressed = true;

                //Resets the restart timer
                restartTimer = restartTimerValue;

                //Reset slider to random value to start
                slider.value = Random.Range(slider.minValue, slider.maxValue);
                goingUp = (Random.value > 0.5f);
            }
            else
            {
                restartTimer -= Time.deltaTime;
            }
        }
    }
}
