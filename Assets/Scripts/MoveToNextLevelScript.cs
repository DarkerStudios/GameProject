using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToNextLevelScript : MonoBehaviour {

    private int nextScene;
	void Start () {
        nextScene = SceneManager.GetActiveScene().buildIndex +1;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutorunMovementScript>().SlowDown();
            StartCoroutine(DelayFornextLevel());
        }
        
    }
   
    private IEnumerator DelayFornextLevel()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(nextScene);
    }
}
