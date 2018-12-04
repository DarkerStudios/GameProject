using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManagerScript : MonoBehaviour {

    public GameObject levelSelectCanvas;

	void Start ()
    {
        Application.targetFrameRate = 60;
        levelSelectCanvas.SetActive(false);
    }
	
    public void GoToGame()
    {
        SceneManager.LoadScene(1);
    }

    public void OpenLevelSelect()
    {
        levelSelectCanvas.SetActive(true);
    }
    public void HideLevelSelect()
    {
        levelSelectCanvas.SetActive(false);
    }
}
