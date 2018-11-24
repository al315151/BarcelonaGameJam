using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                Instantiate(KeysList[i]);
                timer = 1f;
                keysCounter += 1;
            }
            else
            {

                timer -= Time.deltaTime;

            }



        }
       
    }
}
