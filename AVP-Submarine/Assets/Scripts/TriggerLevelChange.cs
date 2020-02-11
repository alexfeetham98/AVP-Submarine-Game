using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerLevelChange : MonoBehaviour {
    public LevelTransition transition;

    public bool goesToNextLevel = true;
    public bool finishedLevel = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //other.GetComponent<PlayerControl>().FinishedLVL1(); //Player Controller - e.g. change relative position on spawn etc
            finishedLevel = true;
            transition.FadeToNextLevel(goesToNextLevel);
        }
    }
}
