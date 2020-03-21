using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fogEnabler : MonoBehaviour
{
    // Start is called before the first frame update
    public FogEffect fogEffect;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            fogEffect.enabled = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            fogEffect.enabled = false;
        }
    }
}
