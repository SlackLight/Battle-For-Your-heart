using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InputManager : MonoBehaviour
{
    [SerializeField]Material upArrow, DownArrow, RightArrow, LeftArrow;
    public int EnemyAttack = 8;
    [SerializeField]CombatManager combatManagerRef;
    List<GameObject> tempList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        combatManagerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatManager>();
    }

   
    void Update()
    {
        for (int i = 0; i < tempList.Count; i++)
        {
            //if (bool)
            //{
            //    //check if object in list has specific tags....
            //}
        }
        


        if (name == "HitBox Perfect")
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                DownArrow.color = new Color(DownArrow.color.r, DownArrow.color.g, DownArrow.color.b, 155);

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {

            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {

            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {

            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (tempList.Contains(other.gameObject))
        {
            tempList.Remove(other.gameObject);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            //note here
            if (other.tag == "DownBlock")
            {

                if (gameObject.name == "HitBox Early")
                {
                    combatManagerRef.TooEarly(EnemyAttack);
                    print("Down Early");


                }
                if (gameObject.name == "HitBox Perfect")
                {
                    combatManagerRef.Perfect(EnemyAttack);
                    print("Down Perfect");

                }
                if (gameObject.name == "HitBox Late")
                {
                    combatManagerRef.TooLate(EnemyAttack);
                    print("Down Late");


                }
                // "down +success rating"
            }
        }
        if (other.tag == "LeftBlock")
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                // "Left +success rating"
                if (gameObject.name == "HitBox Early")
                {
                    combatManagerRef.TooEarly(EnemyAttack);
                    print("Left Early");

                }
                if (gameObject.name == "HitBox Perfect")
                {
                    combatManagerRef.Perfect(EnemyAttack);
                    print("Left Perfect");


                }
                if (gameObject.name == "HitBox Late")
                {
                    combatManagerRef.TooLate(EnemyAttack);
                    print("Left Late");


                }
            }
        }
        if (other.tag == "RightBlock")
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                // "Right +success rating"
                if (gameObject.name == "HitBox Early")
                {
                    combatManagerRef.TooEarly(EnemyAttack);
                    print("Right early");

                }
                if (gameObject.name == "HitBox Perfect")
                {
                    combatManagerRef.Perfect(EnemyAttack);
                    print("Right Perfect");

                }
                if (gameObject.name == "HitBox Late")
                {
                    combatManagerRef.TooLate(EnemyAttack);
                    print("Right Late");

                }
            }
        }
        if (other.tag == "UpBlock")
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                // "Down +success rating"
                if (gameObject.name == "HitBox Early")
                {
                    combatManagerRef.TooEarly(EnemyAttack);
                    print("Up Early");

                }
                if (gameObject.name == "HitBox Perfect")
                {
                    combatManagerRef.Perfect(EnemyAttack);
                    print("Up Perfect");

                }
                if (gameObject.name == "HitBox Late")
                {
                    combatManagerRef.TooLate(EnemyAttack);
                    print("Up Late");


                }
            }
        }
        if (this.gameObject.name == "HitBox Miss")
        {
            combatManagerRef.Missed(EnemyAttack);
            print("Missed");
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;

        }

        //checking if note is active
        if (other.GetComponent<ActivationScript>().isEnabled == true)
        {
            tempList.Add(other.gameObject);
        }
            

        
        
    }
}
