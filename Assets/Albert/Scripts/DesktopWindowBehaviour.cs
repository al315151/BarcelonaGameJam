using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DesktopWindowBehaviour : MonoBehaviour
{

    public RectTransform windowRect;
    public GameObject windowContent;
    RectTransform windowed_RectTransform;
    RectTransform fullScreen_RectTransform;
    bool Maximized;
    
    Vector3 window_position_offset;

    [Header("Access from desktop Behaviour")]
    public RawImage Game_background;
    public Image Icon;
    DesktopBehaviour desktopBehaviour_Reference;

    // Start is called before the first frame update
    void Start()
    {
        Maximized = false;
        setAuxiliarRectTransforms();
        window_position_offset = GetComponentInParent<RectTransform>().position;
        desktopBehaviour_Reference = GetComponentInParent<DesktopBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
         if (Input.GetKeyDown(KeyCode.O))
        {
            this.gameObject.SetActive(false);
        }
    }

    public void panWindow()
    {
        if (Maximized) { Maximized = false; }

    }

    public void MaximizeWindow()
    {
        Maximized = !Maximized;
        if (Maximized)
        {
            SetWindowedProperties(fullScreen_RectTransform);
        }
        else
        {
            SetWindowedProperties(windowed_RectTransform);
        }
    }

    public void MinimizeWindow()
    {
        desktopBehaviour_Reference.AddToMinimizedApps(this.name);
    }

    public void CloseWindow()
    {
        this.gameObject.SetActive(false);
    }


    public void SetWindowedProperties(RectTransform other)
    {
        windowRect.pivot = other.pivot;
        windowRect.position = other.position;
        windowRect.rotation = other.rotation;
        windowRect.localPosition = other.localPosition;
        
        windowRect.rect.Set(other.rect.x, other.rect.y,
                            other.rect.width, other.rect.height);
        windowRect.anchorMax = other.anchorMax;
        windowRect.anchorMin = other.anchorMin;
        windowRect.offsetMax = other.offsetMax;
        windowRect.offsetMin = other.offsetMin;
    }

    void setAuxiliarRectTransforms()
    {
        //Windowed Properties
        GameObject window_GO = new GameObject("windowed_" + this.name, typeof(RectTransform));
        windowed_RectTransform = window_GO.GetComponent<RectTransform>();
        windowed_RectTransform.localPosition = new Vector3(0f, 0f);
        windowed_RectTransform.position = new Vector3(0f, 0f);
        windowed_RectTransform.rect.Set(windowRect.rect.x, windowRect.rect.y + 36f,
                                        windowRect.rect.width, windowRect.rect.height);
        windowed_RectTransform.anchoredPosition = new Vector3(window_position_offset.x, window_position_offset.y);
        windowed_RectTransform.anchorMax = windowRect.anchorMax;
        windowed_RectTransform.anchorMin = windowRect.anchorMin;
        windowed_RectTransform.offsetMax = windowRect.offsetMax;
        windowed_RectTransform.offsetMin = windowRect.offsetMin;

        //Full_screen Properties
        GameObject FC_GO = new GameObject("FullScreen_" + this.name, typeof(RectTransform));
        fullScreen_RectTransform = FC_GO.GetComponent<RectTransform>();
        fullScreen_RectTransform.offsetMax = new Vector2(0, 0.0f); // new Vector2(left, bottom); 
        fullScreen_RectTransform.offsetMin = new Vector2(0, 0.0f); // new Vector2(-right, -top);
        fullScreen_RectTransform.pivot = new Vector2(0.5f, 0.5f);
        fullScreen_RectTransform.localPosition = new Vector3(0f, 0f);
        fullScreen_RectTransform.position = new Vector3(0f, 0f);
        fullScreen_RectTransform.anchoredPosition = new Vector3(window_position_offset.x, window_position_offset.y);
        fullScreen_RectTransform.rotation = windowRect.rotation;        
        fullScreen_RectTransform.rect.Set(windowRect.rect.x, windowRect.rect.y,
                                       windowRect.rect.width, windowRect.rect.height);
        fullScreen_RectTransform.anchorMax = new Vector2(1f, 1f);
        fullScreen_RectTransform.anchorMin = new Vector2(0, 0.1f);
    }


}
