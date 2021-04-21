using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinstateManager : MonoBehaviour
{
    public static WinstateManager instance;
    public bool win;
    public bool firstTimeThrough= true;
    // Start is called before the first frame update
    
    private void Awake()
    {
        if(instance == null)
        {
            WinstateManager.instance = this;
            DontDestroyOnLoad(this);
            firstTimeThrough = true;
        }
    }

 
    public void SetWin()
    {
        win = true;
    }
    public void SetLose()
    {
        win = false;
    }
    public void CutscenePlayed()
    {
        firstTimeThrough = false;
    }
}
