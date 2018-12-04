using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour {

    private float gameSpeed = 0.8f;

    //Pause game
    public GameObject pausedGameGameObject;
    public GameObject removedWhenPausedGameObject;

	void Start ()
    {
        Time.timeScale = gameSpeed;
        Application.targetFrameRate = 60;
        pausedGameGameObject.SetActive(false);
    }

    public void ContinueGame()
    {
        pausedGameGameObject.SetActive(false);
        removedWhenPausedGameObject.SetActive(true);
        Time.timeScale = gameSpeed;
    }

    public void PauseGame()
    {
        removedWhenPausedGameObject.SetActive(false);
        pausedGameGameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
