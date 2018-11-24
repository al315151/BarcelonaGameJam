using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MG2BulletMovement : MonoBehaviour
{
    float speed = 10;

    // Start is called before the first frame update


    private void FixedUpdate()
    {
        this.gameObject.transform.Translate(0, speed * Time.deltaTime, 0);

        Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.transform.position);
        if ((screenPoint.x < 0 || screenPoint.x > 1) || (screenPoint.y < 0 || screenPoint.y > 1))
        {

            Destroy(this.gameObject);
        }
    }
}
