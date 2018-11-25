using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MG2PlayerMovement : MonoBehaviour
{
    public float speed = 700f;
    public GameObject bullet;
    public Transform bulletExit;
    float horizontalMovement = 0f;
    float shootRate = 0.15f;
    bool death = false;
    public GameObject originalLine;
    public Text defeatText;

    // Update is called once per frame
    void Update()
    {
        if (!death)
        {

            horizontalMovement = Input.GetAxisRaw("Horizontal");
            shootRate -= Time.deltaTime;

            if (Input.GetKey(KeyCode.Space))
            {

                if (shootRate <= 0)
                {

                    Shoot();

                }

            }
        } 
    }

    private void FixedUpdate()
    {
        if (!death) {

            transform.RotateAround(Vector3.zero, Vector3.forward, horizontalMovement * Time.fixedDeltaTime * -speed);

        }
       
    }


    void Shoot() {


        Instantiate(bullet, bulletExit.position, this.gameObject.transform.rotation);
        shootRate = 0.15f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Line") {


            shootRate = 0.15f;
            death = true;
            defeatText.text = "You Lose";
            originalLine.GetComponent<LineMovement>().CleanGame();
            this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
    }


    public void ReStart()
    {

        death = false;
        defeatText.text = "";
        originalLine.GetComponent<LineMovement>().RestartGame();
        this.gameObject.GetComponent<SpriteRenderer>().enabled = true;


    }
}
