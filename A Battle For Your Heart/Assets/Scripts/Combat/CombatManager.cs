using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    Image healthbar;
    Text comboCounter;
    int comboCount = 0;
    [SerializeField] int Strength;
    [SerializeField] int Defence;
    [SerializeField] int Health;
    [SerializeField] int currentHealth;
    [SerializeField] OpponentManager OManager;

    [SerializeField] float outgoingDamage;
    public int incomingDamage;
    [SerializeField] private int AppliedDamage;
    int missedCount = 0;
    int perfectCount = 0;
    int earlyCount = 0;
    int lateCount = 0;
    public string LatestRating;

    // Start is called before the first frame update
    void Awake()
    {
        if (gameObject)
        {
            Defence = StatManager.Stats.Defence;
            Strength = StatManager.Stats.Strength;
            Health = StatManager.Stats.Health;
            currentHealth = Health;
            healthbar = GameObject.Find("Tomomi Health").GetComponent<Image>();
            comboCounter = GameObject.Find("Combo Counter").GetComponent<Text>();
            OManager = FindObjectOfType<OpponentManager>();

            //incomingDamage = GetHashCode enemy stats

        }
    }

    // Update is called once per frame
    void Update()
    {
        healthbar.fillAmount = (float)currentHealth / Health;
        comboCounter.text =( "Combo Count: " + comboCount);


        ////Test Damage
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(Random.Range(1, 20));

        //}



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
        LatestRating = "Perfect!";
      
           incomingDamage = 0;
        perfectCount++;
        AppliedDamage = 0;
        outgoingDamage = Strength;
        comboCount++;
        ResolveDamage();

    }
    public void TooEarly(int inwardDamage)
    {
        LatestRating = "Too Early!";

        comboCount++;
        earlyCount++;
        incomingDamage = inwardDamage;
        incomingDamage = incomingDamage / 4;
        outgoingDamage = Strength / 2;

        CalculateDamage();

    }
    public void TooLate(int inwardDamage)
    {
        LatestRating = "Too Late!";

        comboCount++;
        lateCount++;
        incomingDamage = inwardDamage;
        incomingDamage = incomingDamage / 4;
        outgoingDamage = Strength / 2;
        CalculateDamage();


    }
    public void Missed(int inwardDamage)
    {
        LatestRating = "Miss!";

        incomingDamage = inwardDamage;
        comboCount = 0;
        missedCount++;

        //Health = Health- AppliedDamage; dont do this here
        outgoingDamage = 0;
        CalculateDamage();

    }
    public void ResolveDamage()
    {


        currentHealth = currentHealth - AppliedDamage;
        if (currentHealth <= 0)
        {

        }
        OManager.TakeDamage(outgoingDamage);
    }
}
