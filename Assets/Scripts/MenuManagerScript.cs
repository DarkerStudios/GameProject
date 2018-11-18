using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Application.targetFrameRate = 60;
    }
	
    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }
}
