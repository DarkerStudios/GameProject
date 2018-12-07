using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        GameObject.FindGameObjectWithTag("LevelMusic").GetComponent<AudioSource>().Play();
        pausedGameGameObject.SetActive(false);
        removedWhenPausedGameObject.SetActive(true);
        Time.timeScale = gameSpeed;
    }

    public void PauseGame()
    {
        GameObject.FindGameObjectWithTag("LevelMusic").GetComponent<AudioSource>().Pause();
        removedWhenPausedGameObject.SetActive(false);
        pausedGameGameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
