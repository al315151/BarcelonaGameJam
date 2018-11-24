using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    public GameObject apple;

    public static int appleCount;

    // Update is called once per frame
    void Update()
    {
        putApples();
    }

    void putApples(){
        if(appleCount == 0){
            detectSnake();
        }

    }

    void detectSnake()
    {
        Vector3 pos = new Vector3((int)Random.Range(-10, 11), 0.5f, (int)Random.Range(-10, 11));
        RaycastHit hit;
        if (!Physics.Raycast(pos, Vector3.down, out hit, 0.1f))
        {
            Instantiate(apple, pos, Quaternion.identity);
            appleCount++;
        }
    }
}
