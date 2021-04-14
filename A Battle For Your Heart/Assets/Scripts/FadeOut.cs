using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeOut : MonoBehaviour
{

    public CanvasGroup thisCanvas;

    public float timeUntilFadeBegins = 4;

    public Text weekText;

    public Text dayText;

    bool faded = false;

    public float fadeOutSpeed;

    private void Start()
    {
        //Enable all the children for this canvas
        foreach (Transform child in gameObject.transform)
        {
            child.gameObject.SetActive(true);
        }
        thisCanvas = GetComponent<CanvasGroup>();
        weekText.text = "Week " + TimeManager.instance.weekCounter;
        dayText.text = "Day " + TimeManager.instance.dayCounter;
    }

    private void Update()
    {
        if (!faded)
        {
            if (timeUntilFadeBegins > 0)
            {
                timeUntilFadeBegins -= Time.deltaTime;
            }
            else if (thisCanvas.alpha > 0.1f)
            {
                thisCanvas.alpha = Mathf.Lerp(thisCanvas.alpha, 0, Time.deltaTime * fadeOutSpeed);
            }
            else if (thisCanvas.alpha <= 0.1f)
            {
                thisCanvas.alpha = 0;
                faded = true;
                foreach (Transform child in gameObject.transform)
                {
                    child.gameObject.SetActive(false);
                }
            }
        }

        
        
    }

}
