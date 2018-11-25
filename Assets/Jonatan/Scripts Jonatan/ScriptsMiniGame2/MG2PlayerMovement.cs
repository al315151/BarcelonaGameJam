using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG2PlayerMovement : MonoBehaviour
{
    public float speed = 700f;
    public GameObject bullet;
    public Transform bulletExit;
    float horizontalMovement = 0f;
    float shootRate = 0.15f;

    // Update is called once per frame
    void Update()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        shootRate -= Time.deltaTime;

        if (Input.GetKey(KeyCode.Space)) {

            if (shootRate <= 0) {

                Shoot();

            }
            

        }

        
    }

    private void FixedUpdate()
    {
        transform.RotateAround(Vector3.zero, Vector3.forward, horizontalMovement * Time.fixedDeltaTime * -speed);
    }


    void Shoot() {


        Instantiate(bullet, bulletExit.position, this.gameObject.transform.rotation);
        shootRate = 0.15f;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key") {

            Destroy(this.gameObject);


        }
    }
}
