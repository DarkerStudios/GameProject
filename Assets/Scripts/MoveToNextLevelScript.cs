using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevelScript : MonoBehaviour {

    private int nextScene;
	// Use this for initialization
	void Start () {
        nextScene = SceneManager.GetActiveScene().buildIndex +1;


    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            SceneManager.LoadScene(nextScene);
        }
        
    }
   
}
