using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    [SerializeField]Image healthbar;

    [SerializeField] int Strength;
    [SerializeField] int Defence;
    [SerializeField] int Health;
    [SerializeField] int currentHealth;

    private int outgoingDamage;
    public int incomingDamage;
   [SerializeField] private int AppliedDamage;
    int missedCount = 0;
    int perfectCount = 0;
    int earlyCount = 0;
    int lateCount = 0;
    // Start is called before the first frame update
    void Awake()
    {
        if (gameObject)
        {
            Defence = StatManager.Stats.Defence;
            Strength = StatManager.Stats.Strength;
            Health = StatManager.Stats.Health;
            currentHealth = Health;
            //incomingDamage = GetHashCode enemy stats

        }
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = (float)currentHealth / Health;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(Random.Range(1,20));
            
        }
      


    }
    //temp damage testing
    void TakeDamage(int inwardDamage)
    {
        incomingDamage = inwardDamage;
        CalculateDamage();
       
    }
    private void CalculateDamage()
    {
        AppliedDamage = incomingDamage / Defence;
        ResolveDamage();
    }

    public void Perfect()
    {
        incomingDamage = 0;
        perfectCount++;
        AppliedDamage = 0;
        outgoingDamage = Strength;
        ResolveDamage();

    }
    public void TooEarly(int inwardDamage)
    {
        earlyCount++;
        incomingDamage = inwardDamage;

        incomingDamage = incomingDamage / 4;
        outgoingDamage = Strength/2;

        CalculateDamage();

    }
    public void TooLate(int inwardDamage)
    {
        lateCount++;
        incomingDamage = inwardDamage;

        incomingDamage = incomingDamage / 4;
        outgoingDamage = Strength / 2;
        CalculateDamage();


    }
    public void Missed(int inwardDamage)
    {
        incomingDamage = inwardDamage;

        missedCount++;
       
        //Health = Health- AppliedDamage; dont do this here
        outgoingDamage = 0;
        CalculateDamage();

    }
    public void ResolveDamage()
    {
        print("took " + AppliedDamage + " damage");

        currentHealth = currentHealth - AppliedDamage;
        if (currentHealth <= 0)
        {
            print("oh lord she dead");
        }
    }
}
