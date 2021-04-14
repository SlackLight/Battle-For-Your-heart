using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public int Strength;
    public int Defence;
    public int Health;

    public static StatManager _Stats;
    public static StatManager Stats
    {
        get
        {
            if (_Stats == null)
            {
                _Stats = GameObject.FindObjectOfType<StatManager>();
            }

            return _Stats;
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void MatchingWin()
    {
        Strength += 10;
        
       
    }public void GymWin()
    {
        Health += 25;
        
       
    }public void ScienceWin()
    {
        Health += 10;
        
       
    }
}
