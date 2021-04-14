using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpponentManager : MonoBehaviour
{
    public enum Opponents { Shou, Kana, Himeko,Tutorial }
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
    [SerializeField] GameObject TutorialBattle;
    public bool SongDone;


    private void Start()
    {
        if (TimeManager.instance == null)
        {
            opponent = Opponents.Tutorial;
        }
        else if (TimeManager.instance.weekCounter == 2)
        {
            opponent = Opponents.Shou;

        }
        else if (TimeManager.instance.weekCounter == 3)
        {
            opponent = Opponents.Kana;

        }
        else if (TimeManager.instance.weekCounter == 4)
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
                    TutorialBattle.SetActive(false);
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
                    TutorialBattle.SetActive(false);

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
                    TutorialBattle.SetActive(false);

                }

                break;
            case Opponents.Tutorial:
                Strength = 0;
                Defence = 5;
                Health = 100;

                if (!TutorialBattle.activeInHierarchy)
                {
                    ShouBattle.SetActive(false);
                    KanaBattle.SetActive(false);
                    HimekoBattle.SetActive(false);
                    TutorialBattle.SetActive(true);

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

        if (currentHealth <= 0 && SongDone)
        {
            FindObjectOfType<WinstateManager>().CutscenePlayed();
            FindObjectOfType<WinstateManager>().SetWin();
            ReturnToScene();



            //Display Winstuff here
            //win battle but finnish song first
        }else if(currentHealth> 0 && SongDone &&opponent !=Opponents.Tutorial)
        {
            FindObjectOfType<WinstateManager>().SetLose();
            ReturnToScene();
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
    void ReturnToScene()
    {
        if (opponent == Opponents.Tutorial)
        {
            FindObjectOfType<WinstateManager>().SetWin();

            SceneManager.LoadScene("TutorialCutscene");
        }
        else if(opponent== Opponents.Shou)
        {
            SceneManager.LoadScene("ShouCutscenes");
        }
        else if (opponent == Opponents.Kana)
        {
            SceneManager.LoadScene("KanaCutscenes");
        }
        else if (opponent == Opponents.Himeko)
        {
            SceneManager.LoadScene("HimekoCutscenes");
        }
        else
        {

        }

    }

}
