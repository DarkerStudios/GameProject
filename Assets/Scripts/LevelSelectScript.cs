using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectScript : MonoBehaviour {

    private int levelSelected = 0;
    public GameObject playButton;
    private readonly int lastLevelNumber = 3;

	void Start ()
    {
        playButton.SetActive(false);
	}

    public void SelectLevel(int index)
    {
        if (index <= lastLevelNumber)
        {
            levelSelected = index;
            playButton.SetActive(true);
        }
    }

    public void GoToLevel()
    {
        SceneManager.LoadScene(levelSelected);
    }
}
