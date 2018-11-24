using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyMovement : MonoBehaviour
{
    public enum Keys { A, S, D, F }
    public float speed = 3f;
    public Keys mykey = Keys.A;
    // Start is called before the first frame update
    
    private void FixedUpdate()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed * Time.fixedDeltaTime);
    }
}
