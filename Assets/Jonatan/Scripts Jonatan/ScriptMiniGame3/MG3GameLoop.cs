using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MG3GameLoop : MonoBehaviour
{
    bool end = false;
    public GameObject player;
    GameObject aux;
    public Text victory;
    float timer = 3;

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
            timer -= Time.deltaTime;
            if (timer <= 0) {

                SceneManager.LoadScene("Oficina");


            }

        }
    }



}
