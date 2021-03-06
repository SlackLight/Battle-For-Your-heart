using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{

    [SerializeField] int Strenght;
    [SerializeField] int Defence;
    [SerializeField] int Health;

    private int outgoingDamage;
    public int incomingDamage;
    private int AppliedDamage;
    // Start is called before the first frame update
    void Awake()
    {
        if (gameObject)
        {
            Defence = StatManager.Stats.Defence;
            Strenght = StatManager.Stats.Strenght;
            Health = StatManager.Stats.Health;

            //incomingDamage = GetHashCode enemy stats

        }
    }

    // Update is called once per frame
    void Update()
    {
        CalculateDamage();
        if(Health <= 0)
        {
            print("oh lord she dead");
        }


    }
    private void CalculateDamage()
    {
        AppliedDamage = incomingDamage / Defence;
        StartCoroutine(ResolveDamage());
    }

    public void Perfect()
    {
        AppliedDamage = 0;
        outgoingDamage = Strenght;
    }
    public void TooEarly()
    {
        AppliedDamage = AppliedDamage/4;
        outgoingDamage = Strenght/2;


    }
    public void TooLate()
    {
        AppliedDamage = AppliedDamage / 4;
        outgoingDamage = Strenght / 2;


    }
    public void Missed()
    {
        //Health = Health- AppliedDamage; dont do this here
        outgoingDamage = 0;

    }
    IEnumerator ResolveDamage()
    {
        Health = Health - AppliedDamage;
         return null;
    }
}
