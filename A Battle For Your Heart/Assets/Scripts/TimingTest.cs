using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class TimingTest : MonoBehaviour
{

    public Text score;
    public int scoreValue;
    public int scoreToWin;

    public Text time;
    public float mainTimer = 30;

    public Text successText;
    public string successReadout;
    public GameObject successTextParent;

    public Text missText;
    public string missReadout;
    public GameObject missTextParent;

    public Slider slider;

    bool notPressed;
    public float restartTimerValue = 1.5f;
    float restartTimer = 1.5f;

    public int winRangeMin = 35;
    public int winRangeMax = 60;

    bool goingUp;
    public int sliderSpeed = 2;

    public float sceneTransferTimer = 3;

    public bool testingMode = true;
    public int sceneToTransferTo;

    [SerializeField] UnityEvent scored;
    [SerializeField] UnityEvent miss;
    [SerializeField] UnityEvent clear;

    private void Start()
    {
        score.text = "Score - 0";
    }

    private void Update()
    {
        //If minigame is finished
        if(mainTimer <= 0)
        {
            //Play win/lose text, update HP in do not destroy, and scene transfer to end of class
            if(scoreValue >= scoreToWin)
            {
                successText.text = "WIN!";
                successTextParent.SetActive(true);
            }
            else
            {
                missText.text = "Lose...";
                missTextParent.SetActive(true);
            }


            //If its time to scene transfer
            if(sceneTransferTimer <= 0)
            {
                //If in minigame testing mode reloads scene on win
                if (testingMode)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                //Otherwise loads the scene specified in inspector
                else
                {
                    SceneManager.LoadScene(sceneToTransferTo);
                }
            }
            //Counts down scene transfer as soon as main timers done
            else
            {
                sceneTransferTimer -= Time.deltaTime;
            }

        }
        //If minigame is still going
        else
        {
            //Counts down the minigames timer
            mainTimer -= Time.deltaTime;
            //Updates timer text
            time.text = "Time left: " + Mathf.RoundToInt(mainTimer);


            //Moves the slider when not in pressed mode
            if (notPressed)
            {
                //Moves the slider right
                if (goingUp == true)
                {
                    slider.value += sliderSpeed * Time.deltaTime;
                    if(slider.value == slider.maxValue)
                    {
                        goingUp = false;
                    }
                }
                //Moves the slider left
                if(goingUp == false)
                {
                    slider.value -= sliderSpeed * Time.deltaTime;
                    if(slider.value == slider.minValue)
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
                    if(slider.value < winRangeMax && slider.value > winRangeMin)
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
                if(restartTimer <= 0)
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
}
