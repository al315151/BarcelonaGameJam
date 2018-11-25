using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalaController : MonoBehaviour
{
    private float playerSpeed = 10;
    private float iaSpeed = 3;
    private SpriteRenderer sprite;
    public Transform maxPoint;
    public Transform minPoint;
    public bool IAControlled;
    public Transform ball;
    private Vector3 originalPos;

    private void Awake()
    {
        originalPos = transform.position;
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 previousPos = transform.position;
        if (!IAControlled)
        {
            if (Input.GetKey(KeyCode.W))
                Move(Vector3.up,playerSpeed);
            if (Input.GetKey(KeyCode.S))
                Move(Vector3.down,playerSpeed);
        }
        else
        {
            if (ball.position.y > transform.position.y)
                Move(Vector3.up, iaSpeed);
            else if(ball.position.y < transform.position.y)
                Move(Vector3.down, iaSpeed);
        }
    }

    public void Move(Vector3 dir, float speed)
    {
        Vector3 previousPos = transform.position;
        transform.Translate(dir * speed * Time.deltaTime);
        if (transform.position.y + sprite.sprite.bounds.size.y / 2 * transform.localScale.y > maxPoint.position.y || transform.position.y - sprite.sprite.bounds.size.y / 2 * transform.localScale.y < minPoint.position.y)
            transform.position = previousPos;
    }

    public void ResetPos()
    {
        transform.position = originalPos;
    }
}
