using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatManager : MonoBehaviour
{
    public int Strength;
    public int Defence;
    public int Health;


    public static StatManager Stats;
    
       
          
          
        

    


    // Start is called before the first frame update
    void Awake()
    {
        if (Stats == null)
        {
            Stats = this;
            DontDestroyOnLoad(this);
        }

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
