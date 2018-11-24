using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Canvas screenSpaceCanvas;
    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ActivateScreenCanvas();
        }

        
    }

    void ActivateScreenCanvas()
    {
        if (screenSpaceCanvas.gameObject.activeInHierarchy)
        {
            screenSpaceCanvas.gameObject.SetActive(false);
        }
        else { screenSpaceCanvas.gameObject.SetActive(true); }

    }



}
