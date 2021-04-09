using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationScript : MonoBehaviour
{
    public Collider colliderToActivate;
    public GameObject alsoDeactivate;
    public GameObject alsoReactivate;
    public bool isEnabled;
    private void Start()
    {
        if (gameObject.GetComponent<MeshRenderer>() != null)
        {
            if (this.GetComponent<MeshRenderer>().enabled == true)
            {
                isEnabled = true;
            }
            else
            {
                isEnabled = false;


            }
        }
    }
    private void OnMouseDown()
    {
        OnClickThisCollider();
    }

    public void OnClickThisCollider()
    {
        if(alsoDeactivate != null)
        {
            alsoDeactivate.SetActive(false);
        }
        if(alsoReactivate != null)
        {
            alsoReactivate.SetActive(true);
        }


        colliderToActivate.enabled = true;
        this.GetComponent<Collider>().enabled = false;
        //If it has a meshrenderer then disable it
        if(this.GetComponent<MeshRenderer>() != null)
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }
        //If the other thing has a meshrenderer then enable it
        if(colliderToActivate.GetComponent<MeshRenderer>() != null)
        {
            colliderToActivate.GetComponent<MeshRenderer>().enabled = true;
        }
    }


}
