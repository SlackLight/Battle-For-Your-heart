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
        if (StatManager.Stats != null)
        {
            Destroy(this.gameObject);
        }
        else if (StatManager.Stats == null)
        {
            Stats = this;
            DontDestroyOnLoad(this);
        }
        

    }

    public void MatchingWin()
    {
        Strength += 5;
        
       
    }public void GymWin()
    {
        Health += 15;
        
       
    }public void ScienceWin()
    {
        Health += 5;
        
       
    }
}
