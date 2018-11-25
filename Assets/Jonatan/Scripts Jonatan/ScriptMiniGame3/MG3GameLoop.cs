using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG3GameLoop : MonoBehaviour
{
    bool end = false;
    public GameObject player;
    GameObject aux;
    public Text victory;

    private void Start()
    {
        aux = Instantiate(player);
    }

    private void Update()
    {
        if (aux.gameObject.transform.position.y <= -1) {

            victory.text = "Has escapado";
            end = true;


        }


        if (end) {

            if (Input.GetKeyDown(KeyCode.R)) {

                victory.text = "";
                Destroy(aux);
                aux = Instantiate(player);
                end = false;
            }
        }
    }



}
