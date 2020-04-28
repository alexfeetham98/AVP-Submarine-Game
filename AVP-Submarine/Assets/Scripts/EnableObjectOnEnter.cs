using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectOnEnter : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject objectToEnable;

    void Start()
    {
        objectToEnable.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectToEnable.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            objectToEnable.SetActive(false);
        }
    }
}
