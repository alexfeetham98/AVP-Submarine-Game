using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClampText : MonoBehaviour
{
    public Text infoBox;

    void Update()
    {
        Vector3 boxPos = Camera.main.WorldToScreenPoint(this.transform.position);
        infoBox.transform.position = boxPos;
        
    }
}
