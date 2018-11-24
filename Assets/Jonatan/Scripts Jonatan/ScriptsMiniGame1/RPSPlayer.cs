using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSPlayer : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (RPSWork.instance.getPlayerAction() == RPS.Null) {

            if (Input.GetKeyDown(KeyCode.S)) {

                RPSWork.instance.setPlayerAction(RPS.Scissor);

            }
            else if (Input.GetKeyDown(KeyCode.R)) {

                RPSWork.instance.setPlayerAction(RPS.Rock);

            }
            else if (Input.GetKeyDown(KeyCode.P))
            {

                RPSWork.instance.setPlayerAction(RPS.Paper);

            }
            
        }
    }
}
