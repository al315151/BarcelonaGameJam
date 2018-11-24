using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPSIA : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RPSWork.instance.getIAAction() == RPS.Null) {

            int i = Random.Range(0, 3);

            switch (i) {

                case 1:
                    RPSWork.instance.setIAAction(RPS.Paper);
                    print("Paper");
                    break;

                case 2:
                    RPSWork.instance.setIAAction(RPS.Rock);
                    print("Rock");
                    break;

                case 0:
                    RPSWork.instance.setIAAction(RPS.Scissor);
                    print("Scissor");
                    break;

            }

        }
        
    }
}
