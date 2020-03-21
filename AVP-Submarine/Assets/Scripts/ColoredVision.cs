using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ColoredVision : MonoBehaviour
{
    public float waterLevel;
    private bool isUderwater;
    private Color normalColor;
    private Color underwaterColor;

    // Start is called before the first frame update
    void Start()
    {
        normalColor = new Color(0.5f, 0.5f, 0.5f, 0.5f);
        underwaterColor = new Color(0.22f, 0.65f, 0.77f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if((transform.position.y < waterLevel) != isUderwater)
        {
            isUderwater = transform.position.y < waterLevel;
            if(isUderwater)
            {
                SetUnderwater();
            }
            if (!isUderwater)
            {
                SetNormal();
            }
        }
    }

    void SetUnderwater()
    {
        RenderSettings.fogColor = underwaterColor;
        RenderSettings.fogDensity = 0.03f;
    }

    void SetNormal()
    {
        RenderSettings.fogColor = normalColor;
        RenderSettings.fogDensity = 0.002f;
    }
}
