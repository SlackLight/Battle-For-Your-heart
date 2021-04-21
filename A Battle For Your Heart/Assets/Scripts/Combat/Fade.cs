using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    
    [SerializeField] Color hiddenCol;
    Image current;
    [SerializeField]
    [Min(0)] float time;
    // Start is called before the first frame update
    void Start()
    {
        
        current = GetComponent<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(current.color == Color.yellow || current.color == Color.white || current.color == Color.black)
        {

           //StartCoroutine(DoAThingOverTime(current.color, hiddenCol, time));

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
