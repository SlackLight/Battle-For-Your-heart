using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Namechecker : MonoBehaviour
{
    public Text oldName;

    public string defaultName = "(Name)";

    public Text name;
    public Text tomomiName;

    private void Update()
    {

        if(oldName.text == "Tomomi")
        {
            tomomiName.gameObject.SetActive(true);
            name.gameObject.SetActive(false);
        }
        else if(oldName.text != defaultName)
        {
            name.gameObject.SetActive(true);
            name.text = oldName.text;
            tomomiName.gameObject.SetActive(false);
        }
        else
        {
            name.gameObject.SetActive(false);
            tomomiName.gameObject.SetActive(false);
        }
    }


}
