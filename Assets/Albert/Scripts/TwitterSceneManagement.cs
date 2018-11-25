using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TwitterSceneManagement : MonoBehaviour
{

    float timer_change_scene;
    // Start is called before the first frame update
    void Start()
    {
        timer_change_scene = 10f;
    }

    // Update is called once per frame
    void Update()
    {
        timer_change_scene -= Time.deltaTime;
        
        if (timer_change_scene < 0.0f)
        {
            SceneManager.LoadScene(0);
        }

    }
}
