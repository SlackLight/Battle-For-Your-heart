using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentManager : MonoBehaviour
{
    public enum Opponents { Shou, Kana, Himeko }
    public Opponents opponent;
    [SerializeField] Opponents currentOppopnent;
    public int Strength;
    public int Defence;
    public int Health;
    [SerializeField] float currentHealth;
    [SerializeField] Image healthBar;

    [SerializeField] GameObject ShouBattle;
    [SerializeField] GameObject KanaBattle;
    [SerializeField] GameObject HimekoBattle;
    public bool WinSet;


    private void start()
    {

        if (TimeManager.instance.dayCounter == 1)
        {

        }
        else if (TimeManager.instance.weekCounter == 1)
        {
            opponent = Opponents.Shou;

        }
        else if (TimeManager.instance.weekCounter == 2)
        {
            opponent = Opponents.Kana;

        }
        else if (TimeManager.instance.weekCounter == 3)
        {
            opponent = Opponents.Himeko;

        }
    }
    public void StartUp(Opponents opponent)
    {


        switch (opponent)
        {
            case Opponents.Shou:

                Strength = 30;
                Defence = 10;
                Health = 100;

                if (!ShouBattle.activeInHierarchy)
                {
                    ShouBattle.SetActive(true);
                    KanaBattle.SetActive(false);
                    HimekoBattle.SetActive(false);
                }


                break;
            case Opponents.Kana:
                Strength = 30;
                Defence = 60;
                Health = 100;

                if (!KanaBattle.activeInHierarchy)
                {
                    ShouBattle.SetActive(false);
                    KanaBattle.SetActive(true);
                    HimekoBattle.SetActive(false);
                }


                break;
            case Opponents.Himeko:
                Strength = 75;
                Defence = 75;
                Health = 100;

                if (!HimekoBattle.activeInHierarchy)
                {
                    ShouBattle.SetActive(false);
                    KanaBattle.SetActive(false);
                    HimekoBattle.SetActive(true);
                }

                break;




        }
        currentOppopnent = opponent;
        currentHealth = Health;
        FindObjectOfType<InputManager>().EnemyAttack = Strength;



    }

    // Update is called once per frame
    void Update()
    {//update stats if they dont match the selected opponent

        healthBar.fillAmount = currentHealth / Health;

        if (currentOppopnent != opponent || Health == 0)
        {
            StartUp(opponent);


        }

        if (currentHealth <= 0 && WinSet)
        {
            //Display Winstuff here
            //win battle but finnish song first
        }
    }

    public void TakeDamage(float damage)
    {
        float appliedDamage = damage / Defence;
        print(appliedDamage);
        //if(appliedDamage <= 0)
        //{
        //    appliedDamage = 1;
        //}
        currentHealth = currentHealth - appliedDamage;

    }

}
