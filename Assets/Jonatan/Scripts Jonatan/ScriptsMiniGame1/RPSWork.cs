using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RPSWork : MonoBehaviour
{
    public static RPSWork instance;
    int playerPoints = 0;
    int IAPoints = 0;
    RPS playerAction = RPS.Null;
    RPS IAAction = RPS.Null;
    bool newBattle = false;
    bool victory = false;
    public GameObject[] playerObjects = new GameObject[3];
    public GameObject[] IAObjects = new GameObject[3];
    float timerBattle = 1;
    public Text playerScore;
    public Text IAScore;
    public Text victoryText;
    float timer = 3f;
    public GameObject imagen;
    // Start is called before the first frame update

    void Start() {
        imagen.SetActive(false);
        instance = this;

    }


    void Update() {

        if (!victory)
        {

            if (playerAction != RPS.Null && IAAction != RPS.Null)
            {

                if (!newBattle)
                {

                    Turn();

                }


            }

            timerBattle -= Time.deltaTime;
            if (timerBattle <= 0 && newBattle)
            {


                newTurn();

            }

        }
        else {
            imagen.SetActive(true);
            timer -= Time.deltaTime;
            if (timer <= 0) {

                SceneManager.LoadScene("Oficina");
                


            }



        }


    }


    void Turn() {

        playerObjects[(int)playerAction].gameObject.transform.Translate(Vector3.down * -0.75f);
        IAObjects[(int)IAAction].gameObject.transform.Translate(Vector3.down * -0.75f);

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
        playerScore.text = "" + playerPoints;
        IAScore.text = "" + IAPoints;
        newBattle = true;
        timerBattle = 1;
        if (playerPoints >= 3)
        {

            victoryText.text = "You Win";
            victory = true;

        }
        else if (IAPoints >= 3)
        {

            victoryText.text = "You Lose";
            victory = true;

        }


    }

    void newTurn() {


        playerObjects[(int)playerAction].gameObject.transform.Translate(Vector3.down * 0.75f);
        IAObjects[(int)IAAction].gameObject.transform.Translate(Vector3.down * 0.75f);
        playerAction = RPS.Null;
        IAAction = RPS.Null;
        newBattle = false;
        //print("Player Points: " + playerPoints + " ; Enemy Points: " + IAPoints);


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

    public void Restart() {

        victory = false;
        playerPoints = 0;
        IAPoints = 0;
        timerBattle = 0;
        playerScore.text = "" + playerPoints;
        IAScore.text = "" + IAPoints;
        victoryText.text = "";


    }
}

public enum RPS {  Paper, Rock, Scissor, Null }
