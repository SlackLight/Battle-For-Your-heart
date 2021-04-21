using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingColliders : MonoBehaviour
{
    InputManager inputManager;
    CombatManager combatManagerRef;
    [SerializeField] Animator Tomomi;


    // Start is called before the first frame update
    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
        combatManagerRef = FindObjectOfType<CombatManager>();
    }

 
    private void OnTriggerEnter(Collider other)
    {

        inputManager.OnNoteEnter(other, gameObject);


        if (gameObject.name == "HitBox Miss")
        {
            if (other.GetComponent<ActivationScript>().isEnabled)
            {
                if (combatManagerRef.AttackMode)
                {
                    Tomomi.SetTrigger("Hit");

                }
                else
                {
                    Tomomi.SetTrigger("BlockHit");

                }

                other.GetComponent<ActivationScript>().isEnabled = false;
                combatManagerRef.Missed(inputManager.EnemyAttack);
                other.gameObject.GetComponent<SpriteRenderer>().enabled = false;


            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inputManager.OnNoteExit(other, gameObject);
    }
}
