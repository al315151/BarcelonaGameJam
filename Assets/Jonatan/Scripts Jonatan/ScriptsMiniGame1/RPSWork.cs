using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSWork : MonoBehaviour
{
    public static RPSWork instance;
    int playerPoints = 0;
    int IAPoints = 0;
    RPS playerAction = RPS.Null;
    RPS IAAction = RPS.Null;
    // Start is called before the first frame update

    void Start() {

        instance = this;

    }


    void Update() {

        if (playerAction != RPS.Null && IAAction != RPS.Null) {

            Turn();

        }

    }


    void Turn() {

        switch (playerAction) {

            case RPS.Rock:
                switch (IAAction) {

                    case RPS.Paper:
                        IAPoints += 1;
                        break;
                    case RPS.Scissor:
                        playerPoints += 1;
                        break;

                }
                break;
            case RPS.Paper:
                switch (IAAction)
                {

                    case RPS.Scissor:
                        IAPoints += 1;
                        break;
                    case RPS.Rock:
                        playerPoints += 1;
                        break;

                }
                break;
            case RPS.Scissor:
                switch (IAAction)
                {

                    case RPS.Rock:
                        IAPoints += 1;
                        break;
                    case RPS.Paper:
                        playerPoints += 1;
                        break;

                }
                break;
        }

        playerAction = RPS.Null;
        IAAction = RPS.Null;

        print("Player Points: " + playerPoints + " ; Enemy Points: " + IAPoints);
    }


    public void setPlayerAction(RPS rps) {

        playerAction = rps;


    }

    public void setIAAction(RPS rps)
    {

        IAAction = rps;


    }

    public RPS getPlayerAction() {

        return playerAction;


    }


    public RPS getIAAction() {


        return IAAction;

    }
}

public enum RPS { Rock, Paper, Scissor, Null }
