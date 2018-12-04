using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileControlsScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void GoLeftPressed()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutorunMovementScript>().GoLeftPressed();
    }
    public void JumpPressed()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutorunMovementScript>().JumpPressed();
    }
    public void GoRightPressed()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAutorunMovementScript>().GoRightPressed();
    }
}
