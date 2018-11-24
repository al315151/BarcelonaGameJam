using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCapScript : MonoBehaviour
{

    public enum KeysAnim { A, S, D, F }
    public KeysAnim myKeysAnim;

    [Range(0, 1)]
    public float speed = 0.5f;

    private Vector3 initialPos;
    private Vector3 endPos;

    void Awake(){
        endPos = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z);
        initialPos = transform.position;
    }

    void Update()
    {
        switch (myKeysAnim) {
                case AnimCapScript.KeysAnim.A:
                    if (Input.GetKeyDown(KeyCode.A)) { 
                        StartCoroutine(animation());
                    }
                    break;
                case AnimCapScript.KeysAnim.S:
                    if (Input.GetKeyDown(KeyCode.S))
                    {
                        StartCoroutine(animation());
                    }
                    break;
                case AnimCapScript.KeysAnim.D:
                    if (Input.GetKeyDown(KeyCode.D))
                    {
                        StartCoroutine(animation());
                    }
                    break;
                case AnimCapScript.KeysAnim.F:
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        StartCoroutine(animation());
                    }
                    break;
        }
    }

    IEnumerator animation(){
        transform.position = Vector3.Lerp(endPos, initialPos, speed * Time.deltaTime);
        yield return new WaitForSeconds(0.1f);
        transform.position = Vector3.Lerp(initialPos, endPos, speed * Time.deltaTime);
    }
}
