using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class Rating : MonoBehaviour
{
    CombatManager managerRef;
    Image perfect;
    Image tooEarly;
    Image tooLate;
    Image miss;
    Text myText;
    int ratings = 0;
    [SerializeField] float time;
    bool perf;
    bool late;
    bool early;
    bool Bmiss;

    Vector3 perfLoc;
    Vector3 lateLoc;
    Vector3 earlyLoc;
    Vector3 missLoc;


    // Start is called before the first frame update
    void Awake()
    {
        perfect = transform.GetChild(0).GetComponent<Image>();
        tooEarly = transform.GetChild(1).GetComponent<Image>();
        tooLate = transform.GetChild(2).GetComponent<Image>();
        miss = transform.GetChild(3).GetComponent<Image>();
        perfLoc = perfect.transform.position;
        lateLoc = perfect.transform.position;
        earlyLoc = perfect.transform.position;
        missLoc = perfect.transform.position;


    }


    public void UpdateRating(string rating)
    {
        if (rating == "Perfect")
        {
            perfect.color = Color.yellow;
            perfect.transform.position = perfLoc;

        }
        else if (rating == "Too Early")
        {
            tooEarly.color = Color.white;
            tooEarly.transform.position = earlyLoc;


        }
        else if (rating == "Too Late")
        {
            tooLate.color = Color.white;
            tooLate.transform.position = lateLoc;


        }
        else if (rating == "Miss")
        {
            miss.color = Color.grey;
            miss.transform.position = missLoc;


        }
    }

    private void Update()
    {
        if (perfect.color == Color.yellow)
        {
            perf = true;
        }        
        if (tooEarly.color == Color.white)
        {
            early = true;
        }
        
        if (tooLate.color == Color.white)
        {
            late = true;
        }
        
        if (miss.color == Color.grey)
        {
            Bmiss = true;
        }
      

        if (perf)
        {

            float a = perfect.color.a;
            a -= Time.deltaTime;
            perfect.color = new Color(perfect.color.r, perfect.color.g, perfect.color.b, a);
            perfect.transform.position = new Vector3(perfect.transform.position.x, perfect.transform.position.y - a, perfect.transform.position.z);
            if(a < 0) { perf = false; };


        }
        if (early)
        {
            float a = tooEarly.color.a;
            a -= Time.deltaTime;
            tooEarly.color = new Color(tooEarly.color.r, tooEarly.color.g, tooEarly.color.b, a);
            tooEarly.transform.position = new Vector3(tooEarly.transform.position.x, tooEarly.transform.position.y - a, tooEarly.transform.position.z);

            if (a < 0) { early = false; };


        }
        if (late)
        {
            float a = tooLate.color.a;
            a -= Time.deltaTime;
            tooLate.color = new Color(tooLate.color.r, tooLate.color.g, tooLate.color.b, a);
            tooLate.transform.position = new Vector3(tooLate.transform.position.x, tooLate.transform.position.y - a, tooLate.transform.position.z);

            if (a < 0) { late = false; };


        }
        if (Bmiss)
        {
            float a = miss.color.a;
            a -= Time.deltaTime;
            miss.color = new Color(miss.color.r, miss.color.g, miss.color.b, a);
            miss.transform.position = new Vector3(miss.transform.position.x, miss.transform.position.y - a, miss.transform.position.z);

            if (a < 0) { Bmiss = false; };
        }

    }
  
}
