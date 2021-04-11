using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

[System.Serializable]
public class Minigame : MonoBehaviour
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

    public float restartTimerValue = 1.5f;
    public float restartTimer = 1.5f;

    public float sceneTransferTimer = 3;

    public bool testingMode = false;
    public int sceneToTransferTo;

    public UnityEvent scored;
    public UnityEvent miss;
    public UnityEvent clear;

    public bool gameStillGoing;

    public virtual void Start()
    {
        score.text = "Score - 0";
    }

    public virtual void Update()
    {
        //If minigame is finished
        if (mainTimer <= 0)
        {
            //Play win/lose text, update HP in do not destroy, and scene transfer to end of class
            if (scoreValue >= scoreToWin)
            {
                successText.text = "WIN!";
                successTextParent.SetActive(true);
            }
            else
            {
                missText.text = "Lose...";
                missTextParent.SetActive(true);
            }

            gameStillGoing = false;

            //If its time to scene transfer
            if (sceneTransferTimer <= 0)
            {
                //If in minigame testing mode reloads scene on win
                if (testingMode)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                }
                //Otherwise loads the scene specified in inspector
                else
                {
                    TimeManager.instance.LoadEndHallwayScene();
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

            gameStillGoing = true;

        }
    }
}
