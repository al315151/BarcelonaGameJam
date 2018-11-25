using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class KeyGenerator : MonoBehaviour
{
    public GameObject[] KeysList = new GameObject[4]; 
    public float timer = 0.5f;
    int keysCounter = 0;
    

    // Update is called once per frame
    void Update()
    {
        if (keysCounter < 20) {


            if (timer <= 0)
            {
                Random random = new Random();
                int i = Random.Range(0, KeysList.Length);
                GameObject aux = Instantiate(KeysList[i]);
                aux.tag = "Key";
                timer = 1f;
                keysCounter += 1;
            }
            else
            {

                timer -= Time.deltaTime;

            }

            if (keysCounter == 20)
            {
                timer = 5f;
            }

        }
        else
        {
            
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                GoToWay();
            }
        }
       
    }

    void GoToWay()
    {
        GameManager.instance.money = GameManager.instance.money + 60 + PlayData.instance.points;
        SceneManager.LoadScene(4);
    }



}
