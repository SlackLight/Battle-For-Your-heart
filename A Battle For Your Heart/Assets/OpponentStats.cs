using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentStats : MonoBehaviour
{
    public enum Opponents { Shou, Kana, Himeko }
    public Opponents opponent;
    Opponents currentOppopnent;
    public int Strength;
    public int Defence;
    public int Health;

    public static OpponentStats _OpponentStats;
    public static OpponentStats OStats
    {
        get
        {
            if (_OpponentStats == null)
            {
                _OpponentStats = GameObject.FindObjectOfType<OpponentStats>();
            }

            return _OpponentStats;
        }

    }
 
    public void StartUp(Opponents opponent)
    {
        switch (opponent)
        {
            case Opponents.Shou:

                Strength = 10;
                Defence = 10;
                Health = 10;

                break;
            case Opponents.Kana:
                Strength = 20;
                Defence = 20;
                Health = 20;
                break;
            case Opponents.Himeko:
                Strength = 30;
                Defence = 30;
                Health = 30;
                break;




        }
        currentOppopnent = opponent;

    }

    // Update is called once per frame
    void Update()
    {//update stats if they dont match the selected opponent
        if (currentOppopnent != opponent)
        {
            StartUp(opponent);
        }
    }
}
