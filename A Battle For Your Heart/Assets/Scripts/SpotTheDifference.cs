using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotTheDifference : Minigame
{
    [SerializeField] int totalDifferences;
    [SerializeField] int differencesFound;

    
    public override void Start()
    {
        scoreToWin = totalDifferences;
        base.Start();
    }
    public override void Update()
    {
        base.Update();
        if (gameStillGoing)
        {
            SpotTheDifferenceMinigame();
        }
    }
    void SpotTheDifferenceMinigame()
    {
        scoreValue = differencesFound;
    }
    public void DifferenceFound()
    {
        differencesFound++;
    }
}
