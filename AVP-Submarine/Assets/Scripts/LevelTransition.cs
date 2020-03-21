using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour {

    public Animator animator;

    public int levelToLoad;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void FadeToLevel(int levelIndex)
    {
        levelToLoad = levelIndex;
        animator.SetTrigger("FadeOut");
    }

    public void FadeToNextLevel(bool next)
    {
        if (next)
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            FadeToLevel(SceneManager.GetActiveScene().buildIndex - 1);
        }
    }
    public void OnFadeComplete()
    {
        SceneManager.LoadScene(levelToLoad);
    }
}
