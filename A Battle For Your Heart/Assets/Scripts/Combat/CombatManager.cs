using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CombatManager : MonoBehaviour
{
    Image healthbar;
    Text comboCounter;
    [SerializeField] Text ModeText;

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
    public bool AttackMode = false;
    [SerializeField] SpriteRenderer BattleSheet;
    [SerializeField] SpriteRenderer OBattleSheet;
    [SerializeField] SpriteRenderer HeartIcon;
    [SerializeField] Color DefenceColor;
    [SerializeField] Color AttackColor;
    [SerializeField] Color H_DefenceColor;
    [SerializeField] Color H_AttackColor;
    [SerializeField] Color O_DefaultColor;
    [SerializeField] ParticleSystem hurtPart;
    [SerializeField] float hoverDist;
    [SerializeField] Animator Tomomi;



    // Start is called before the first frame update
    void Awake()
    {
        if (gameObject)
        {
            ModeText.text = "Defend";
            OBattleSheet.color = O_DefaultColor;
            HeartIcon.color = H_DefenceColor;
            BattleSheet.color = DefenceColor;
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
        if (AttackMode)
        {
            ModeText.text = "Attack";
            BattleSheet.color = AttackColor;
            HeartIcon.color = H_AttackColor;
            OBattleSheet.color = O_DefaultColor;



        }
        else
        {
            ModeText.text = "Defend";

            BattleSheet.color = DefenceColor;
            HeartIcon.color = H_DefenceColor;
            OBattleSheet.color = AttackColor;

        }
        healthbar.fillAmount = (float)currentHealth / Health;
        if (comboCount > 0) comboCounter.text = (comboCount + " COMBO!");
        else comboCounter.text = null;

        HeartIcon.gameObject.transform.position = new Vector3(HeartIcon.gameObject.transform.position.x, HeartIcon.gameObject.transform.position.y, HeartIcon.gameObject.transform.position.z + hoverDist * Mathf.Sin(Time.time));

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
        LatestRating = "PERFECT!!!";

        incomingDamage = 0;
        perfectCount++;
        AppliedDamage = 0;
        outgoingDamage = Strength;
        comboCount++;
        ResolveDamage();

    }
    public void TooEarly(int inwardDamage)
    {
        LatestRating = "Too Early";

        comboCount++;
        earlyCount++;
        incomingDamage = inwardDamage;
        incomingDamage = incomingDamage / 4;
        outgoingDamage = Strength / 2;

        CalculateDamage();

    }
    public void TooLate(int inwardDamage)
    {
        LatestRating = "Too Late";

        comboCount++;
        lateCount++;
        incomingDamage = inwardDamage;
        incomingDamage = incomingDamage / 4;
        outgoingDamage = Strength / 2;
        CalculateDamage();


    }
    public void Missed(int inwardDamage)
    {
        LatestRating = "Miss";

        incomingDamage = inwardDamage;
        comboCount = 0;
        missedCount++;

        //Health = Health- AppliedDamage; dont do this here
        outgoingDamage = 0;
        CalculateDamage();

    }
    public void ResolveDamage()
    {




        if (AttackMode)
        {
            OManager.TakeDamage(outgoingDamage);

        }
        else
        {
            if (AppliedDamage > 0)
            {
                Tomomi.SetTrigger("Hit");
                hurtPart.Play();
            }
            currentHealth = currentHealth - AppliedDamage;

        }

        if (currentHealth <= 0)
        {
            hurtPart.Play();
            //PLAY DEATH THING HERERERERER

            FindObjectOfType<WinstateManager>().SetLose();
            FindObjectOfType<OpponentManager>().ReturnToScene();


            // Lose the game and load scene immediatly

        }
    }
}
