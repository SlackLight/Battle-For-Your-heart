using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    [SerializeField] Color defaultCol;
    [SerializeField] Color hiddenCol;
    Text current;
    // Start is called before the first frame update
    void Start()
    {
        current.color = defaultCol;
        current = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(current.color == defaultCol)
        {

           StartCoroutine(DoAThingOverTime(current.color, hiddenCol, 1f));

        }

    }


    IEnumerator DoAThingOverTime(Color start, Color end, float duration)
    {
        for (float t = 0f; t < duration; t += Time.deltaTime)
        {
            float normalizedTime = t / duration;
            //right here, you can now use normalizedTime as the third parameter in any Lerp from start to end
            current.color = Color.Lerp(start, end, normalizedTime);
            yield return null;
        }
        current.color = end; //without this, the value will end at something like 0.9992367
    }
}
