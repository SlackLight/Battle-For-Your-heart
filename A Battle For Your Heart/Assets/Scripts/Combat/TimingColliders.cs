using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingColliders : MonoBehaviour
{
    InputManager inputManager;
    CombatManager combatManagerRef;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = FindObjectOfType<InputManager>();
        combatManagerRef = FindObjectOfType<CombatManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {

        inputManager.OnNoteEnter(other, gameObject);


        if (gameObject.name == "HitBox Miss")
        {
            if (other.GetComponent<ActivationScript>().isEnabled)
            {
                other.GetComponent<ActivationScript>().isEnabled = false;
                combatManagerRef.Missed(inputManager.EnemyAttack);
                other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        inputManager.OnNoteExit(other, gameObject);
    }
}
