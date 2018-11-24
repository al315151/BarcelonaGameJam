using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyTrigger : MonoBehaviour
{
    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Key")
        {
            switch (other.gameObject.GetComponent<KeyMovement>().mykey) {


                case KeyMovement.Keys.A:
                    if (Input.GetKeyDown(KeyCode.A)) {
                        Destroy(other.gameObject);
                    }
                    break;

                case KeyMovement.Keys.S:
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        Destroy(other.gameObject);
                    }
                    break;
                case KeyMovement.Keys.D:
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        Destroy(other.gameObject);
                    }
                    break;
                case KeyMovement.Keys.F:
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Destroy(other.gameObject);
                    }
                    break;



            }


        }
    }

}
