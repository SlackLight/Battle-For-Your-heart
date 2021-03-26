using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    [SerializeField] int Strength;
    [SerializeField] int Defence;
    [SerializeField] int Health;

    private int outgoingDamage;
    public int incomingDamage;
   [SerializeField] private int AppliedDamage;
    // Start is called before the first frame update
    void Awake()
    {
        if (gameObject)
        {
            Defence = StatManager.Stats.Defence;
            Strength = StatManager.Stats.Strength;
            Health = StatManager.Stats.Health;

            //incomingDamage = GetHashCode enemy stats

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(Random.Range(1,20));
            
        }
      


    }
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

    public void Perfect(int inwardDamage)
    {
        AppliedDamage = 0;
        outgoingDamage = Strength;
        CalculateDamage();

    }
    public void TooEarly(int inwardDamage)
    {
        AppliedDamage = AppliedDamage/4;
        outgoingDamage = Strength/2;

        CalculateDamage();

    }
    public void TooLate(int inwardDamage)
    {
        AppliedDamage = AppliedDamage / 4;
        outgoingDamage = Strength / 2;
        CalculateDamage();


    }
    public void Missed(int inwardDamage)
    {
        //Health = Health- AppliedDamage; dont do this here
        outgoingDamage = 0;
        CalculateDamage();

    }
    public void ResolveDamage()
    {
        Health = Health - AppliedDamage;
        if (Health <= 0)
        {
            print("oh lord she dead");
        }
    }
}
