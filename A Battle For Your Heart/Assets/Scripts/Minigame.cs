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

    public float minigameResultTime = 3;

    public bool testingMode = false;
    public int sceneToTransferTo;

    public UnityEvent scored;
    public UnityEvent miss;
    public UnityEvent clear;

    public bool gameStillGoing;

    bool won;

    public virtual void Start()
    {
        score.text = "Score : 0";
        successText.text = successReadout;
        testingMode = false;
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
                if (missTextParent.activeSelf)
                {
                    missTextParent.SetActive(false);
                }
                won = true;
            }
            else
            {
                missText.text = "Lose...";
                missTextParent.SetActive(true);
                if (successTextParent.activeSelf)
                {
                    successTextParent.SetActive(false);
                }
                won = false;
            }

            gameStillGoing = false;

            //If its time to scene transfer
            if (minigameResultTime <= 0)
            {
                if (won)
                {
                    MinigameManager.instance.nextMinigame();
                }
                else
                {
                    TimeManager.instance.LoadEndHallwayScene();
                }
            }
            //Counts down scene transfer as soon as main timers done
            else
            {
                minigameResultTime -= Time.deltaTime;
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
