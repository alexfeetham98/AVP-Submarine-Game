using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrButtonPress : MonoBehaviour
{
    public FollowPath followPath;
    public bool isBeingPressed;
    public Vector3 offsetToSet;
    public float offsetChangeEvery = 1.0f;

    private float timer = 0;
    private bool wasPressedOnce = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isBeingPressed)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            wasPressedOnce = false;
        }

        if (isBeingPressed && (!wasPressedOnce || (timer > offsetChangeEvery)))
        {
            if ((followPath.offset.x + offsetToSet.x < followPath.offsetMax && followPath.offset.x + offsetToSet.x > -followPath.offsetMax) &&
                (followPath.offset.y + offsetToSet.y < followPath.offsetMax && followPath.offset.y + offsetToSet.y > -followPath.offsetMax) &&
                (followPath.offset.z + offsetToSet.z < followPath.offsetMax && followPath.offset.z + offsetToSet.z > -followPath.offsetMax))
            {
                followPath.offset += offsetToSet;
            }

            //Debug.Log("hit");

            wasPressedOnce = true;
            timer = 0;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand")
        {
            isBeingPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "LeftHand" || other.gameObject.tag == "RightHand")
        {
            isBeingPressed = false;
        }
    }
}
