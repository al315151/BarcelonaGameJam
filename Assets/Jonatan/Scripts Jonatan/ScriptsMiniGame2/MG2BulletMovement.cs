using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG2BulletMovement : MonoBehaviour
{
    float speed = 5;

    // Start is called before the first frame update


    private void FixedUpdate()
    {
        this.gameObject.transform.Translate(0, speed * Time.fixedDeltaTime, 0);

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.transform.position);
        if ((screenPoint.x < 0 || screenPoint.x > 1) || (screenPoint.y < 0 || screenPoint.y > 1))
        {

            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Key") {

            Destroy(collision.gameObject);
            Destroy(this.gameObject);

        }
    }

}
