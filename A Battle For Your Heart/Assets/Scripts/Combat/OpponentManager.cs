using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OpponentManager : MonoBehaviour
{
    public enum Opponents { Shou, Kana, Himeko, Tutorial }
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
    [SerializeField] Text OpponentName;
    [SerializeField] bool testMode;
    
    

    private void Start()
    {
        if (!testMode)
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
        StartUp(opponent);

    }
    public void StartUp(Opponents opponent)
    {


        switch (opponent)
        {
            case Opponents.Shou:

                Strength = 30;
                Defence = 10;
                Health = 100;
                ShouBattle.transform.GetComponentInChildren<NpcSelector>().tag = "Active";

                if (!ShouBattle.activeInHierarchy)
                {
                    ShouBattle.SetActive(true);
                    KanaBattle.SetActive(false);
                    HimekoBattle.SetActive(false);
                    TutorialBattle.SetActive(false);
                    OpponentName.text = "Shou";
                    ShouBattle.transform.GetComponentInChildren<NpcSelector>().CreatePortrait();
                }


                break;
            case Opponents.Kana:
                Strength = 30;
                Defence = 23;
                Health = 100;
                KanaBattle.transform.GetComponentInChildren<NpcSelector>().tag = "Active";

                if (!KanaBattle.activeInHierarchy)
                {
                    ShouBattle.SetActive(false);
                    KanaBattle.SetActive(true);
                    HimekoBattle.SetActive(false);
                    TutorialBattle.SetActive(false);
                    OpponentName.text = "Kana";
                    KanaBattle.transform.GetComponentInChildren<NpcSelector>().CreatePortrait();



                }


                break;
            case Opponents.Himeko:
                Strength = 65;
                Defence = 65;
                Health = 100;
                HimekoBattle.transform.GetComponentInChildren<NpcSelector>().tag = "Active";

                if (!HimekoBattle.activeInHierarchy)
                {
                    ShouBattle.SetActive(false);
                    KanaBattle.SetActive(false);
                    HimekoBattle.SetActive(true);
                    TutorialBattle.SetActive(false);
                    OpponentName.text = "Himeko";
                    HimekoBattle.transform.GetComponentInChildren<NpcSelector>().CreatePortrait();


                }

                break;
            case Opponents.Tutorial:
                Strength = 1;
                Defence = 2;
                Health = 50;
                TutorialBattle.transform.GetComponentInChildren<NpcSelector>().tag = "Active";


                if (!TutorialBattle.activeInHierarchy)
                {
                    ShouBattle.SetActive(false);
                    KanaBattle.SetActive(false);
                    HimekoBattle.SetActive(false);
                    TutorialBattle.SetActive(true);
                    OpponentName.text = "Grunt";
                    TutorialBattle.transform.GetComponentInChildren<NpcSelector>().CreatePortrait();



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
        }
        else if (currentHealth > 0 && SongDone)
        {
            if (opponent == Opponents.Tutorial)
            {
                FindObjectOfType<WinstateManager>().CutscenePlayed();

                FindObjectOfType<WinstateManager>().SetWin();
                ReturnToScene();

            }
            else
            {
                FindObjectOfType<WinstateManager>().CutscenePlayed();

                FindObjectOfType<WinstateManager>().SetLose();
                ReturnToScene();
            }

        }
    }

    public void TakeDamage(float damage)
    {
        float appliedDamage = damage / Defence;

        //if(appliedDamage <= 0)
        //{
        //    appliedDamage = 1;
        //}
        currentHealth = currentHealth - appliedDamage;

    }
    public void ReturnToScene()
    {
        if (opponent == Opponents.Tutorial)
        {
            FindObjectOfType<WinstateManager>().SetWin();

            SceneManager.LoadScene("TutorialCutscene");
        }
        else if (opponent == Opponents.Shou)
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
