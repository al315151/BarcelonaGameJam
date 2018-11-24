using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KeyMovement : MonoBehaviour
{
    public bool canDestroy = false;
    public enum Keys { A, S, D, F }
    public Keys myKey = Keys.A;
    float speed = -400f;
    // Start is called before the first frame update

    private void Update()
    {
        if (canDestroy)
        {

            Game();
        }
    }


    private void FixedUpdate()
    {
        this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, speed * Time.fixedDeltaTime);
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(this.transform.position);
        if (screenPoint.y < 0)
        {
            PlayData.instance.Fail();
            Destroy(this.gameObject);
        }
       
    }

    void Game() {


        switch (myKey) {


                case KeyMovement.Keys.A:
                    if (Input.GetKeyDown(KeyCode.A)) {
                        PlayData.instance.Hit();
                        Destroy(this.gameObject);
                    }
                    break;

                case KeyMovement.Keys.S:
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        PlayData.instance.Hit();
                        Destroy(this.gameObject);
                    }
                    break;
                case KeyMovement.Keys.D:
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        PlayData.instance.Hit();
                        Destroy(this.gameObject);
                    }
                    break;
                case KeyMovement.Keys.F:
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        PlayData.instance.Hit();
                        Destroy(this.gameObject);
                    }
                    break;



            }


    }
}
