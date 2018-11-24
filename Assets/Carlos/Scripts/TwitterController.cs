using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TwitterController : MonoBehaviour
{
    public Scrollbar scrollBar;
    public GameObject tweetPrefab;
    public Transform TL;

    // Update is called once per frame
    void Update()
    {
        scrollBar.value = 0;
        if (Input.GetKeyDown(KeyCode.A))
            InsertTweet("HOLA");
    }

    public void InsertTweet(string tweetText)
    {
        //inserta tweet
        GameObject tweet = Instantiate(tweetPrefab, TL);
        tweet.GetComponentInChildren<Text>().text = tweetText;
    }
}
