using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BolaPongBehaviour : MonoBehaviour
{
    Vector2 dir;
    float speed = 5;
    private SpriteRenderer sprite;
    public Transform maxPoint;
    public Transform minPoint;
    public PalaController p1;
    public PalaController p2;
    public Text p1TextScore;
    public Text p2TextScore;
    private int p1Score;
    private int p2Score;
    private int maxScore = 3;
    private float timer = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        dir = new Vector2(Random.value * 2 - 1, Random.value - 0.5f);
        p1Score = 0;
        p2Score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer<=0)
        {
            dir *= 1.1f;
            timer += 1.0f;
        }

        transform.Translate(dir * speed * Time.deltaTime);
        if (transform.position.y + sprite.sprite.bounds.size.y / 2 * transform.localScale.y > maxPoint.position.y || transform.position.y - sprite.sprite.bounds.size.y / 2 * transform.localScale.y < minPoint.position.y)
            dir = new Vector2(dir.x, -dir.y);
        if (transform.position.x + sprite.sprite.bounds.size.x / 2 * transform.localScale.x > maxPoint.position.x)
        {
            //sale por la derecha
            p1Score++;
            ResetGame();
            p1TextScore.text = p1Score.ToString();
            if(p1Score == maxScore)
            {
                //gana p1
            }
        }
        else if(transform.position.x - sprite.sprite.bounds.size.x / 2 * transform.localScale.x < minPoint.position.x)
        {
            //sale por la izquierda
            p2Score++;
            ResetGame();
            p2TextScore.text = p2Score.ToString();
            if (p2Score == maxScore)
            {
                //gana p2
            }

        }


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "PalaPong")
            dir = new Vector2(-dir.x, dir.y);
    }

    private void ResetGame()
    {
        transform.position = Vector3.zero;
        p1.ResetPos();
        p2.ResetPos();
        dir = new Vector2(Random.value * 2 - 1, Random.value - 0.5f);
    }
}
