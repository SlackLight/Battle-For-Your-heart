using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    [SerializeField] Material UpArrow, DownArrow, RightArrow, LeftArrow;
    public int EnemyAttack = 8;
    [SerializeField] CombatManager combatManagerRef;

    [SerializeField] List<GameObject> DownNoteList = new List<GameObject>();
    [SerializeField] List<GameObject> UpNoteList = new List<GameObject>();
    [SerializeField] List<GameObject> LeftNoteList = new List<GameObject>();
    [SerializeField] List<GameObject> RightNoteList = new List<GameObject>();
    [SerializeField] bool leftAvailable;
    [SerializeField] bool rightAvailable;
    [SerializeField] bool upAvailable;
    [SerializeField] bool downAvailable;
    [SerializeField] GameObject perfect;
    [SerializeField] GameObject late;

   
    

    // Start is called before the first frame update
    void Start()
    {
        combatManagerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatManager>();
        DownArrow.DisableKeyword("_EMISSION");
        RightArrow.DisableKeyword("_EMISSION");
        LeftArrow.DisableKeyword("_EMISSION");
        UpArrow.DisableKeyword("_EMISSION");
        


    }

    IEnumerator DownPress()
    {
        DownArrow.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(.1f);
        DownArrow.DisableKeyword("_EMISSION");
    }
    IEnumerator UpPress()
    {
        UpArrow.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(.1f);
        UpArrow.DisableKeyword("_EMISSION");
    }
    IEnumerator RightPress()
    {
        RightArrow.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(.1f);
        RightArrow.DisableKeyword("_EMISSION");
    }
    IEnumerator LeftPress()
    {
        LeftArrow.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(.1f);
        LeftArrow.DisableKeyword("_EMISSION");
    }

    void Update()
    {//visuals for buttons
        if (name == "HitBox Perfect")
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
                StartCoroutine("DownPress");
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                StartCoroutine("UpPress");

            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                StartCoroutine("LeftPress");

            }
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                StartCoroutine("RightPress");

            }
        }
        //INPUTS
        if (leftAvailable)
            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            {
                if (late.GetComponent<InputManager>().leftAvailable)
                {
                    late.GetComponent<InputManager>().LeftNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    late.GetComponent<InputManager>().LeftNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    late.GetComponent<InputManager>().LeftNoteList.RemoveAt(0);
                    late.GetComponent<InputManager>().leftAvailable = false;
                    combatManagerRef.TooLate(EnemyAttack);

                }
                else if (gameObject.name == "HitBox Early")
                {
                    combatManagerRef.TooEarly(EnemyAttack);

                    //print("Left Early");

                }
                else if (gameObject.name == "HitBox Perfect")
                {
                    combatManagerRef.Perfect();
                    //print("Left Perfect");


                }
                else if (gameObject.name == "HitBox Late")
                {
                    combatManagerRef.TooLate(EnemyAttack);
                    //print("Left Late");


                }
            }
        if (rightAvailable)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            {
                if (late.GetComponent<InputManager>().rightAvailable)
                {
                    late.GetComponent<InputManager>().RightNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    late.GetComponent<InputManager>().RightNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    late.GetComponent<InputManager>().RightNoteList.RemoveAt(0);
                    late.GetComponent<InputManager>().rightAvailable = false;
                    combatManagerRef.TooLate(EnemyAttack);

                }
                else if (gameObject.name == "HitBox Early")
                {
                    RightNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    RightNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    RightNoteList.RemoveAt(0);
                    rightAvailable = false;
                    combatManagerRef.TooEarly(EnemyAttack);
                    //print("Right early");

                }
                else if (gameObject.name == "HitBox Perfect")
                {
                    RightNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    RightNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    RightNoteList.RemoveAt(0);
                    rightAvailable = false;
                    combatManagerRef.Perfect();
                    //print("Right Perfect");

                }
                else if (gameObject.name == "HitBox Late")
                {
                    RightNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    RightNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    RightNoteList.RemoveAt(0);
                    rightAvailable = false;
                    combatManagerRef.TooLate(EnemyAttack);
                    //print("Right Late");

                }
            }
        }
        if (downAvailable)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
            {
              
                if (late.GetComponent<InputManager>().downAvailable)
                {
                    late.GetComponent<InputManager>().DownNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    late.GetComponent<InputManager>().DownNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    late.GetComponent<InputManager>().DownNoteList.RemoveAt(0);
                    late.GetComponent<InputManager>().downAvailable = false;
                    combatManagerRef.TooLate(EnemyAttack);

                }
                else if(gameObject.name == "HitBox Early")
                {
                    DownNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    DownNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    DownNoteList.RemoveAt(0);
                    downAvailable = false;
                    combatManagerRef.TooEarly(EnemyAttack);
                }

                else if (gameObject.name == "HitBox Perfect")
                {
                    DownNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    DownNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    DownNoteList.RemoveAt(0);
                    downAvailable = false;
                    combatManagerRef.Perfect();
                    //print("Down Perfect");
                }
                else if (gameObject.name == "HitBox Late")
                {
                    DownNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    DownNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    DownNoteList.RemoveAt(0);
                    downAvailable = false;
                    combatManagerRef.TooLate(EnemyAttack);
                    //print("Down Late");
                }

            }
        }
        if (upAvailable)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                if (late.GetComponent<InputManager>().upAvailable)
                {
                    late.GetComponent<InputManager>().UpNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    late.GetComponent<InputManager>().UpNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    late.GetComponent<InputManager>().UpNoteList.RemoveAt(0);
                    late.GetComponent<InputManager>().upAvailable = false;
                    combatManagerRef.TooLate(EnemyAttack);

                }

                else if (gameObject.name == "HitBox Early")
                {
                    UpNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    UpNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    UpNoteList.RemoveAt(0);
                    upAvailable = false;
                    combatManagerRef.TooEarly(EnemyAttack);
                    //print("Up Early");

                }
                else if (gameObject.name == "HitBox Perfect")
                {
                    UpNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    UpNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    UpNoteList.RemoveAt(0);
                    upAvailable = false;
                    combatManagerRef.Perfect();
                    //print("Up Perfect");

                }
                else if (gameObject.name == "HitBox Late")
                {
                    UpNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                    UpNoteList[0].gameObject.GetComponent<MeshRenderer>().enabled = false;
                    UpNoteList.RemoveAt(0);
                    upAvailable = false;
                    combatManagerRef.TooLate(EnemyAttack);
                    //print("Up Late");


                }
            }
        }
        //REMOVE FROM THIS LIST IF OVERLAPPING WITH LATER LIST

        if (name == "HitBox Early")
        {
            if (UpNoteList.Count != 0)
            {
                if (perfect.GetComponent<InputManager>().UpNoteList.Contains(UpNoteList[0].gameObject))
                {
                    UpNoteList.RemoveAt(0);
                    upAvailable = false;
                }
            }
            if (DownNoteList.Count != 0)
            {
                if (perfect.GetComponent<InputManager>().DownNoteList.Contains(DownNoteList[0].gameObject))
                {
                    DownNoteList.RemoveAt(0);
                    downAvailable = false;
                }
            }
            if (LeftNoteList.Count != 0)
            {
                if (perfect.GetComponent<InputManager>().LeftNoteList.Contains(LeftNoteList[0].gameObject))
                {
                    LeftNoteList.RemoveAt(0);
                    leftAvailable = false;
                }
            }
            if (RightNoteList.Count != 0)
            {
                if (perfect.GetComponent<InputManager>().RightNoteList.Contains(RightNoteList[0].gameObject))
                {
                    RightNoteList.RemoveAt(0);
                    rightAvailable = false;
                }
            }

        }
        if (name == "HitBox Perfect")
        {
            if (UpNoteList.Count != 0)
            {
                if (late.GetComponent<InputManager>().UpNoteList.Contains(UpNoteList[0].gameObject))
                {
                    UpNoteList.RemoveAt(0);
                    upAvailable = false;
                }
            }
            if (DownNoteList.Count != 0)
            {
                if (late.GetComponent<InputManager>().DownNoteList.Contains(DownNoteList[0].gameObject))
                {
                    DownNoteList.RemoveAt(0);
                    downAvailable = false;
                }
            }
            if (LeftNoteList.Count != 0)
            {
                if (late.GetComponent<InputManager>().LeftNoteList.Contains(LeftNoteList[0].gameObject))
                {
                    LeftNoteList.RemoveAt(0);
                    leftAvailable = false;
                }
            }
            if (RightNoteList.Count != 0)
            {
                if (late.GetComponent<InputManager>().RightNoteList.Contains(RightNoteList[0].gameObject))
                {
                    RightNoteList.RemoveAt(0);
                    rightAvailable = false;
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        //checking if note is active
        if (other.GetComponent<ActivationScript>().isEnabled == true)
        {

            if (other.tag == "DownBlock")
            {
                downAvailable = true;
                DownNoteList.Add(other.gameObject);
            }
            if (other.tag == "UpBlock")
            {
                upAvailable = true;
                UpNoteList.Add(other.gameObject);
            }
            if (other.tag == "LeftBlock")
            {
                leftAvailable = true;
                LeftNoteList.Add(other.gameObject);
            }
            if (other.tag == "RightBlock")
            {
                rightAvailable = true;
                RightNoteList.Add(other.gameObject);
            }


            //missed note
            if (gameObject.name == "HitBox Miss")
            {
                other.GetComponent<ActivationScript>().isEnabled = false;
                combatManagerRef.Missed(EnemyAttack);
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }


        }

    }
    private void OnTriggerExit(Collider other)
    {
        if (RightNoteList.Contains(other.gameObject))
        {
            rightAvailable = false;
            RightNoteList.Remove(other.gameObject);
        }
        if (LeftNoteList.Contains(other.gameObject))
        {
            leftAvailable = false;
            LeftNoteList.Remove(other.gameObject);

        }
        if (UpNoteList.Contains(other.gameObject))
        {
            upAvailable = false;
            UpNoteList.Remove(other.gameObject);

        }
        if (DownNoteList.Contains(other.gameObject))
        {
            downAvailable = false;
            DownNoteList.Remove(other.gameObject);

        }



    }
}




