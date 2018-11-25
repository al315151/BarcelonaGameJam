using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineMovement : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    public float speed = 30f;
    float timer = 1.5f;
    float timerBase = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D.rotation = Random.Range(0f, 360f);

    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.name.Contains("Clone")) {
            
        }
        else {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {

                Instantiate(this.gameObject);
                if (timerBase > 0.1) {

                    timerBase = timerBase - 0.005f;

                }
                timer = timerBase;
                speed += 0.01f;
            }

        }


    }

    private void FixedUpdate()
    {
        if (this.gameObject.name.Contains("Clone"))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, Vector3.zero, speed * Time.fixedDeltaTime);
        }
        else {

            transform.RotateAround(Vector3.zero, Vector3.forward, 25 * Time.fixedDeltaTime * -speed);
        }
        
    }
}
