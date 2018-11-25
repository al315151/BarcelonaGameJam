using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractWithObjectsCheckBehaviour : MonoBehaviour
{
    public GameObject interactUI;
    private RaycastHit hit;
    private float checkDistance = 5f;
    int layerMask;
    public GameObject desktopCanvas;

    // Start is called before the first frame update
    void Start()
    {
        layerMask = 1 << 10;
        interactUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward)* checkDistance, Color.red, 0.1f);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, checkDistance, layerMask))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //ESCENA DE CASA, VAMOS A ESCENA DE PC CASA
                if (SceneManager.GetActiveScene().name == "Casa")
                {
                    SceneManager.LoadScene(1);
                }
                else if (SceneManager.GetActiveScene().name == "Oficina")
                {
                    SceneManager.LoadScene(3);
                }
            }
            
            interactUI.SetActive(true);
        }
        else
            interactUI.SetActive(false);
    }
}
