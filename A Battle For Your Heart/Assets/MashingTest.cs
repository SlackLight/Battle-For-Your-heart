using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MashingTest : Minigame
{
    public Slider slider;

    bool notResetting;

    public int sliderSpeed = 2;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        if (gameStillGoing)
        {
            MashingMinigame();
        }
    }

    public void MashingMinigame()
    {
        //If not in sucess menu
        if (notResetting)
        {
            //Mashing 
        }
        else
        {
            //run the reset stuff
        }
    }
}
