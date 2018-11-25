using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayData : MonoBehaviour
{
    public static PlayData instance;
    public int points = 0;
    int streak = 0;
    float streakMultiplier = 0.75f;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void Hit() {

        streak += 1;
        points = points + (int)(streak/4 * streakMultiplier);
        print("Points = " + points + " ; Streak = " + streak);


    }

    public void Fail() {

        streak = 0;
        print("Points = " + points + " ; Streak = " + streak);

    }
}
