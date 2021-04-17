using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;

    public List<GameObject> minigames;

    [SerializeField] int currentMinigame;

    public float strengthIncrease;
    public float healthIncrease;
    public float defenseIncrease;

    float currentStrength;
    float currentHealth;
    float currentDefense;

    public Text strengthText;
    public Text healthText;
    public Text defenseText;

    public GameObject reportCardUIParent;

    public float reportCardTimer;

    private void Start()
    {
        if (MinigameManager.instance)
        {
            Destroy(MinigameManager.instance.gameObject);
            MinigameManager.instance = null;
        }
        MinigameManager.instance = this;

        minigames[currentMinigame].SetActive(true);

        //If statmanager exists assign current values
        if (StatManager.Stats)
        {
            currentDefense = StatManager.Stats.Defence;
            currentHealth = StatManager.Stats.Health;
            currentStrength = StatManager.Stats.Strength;
            defenseIncrease += currentDefense;
            healthIncrease += currentHealth;
            strengthIncrease += currentStrength;
        }
        else
        {
            currentStrength = 0;
            currentHealth = 0;
            currentDefense = 0;
        }
    }

    private void Update()
    {
        if (reportCardUIParent.activeSelf)
        {
            //If strength needs to keep increasing
            if(currentStrength < strengthIncrease)
            {
                currentStrength += Time.deltaTime;
                strengthText.text = ((int)currentStrength).ToString();
                strengthText.color = Color.green;
            }
            else
            {
                currentStrength = strengthIncrease;
            }

            //If defense needs to keep increasing
            if (currentDefense < defenseIncrease)
            {
                currentDefense += Time.deltaTime;
                defenseText.text = ((int)currentDefense).ToString();
                defenseText.color = Color.green;
            }
            else
            {
                currentDefense = defenseIncrease;
            }

            //If health needs to keep increasing
            if (currentHealth < healthIncrease)
            {
                currentHealth += Time.deltaTime;
                healthText.text = ((int)currentHealth).ToString();
                healthText.color = Color.green;
            }
            else
            {
                currentHealth = healthIncrease;
            }

            if (currentStrength == strengthIncrease && currentHealth == healthIncrease && currentDefense == defenseIncrease)
            {
                if (reportCardTimer < 0)
                {
                    //Scene transition
                    TimeManager.instance.LoadEndHallwayScene();
                }
                else
                {
                    reportCardTimer -= Time.deltaTime;
                }
            }
            
        }
    }

    public void nextMinigame()
    {
        if (currentMinigame + 1 == minigames.Count)
        {
            minigames[currentMinigame].SetActive(false);
            reportCard();
        }
        else
        {
            minigames[currentMinigame].SetActive(false);
            currentMinigame++;
            minigames[currentMinigame].SetActive(true);
        }
    }

    public void reportCard()
    {
        //Increase the stats
        if (StatManager.Stats)
        {
            StatManager.Stats.Strength = (int)strengthIncrease;
            StatManager.Stats.Health = (int)healthIncrease;
            StatManager.Stats.Defence = (int)defenseIncrease;
        }
        reportCardUIParent.SetActive(true);
    }

    public void BackToHallway()
    {
        TimeManager.instance.LoadEndHallwayScene();
    }

}
