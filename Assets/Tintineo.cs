using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tintineo : MonoBehaviour
{
    public float min;
    public float max;
    public float step;
    private float value;
    private Light luz;
    public Material pantalla;
    private Color origColor;
    private Color currentColor;
    private float colorRedStep = 0.07f;

    // Start is called before the first frame update
    void Start()
    {
        value = min;
        luz = GetComponent<Light>();
        origColor = new Color(0.5f, 0.5f, 0.5f);
        currentColor = origColor;
    }

    // Update is called once per frame
    void Update()
    {
        value += step;
        luz.range = value;
        if (value > max || value < min)
            step *= -1;

        if (currentColor.g >= 1f || currentColor.g <= 0f)
            colorRedStep *= -1;

        currentColor.g += colorRedStep;
        pantalla.color = currentColor;
    }
}
