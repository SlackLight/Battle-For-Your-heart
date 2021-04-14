using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinstateManager : MonoBehaviour
{
    public bool win;
    public bool firstTimeThrough;
    // Start is called before the first frame update
    void Start()
    {
        win = true;



    }

    // Update is called once per frame
    void Update()
    {
        
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
