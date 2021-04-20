using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public enum mode { Edit, Play };
    public mode Mode;
    [SerializeField] Material UpArrow, DownArrow, RightArrow, LeftArrow;
    [SerializeField] Material UpArrowO, DownArrowO, RightArrowO, LeftArrowO;
    public int EnemyAttack = 8;
    bool editing = false;
    [SerializeField] CombatManager combatManagerRef;

    [SerializeField] List<GameObject> DownNoteList = new List<GameObject>();
    [SerializeField] List<GameObject> UpNoteList = new List<GameObject>();
    [SerializeField] List<GameObject> LeftNoteList = new List<GameObject>();
    [SerializeField] List<GameObject> RightNoteList = new List<GameObject>();
    [SerializeField] List<GameObject> earlyNoteList = new List<GameObject>();
    [SerializeField] List<GameObject> perfectNoteList = new List<GameObject>();
    [SerializeField] List<GameObject> lateNoteList = new List<GameObject>();
    [SerializeField] GameObject perfect;
    [SerializeField] GameObject early;
    [SerializeField] GameObject late;
    [SerializeField] GameObject opponentNotes;

    [SerializeField] GameObject upPrefab;
    [SerializeField] GameObject DownPrefab;
    [SerializeField] GameObject LeftPrefab;
    [SerializeField] GameObject RightPrefab;


    [SerializeField] GameObject Up;
    [SerializeField] GameObject Down;
    [SerializeField] GameObject Left;
    [SerializeField] GameObject Right;
    [SerializeField] Transform noteController;
    [SerializeField] GameObject miss;

    [SerializeField] Animator animator;

    [SerializeField] ParticleSystem UpPart;
    [SerializeField] ParticleSystem DownPart;
    [SerializeField] ParticleSystem LeftPart;
    [SerializeField] ParticleSystem RightPart;
    [SerializeField] ParticleSystem UpPartO;
    [SerializeField] ParticleSystem DownPartO;
    [SerializeField] ParticleSystem LeftPartO;
    [SerializeField] ParticleSystem RightPartO;


    [SerializeField] ParticleSystem PlayerPerfect;

    [SerializeField] Animator Tomomi;





    // Start is called before the first frame update
    void Start()
    {
        combatManagerRef = GameObject.FindGameObjectWithTag("Player").GetComponent<CombatManager>();
        if (noteController == null)
        {

            noteController = FindObjectOfType<NoteController>().transform;

        }
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

    IEnumerator DownO()
    {
        DownPartO.Play();
        DownArrowO.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(.1f);
        DownArrowO.DisableKeyword("_EMISSION");

    }
    IEnumerator UpO()
    {
        UpPartO.Play();
        UpArrowO.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(.1f);
        UpArrowO.DisableKeyword("_EMISSION");
    }
    IEnumerator RightO()
    {
        RightPartO.Play();
        RightArrowO.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(.1f);
        RightArrowO.DisableKeyword("_EMISSION");
    }
    IEnumerator LeftO()
    {
        LeftPartO.Play();
        LeftArrowO.EnableKeyword("_EMISSION");
        yield return new WaitForSeconds(.1f);
        LeftArrowO.DisableKeyword("_EMISSION");
    }

    void Update()
    {
        switch (Mode)
        {
            case mode.Edit:
                editing = true;
                miss.SetActive(false);


                break;
            case mode.Play:
                editing = false;

                miss.SetActive(true);

                break;

        }
        if (noteController != null)
        {
            if (!noteController.gameObject.activeInHierarchy)
            {
                noteController = FindObjectOfType<NoteController>().transform;
            }
        }
        //visuals for buttons

        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            if (editing)
            {
                GameObject temp = Instantiate(DownPrefab, noteController.transform);
                temp.transform.position = Down.transform.position;
                temp.transform.rotation = Down.transform.rotation;
            }
            StartCoroutine("DownPress");

        }
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine("UpPress");
            if (editing)
            {
                GameObject temp = Instantiate(upPrefab, noteController.transform);
                temp.transform.position = Up.transform.position;
                temp.transform.rotation = Up.transform.rotation;
            }

        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine("LeftPress");
            if (editing)
            {
                GameObject temp = Instantiate(LeftPrefab, noteController.transform);
                temp.transform.position = Left.transform.position;
                temp.transform.rotation = Left.transform.rotation;
            }

        }
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine("RightPress");
            if (editing)
            {
                GameObject temp = Instantiate(RightPrefab, noteController.transform);
                temp.transform.position = Right.transform.position;
                temp.transform.rotation = Right.transform.rotation;
            }

        }

        if (!editing)
        {
            //INPUTS
            if (LeftNoteList.Count != 0)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
                {
                    if (lateNoteList.Contains(LeftNoteList[0]))
                    {
                        LeftNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                        LeftNoteList[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        LeftNoteList.RemoveAt(0);
                        lateNoteList.RemoveAt(0);
                        combatManagerRef.TooLate(EnemyAttack);
                        //animator.GetParameter("") = true;

                    }
                    else if (perfectNoteList.Contains(LeftNoteList[0]))
                    {
                        LeftNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                        LeftNoteList[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        LeftNoteList.RemoveAt(0);
                        perfectNoteList.RemoveAt(0);
                        combatManagerRef.Perfect();
                        LeftPart.Play();
                        //PlayerPerfect.Play();

                    }
                    else if (earlyNoteList.Contains(LeftNoteList[0]))
                    {
                        LeftNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                        LeftNoteList[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        LeftNoteList.RemoveAt(0);
                        earlyNoteList.RemoveAt(0);
                        combatManagerRef.TooEarly(EnemyAttack);
                    }
                    Tomomi.SetTrigger("DanceLeft");

                }
            }
            if (RightNoteList.Count != 0)
            {
                if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                {

                    if (lateNoteList.Contains(RightNoteList[0]))
                    {
                        RightNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                        RightNoteList[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        RightNoteList.RemoveAt(0);
                        lateNoteList.RemoveAt(0);
                        combatManagerRef.TooLate(EnemyAttack);
                    }
                    else if (perfectNoteList.Contains(RightNoteList[0]))
                    {
                        RightNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                        RightNoteList[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        RightNoteList.RemoveAt(0);
                        perfectNoteList.RemoveAt(0);
                        combatManagerRef.Perfect();
                        RightPart.Play();
                        //PlayerPerfect.Play();

                    }
                    else if (earlyNoteList.Contains(RightNoteList[0]))
                    {
                        RightNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                        RightNoteList[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        RightNoteList.RemoveAt(0);
                        earlyNoteList.RemoveAt(0);
                        combatManagerRef.TooEarly(EnemyAttack);
                    }
                    Tomomi.SetTrigger("DanceRight");


                }

            }
            if (DownNoteList.Count != 0)
            {
                if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
                {
                    if (lateNoteList.Contains(DownNoteList[0]))
                    {
                        DownNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                        DownNoteList[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        DownNoteList.RemoveAt(0);
                        lateNoteList.RemoveAt(0);
                        combatManagerRef.TooLate(EnemyAttack);
                    }
                    else if (perfectNoteList.Contains(DownNoteList[0]))
                    {
                        DownNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                        DownNoteList[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        DownNoteList.RemoveAt(0);
                        perfectNoteList.RemoveAt(0);
                        combatManagerRef.Perfect();
                        DownPart.Play();
                        //PlayerPerfect.Play();

                    }
                    else if (earlyNoteList.Contains(DownNoteList[0]))
                    {
                        DownNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                        DownNoteList[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        DownNoteList.RemoveAt(0);
                        earlyNoteList.RemoveAt(0);
                        combatManagerRef.TooEarly(EnemyAttack);
                    }
                    Tomomi.SetTrigger("DanceDown");


                }
            }
            if (UpNoteList.Count != 0)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
                {

                    if (lateNoteList.Contains(UpNoteList[0]))
                    {
                        UpNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                        UpNoteList[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        UpNoteList.RemoveAt(0);
                        lateNoteList.RemoveAt(0);
                        combatManagerRef.TooLate(EnemyAttack);
                    }
                    else if (perfectNoteList.Contains(UpNoteList[0]))
                    {
                        UpNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                        UpNoteList[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        UpNoteList.RemoveAt(0);
                        perfectNoteList.RemoveAt(0);
                        combatManagerRef.Perfect();
                        UpPart.Play();
                        //PlayerPerfect.Play();
                    }
                    else if (earlyNoteList.Contains(UpNoteList[0]))
                    {
                        UpNoteList[0].gameObject.GetComponent<ActivationScript>().isEnabled = false;
                        UpNoteList[0].gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        UpNoteList.RemoveAt(0);
                        earlyNoteList.RemoveAt(0);
                        combatManagerRef.TooEarly(EnemyAttack);
                    }
                    Tomomi.SetTrigger("DanceUp");


                }
            }
        }
    }

    public void OnNoteEnter(Collider note, GameObject timingOverlap)
    {
        if (timingOverlap == opponentNotes)
        {
            if (note.tag == "AttackMode")
            {
                combatManagerRef.AttackMode = true;
                //combat manager attack mode = true
            }
            else
            {
                note.GetComponent<SpriteRenderer>().enabled = false;
                earlyNoteList.Add(note.gameObject);
                if (note.tag == "DownBlock")
                {
                    StartCoroutine("DownO");
                }
                if (note.tag == "UpBlock")
                {
                    StartCoroutine("UpO");
                }
                if (note.tag == "LeftBlock")
                {
                    StartCoroutine("LeftO");
                }
                if (note.tag == "RightBlock")
                {
                    StartCoroutine("RightO");
                }

                combatManagerRef.AttackMode = false;

            }
        }
        else
        {




            if (note.tag == "EndBlock")
            {
                FindObjectOfType<OpponentManager>().SongDone = true;
            }
            if (note.GetComponent<ActivationScript>().isEnabled == true && !editing && timingOverlap != opponentNotes)
            {
                if (timingOverlap == early)
                {
                    earlyNoteList.Add(note.gameObject);
                    if (note.tag == "DownBlock")
                    {
                        DownNoteList.Add(note.gameObject);
                    }
                    if (note.tag == "UpBlock")
                    {
                        UpNoteList.Add(note.gameObject);
                    }
                    if (note.tag == "LeftBlock")
                    {
                        LeftNoteList.Add(note.gameObject);
                    }
                    if (note.tag == "RightBlock")
                    {
                        RightNoteList.Add(note.gameObject);
                    }

                }
                if (timingOverlap == perfect)
                {
                    if (earlyNoteList.Contains(note.gameObject))
                    {
                        earlyNoteList.Remove(note.gameObject);
                        perfectNoteList.Add(note.gameObject);
                    }

                }
                if (timingOverlap == late)
                {
                    if (perfectNoteList.Contains(note.gameObject))
                    {
                        perfectNoteList.Remove(note.gameObject);
                        lateNoteList.Add(note.gameObject);
                    }

                }
            }
        }
        //if(timingOverlap == End)
    }



    public void OnNoteExit(Collider note, GameObject timingOverlap)
    {
        if (timingOverlap == late)
        {
            if (RightNoteList.Contains(note.gameObject))
            {
                RightNoteList.Remove(note.gameObject);
            }
            if (LeftNoteList.Contains(note.gameObject))
            {
                LeftNoteList.Remove(note.gameObject);
            }
            if (UpNoteList.Contains(note.gameObject))
            {
                UpNoteList.Remove(note.gameObject);
            }
            if (DownNoteList.Contains(note.gameObject))
            {
                DownNoteList.Remove(note.gameObject);
            }
            if (lateNoteList.Contains(note.gameObject))
            {
                lateNoteList.Remove(note.gameObject);
            }
        }






    }
}




