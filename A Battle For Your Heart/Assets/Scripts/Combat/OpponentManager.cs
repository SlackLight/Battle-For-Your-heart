using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpponentManager : MonoBehaviour
{
    public enum Opponents { Shou, Kana, Himeko }
    public Opponents opponent;
    Opponents currentOppopnent;
    public int Strength;
    public int Defence;
    public int Health;
   [SerializeField]int currentHealth;
    [SerializeField] Image healthBar;
    [SerializeField] InputManager input;

    public static OpponentManager _OpponentManager;
    public static OpponentManager OManager
    {
        get
        {
            if (_OpponentManager == null)
            {
                _OpponentManager = GameObject.FindObjectOfType<OpponentManager>();
            }

            return _OpponentManager;
        }

    }
    private void start()
    {

        


        if (TimeManager.instance.weekCounter == 1)
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

                break;
            case Opponents.Kana:
                Strength = 30;
                Defence = 60;
                Health = 100;
                break;
            case Opponents.Himeko:
                Strength = 75;
                Defence = 75;
                Health = 100;
                break;




        }
        currentOppopnent = opponent;
        currentHealth = Health;
        for (int i = 0; i < FindObjectsOfType<InputManager>().Length; i++)
        {
            FindObjectsOfType<InputManager>()[i].EnemyAttack = Strength;
        }


    }
 
    // Update is called once per frame
    void Update()
    {//update stats if they dont match the selected opponent

        healthBar.fillAmount = (float)currentHealth /(float)Health ;

        if (currentOppopnent != opponent ||Health==0)
        {
            StartUp(opponent);
            

        }

        if (currentHealth <= 0)
        {
            
            //win battle but finnish song first
        }
    }

    public void TakeDamage (int damage)
    {
        int appliedDamage = damage / Defence;
        currentHealth = currentHealth - appliedDamage;
        
    }

}
