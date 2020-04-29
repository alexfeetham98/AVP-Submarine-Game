using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFog : MonoBehaviour
{
    float waterLevel;
    private bool isUnderWater = true;
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
        if (isUnderWater)
        {
            SetUnderWater();
        }
        
    }

    void SetUnderWater()
    {
        RenderSettings.fogColor = underwaterColor;
        RenderSettings.fogDensity = 0.8f;
    }
}
